unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
    Label2: TLabel;
    Edit2: TEdit;
    Button2: TButton;
    Edit3: TEdit;
    Label3: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  i,n,m0:word;
  zad:Tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var j:integer;
begin
   edit1.Text:='15';
   edit2.Clear;
   edit3.Clear;
   stringgrid1.Cells[0,0]:='Фамилия';
   stringgrid1.Cells[1,0]:='Ключ';
   n:=15;
   m0:=15;
   randomize;
   for i:=1 to n do
   begin
      j:=1+random(100);
      stringgrid1.Cells[0,i]:=chr(j)+chr(j+50)+chr(j+100);
      stringgrid1.Cells[1,i]:=inttostr(j);
   end;

end;

procedure TForm1.Button1Click(Sender: TObject);
var inf:Tinf;
begin
   m0:=strtoint(edit1.text);
   zad:=Tzad.create(m0);
   for i:=1 to m0 do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.Add(inf);
   end;
end;

procedure TForm1.Button2Click(Sender: TObject);
var k:Tkey; inf:Tinf;
begin
   k:=strtoint(edit2.Text);
   inf:=zad.Read(k);
   if inf.k<>nok then edit3.Text:=inf.f
   else edit3.Text:='Не найдено';

end;

end.
