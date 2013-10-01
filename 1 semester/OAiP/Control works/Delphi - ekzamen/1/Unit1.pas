unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    BitBtn1: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  i,n:integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var j:word;
begin
   n:=stringgrid1.RowCount-1;
   stringgrid1.Cells[0,0]:='Фамилия';
   stringgrid1.Cells[1,0]:='Ключ';
   randomize;
   for i:=1 to n do
   begin
      j:=1+random(100);
      stringgrid1.Cells[1,i]:=inttostr(j);
      stringgrid1.Cells[0,i]:=chr(j)+chr(j+50)+chr(j+100);
   end;
   edit1.Clear;
   edit2.clear;

end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var inf:tinf; k:Tkey;
begin
   zad:=Tzad.Create;
   zad.n:=n;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(Stringgrid1.Cells[1,i]);
      zad.a[i]:=inf;
   end;
   zad.sort;
   k:=strtoint(edit1.Text);
   inf:=zad.poiskd(k);
   if inf.k<>nok then edit2.Text:=inf.f
      else showmessage('Не найдено');

   zad.Free;
end;

end.
