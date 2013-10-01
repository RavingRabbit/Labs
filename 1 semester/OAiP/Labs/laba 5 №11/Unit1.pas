unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, ExtCtrls, Grids;

type
  TForm1 = class(TForm)
    btn1: TBitBtn;
    strngrd1: TStringGrid;
    Label1: TLabel;
    edt1: TEdit;
    btn2: TButton;
    btn3: TButton;
    edt2: TEdit;
    btn4: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
type mas = array[0..0] of integer;
memory = ^mas;
var
  Form1: TForm1;
  N,i,j:Word;
  Inv:Integer;
  mas1:memory;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:=IntToStr(6);
N:=StrToInt(edt1.text);
edt2.clear;
end;

procedure TForm1.btn4Click(Sender: TObject);
begin
Randomize;
for i:=0 to N-1 do strngrd1.Cells[i,0]:=IntToStr(Random(10));
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
  try
   N:=StrToInt(edt1.text);
  except
    on EConvertError do ShowMessage('Введте целое число');
  end;
strngrd1.ColCount:=N;
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
{$R-}
Inv:=0;
GetMem(mas1,N*sizeof(Integer));
try
 for i:=0 to N-1 do mas1[i]:=strtoint(strngrd1.Cells[i,0]);
except
  on ERangeError  do ShowMessage('Выход за пределы массива. Уменьшите размер массива.');
  on EConvertError do MessageDlg('Заполните массив целочисленными значениями.',mtWarning,[mbOK],0);
  else ShowMessage('Возникла неизвестная ошибка. Sorry :'+'(');
 end;
for j:=0 to N-2 do
 begin
  i:=j;
  while i<N-1 do
   begin
   if mas1[j]>mas1[i+1] then inc(Inv);
   inc(i);
   end;
 end;
FreeMem(mas1,N*sizeof(Integer));
edt2.Text:=IntToStr(Inv);
end;

end.
