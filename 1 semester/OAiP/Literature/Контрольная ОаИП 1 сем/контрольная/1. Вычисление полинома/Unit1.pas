unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls, XpMan, Unit2;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    edt1: TEdit;
    lbl1: TLabel;
    btn1: TButton;
    btn2: TButton;
    mmo1: TMemo;
    btn3: TButton;
    edt2: TEdit;
    lbl2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  N:Integer;
  A:Tmas;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  strngrd1.cells[0,0]:='Ai';
  edt1.Text:='4';
  N:=4;
  mmo1.Clear;
  edt2.Text:='2,54';
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
  strngrd1.ColCount:=1+strtoint(edt1.Text);
end;

procedure TForm1.btn2Click(Sender: TObject);
var i:Integer;
begin
  N:=strtoint(edt1.Text);
  randomize;
  for i:=1 to N do begin
   strngrd1.Cells[i,0]:=IntToStr(Random(10));
  end;
end;

procedure TForm1.btn3Click(Sender: TObject);
var i:Integer;
    x:Extended;
begin
  mmo1.clear;
  N:=strtoint(edt1.Text);
  GetMem(A,SizeOf(extended)*(N+2));
  x:=StrToFloat(edt2.text);
  for i:=1 to N do begin
    A[i]:=StrToInt(strngrd1.Cells[i,0]);
  end;
  for i:=1 to N do begin
    mmo1.Lines.add('A'+inttostr(i)+' = '+strngrd1.Cells[i,0]);
  end;
  mmo1.Lines.Add('Значение полинома = '+FloatToStr(polinom(x,N,A)));
  FreeMem(A,SizeOf(extended)*(N+2));
end;

end.
