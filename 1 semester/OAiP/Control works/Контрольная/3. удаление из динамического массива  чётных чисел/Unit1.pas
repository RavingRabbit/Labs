unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, XPMan, Unit2, Grids, StdCtrls;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    lbl2: TLabel;
    btn1: TButton;
    strngrd1: TStringGrid;
    strngrd2: TStringGrid;
    lbl3: TLabel;
    edt1: TEdit;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
type
  Pmas1 = array[1..1] of Integer;
  Tm = ^Pmas1;
var
  Form1: TForm1;
  n,n1:Integer;
  mas1: Tm;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='5';
end;

procedure TForm1.btn1Click(Sender: TObject);
var i:Integer;
begin
  {$R-}
  Randomize;
  n:=StrToInt(edt1.text);
  GetMem (mas1,n*sizeof(Integer));
  for i:=0 to n do
   begin
    strngrd1.Cells[i,0]:=IntToStr(Random(10));
    mas1[i]:=StrToInt(strngrd1.Cells[i,0]);
   end;
  n1:=n*2;
  algoritm(mas1,n,n1);
  FreeMem(mas1);
  strngrd2.Cells[0,0]:=IntToStr(n);
  strngrd2.Cells[1,0]:=IntToStr(n1);
end;

end.
