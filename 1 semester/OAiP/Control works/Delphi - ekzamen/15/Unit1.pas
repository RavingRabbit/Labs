unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Button1: TButton;
    Label1: TLabel;
    Edit1: TEdit;
    Button2: TButton;
    Label2: TLabel;
    Memo1: TMemo;
    Button3: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  n,i:word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var j:word;
begin
   stringgrid1.cells[0,0]:='Фамилия';
   stringgrid1.cells[1,0]:='Ключ';
   n:=stringgrid1.RowCount-1;
   randomize;
   for i:=1 to n do
   begin
      j:=1+random(100);
      stringgrid1.Cells[0,i]:=chr(j)+chr(j+50)+chr(j+100);
      stringgrid1.Cells[1,i]:=inttostr(j);
   end;
   edit1.Clear;
   memo1.Clear;

end;

procedure TForm1.Button1Click(Sender: TObject);
var inf:Tinf; k:Tkey;
begin
   zad:=Tzad.create;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.addb(inf);
   end;

end;

procedure TForm1.Button2Click(Sender: TObject);
var inf:Tinf; k:Tkey;
begin
   k:=strtoint(edit1.Text);
   inf:=zad.Pioskb(k);
   if inf.k=nok then memo1.Lines.Add('Не найдено')
   else memo1.Lines.Add('Ключ: '+inttostr(inf.k)+'  Фамилия: '+inf.f);

end;

procedure TForm1.Button3Click(Sender: TObject);
begin
   zad.free;
end;

end.
