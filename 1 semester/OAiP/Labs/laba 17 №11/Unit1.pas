unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, Buttons, StdCtrls, XPman, unit2, math;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    edt1: TEdit;
    edt2: TEdit;
    lbl1: TLabel;
    btn1: TBitBtn;
    lbl2: TLabel;
    btn2: TBitBtn;
    edt3: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
  private { Private declarations }
  public { Public declarations }
  end;

var
  Form1: TForm1;
  zad: Tzad;
implementation
{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  zad:=Tzad.create;
  strngrd1.cells[0,0]:='argum';
  strngrd1.cells[1,0]:='value';
  strngrd1.cells[0,1]:='d'; strngrd1.cells[1,1]:='0,5';
  strngrd1.cells[0,2]:='e'; strngrd1.cells[1,2]:='4';
  strngrd1.cells[0,3]:='f'; strngrd1.cells[1,3]:='5';
  strngrd1.cells[0,4]:='g'; strngrd1.cells[1,4]:='0,75';
  strngrd1.cells[0,5]:='s'; strngrd1.cells[1,5]:='9';
  strngrd1.cells[0,6]:='a'; strngrd1.cells[1,6]:='3';
  strngrd1.cells[0,7]:='w'; strngrd1.cells[1,7]:='0';
end;

procedure TForm1.btn1Click(Sender: TObject);
var stri,strp: string;
begin
  edt2.show;
  lbl2.show;
  stri:=edt1.Text;
  zad.convert(stri,strp);
  edt2.text:=strp;
  btn2.Enabled:=true;
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
  zad.read_mas(strngrd1);
  edt3.Text:=FloatToStr(zad.calculate(edt2.Text));
  edt3.Show;
end;

end.
