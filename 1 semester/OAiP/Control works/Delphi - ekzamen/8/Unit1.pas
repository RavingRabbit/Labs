unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,unit2, StdCtrls, Buttons, Grids;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
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
  n,i:integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var j:integer;
begin
   stringgrid1.Cells[0,0]:='Фамилия';
   stringgrid2.Cells[0,0]:='Фамилия';
   stringgrid1.Cells[1,0]:='Ключ';
   stringgrid2.Cells[1,0]:='Ключ';
   randomize;
   n:=stringgrid1.RowCount-1;
   for i:=1 to n do
   begin
      j:=1+random(100);
      stringgrid1.Cells[1,i]:=inttostr(j);
      stringgrid1.Cells[0,i]:=chr(j)+chr(j+50)+chr(j+100);
   end;
end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var inf:Tinf;
begin
   zad:=tzad.Create;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.Add1(inf);
   end;
   zad.sortb;
   for i:=1 to n do
   begin
      zad.read1(inf);
      stringgrid2.Cells[0,i]:=inf.f;
      stringgrid2.Cells[1,i]:=inttostr(inf.k);
   end;
   zad.Free;



end;

end.
 