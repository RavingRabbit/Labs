unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, XPMan, Unit2, Grids, StdCtrls, Buttons, ExtCtrls;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    btn1: TButton;
    strngrd1: TStringGrid;
    btn2: TButton;
    edt2: TEdit;
    lbl1: TLabel;
    btn3: TBitBtn;
    lbl2: TLabel;
    lbledt1: TLabeledEdit;
    lbledt2: TLabeledEdit;
    btn4: TButton;
    lbl3: TLabel;
    lbledt3: TLabeledEdit;
    btn5: TBitBtn;
    edt3: TEdit;
    btn6: TButton;
    strngrd2: TStringGrid;
    lbl4: TLabel;
    lbl5: TLabel;
    shp1: TShape;
    shp2: TShape;
    lbl6: TLabel;
    lbl7: TLabel;
    btn7: TButton;
    mmo1: TMemo;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure btn7Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  H1:THesh;
  M0,n:word;
  Inf:Tinf;
  Key:Tkey;

implementation

{$R *.dfm}

procedure TForm1.btn1Click(Sender: TObject);
begin
  M0:=StrToInt(Edt1.Text);
  H1:=THesh.create(M0);
  btn2.Enabled:=true;
  btn4.Enabled:=true;
  btn6.Enabled:=true;
  btn7.Enabled:=true;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  strngrd1.Cells[0,0]:='ÔÈÎ';
  strngrd1.cells[1,0]:='Êëþ÷';
  strngrd2.Cells[0,0]:='ÔÈÎ';
  strngrd2.cells[1,0]:='Êëþ÷';
end;

procedure TForm1.btn2Click(Sender: TObject);
var i:word;
begin
  n:=StrToInt(Edt2.Text);
  for i:=1 to n do
    begin
      Inf.Fio:=Strngrd1.Cells[0,i];
      Inf.key:=StrToInt(Strngrd1.Cells[1,i]);
      H1.Add(inf);
    end;
  btn5.Enabled:=true;
end;

procedure TForm1.btn3Click(Sender: TObject);
var i:word;
begin
  strngrd1.rowcount:=strtoint(edt2.Text)+1;
  randomize;
  for i:=1 to strtoint(edt2.Text) do
    begin
      Strngrd1.Cells[0,i]:=chr(random(25)+97)+chr(random(25)+97)+chr(random(25)+97);
      Strngrd1.Cells[1,i]:=inttostr(random(9999));
    end;
end;

procedure TForm1.btn4Click(Sender: TObject);
begin
  Inf.Fio:=lbledt1.Text;
  Inf.key:=StrToInt(lbledt2.Text);
  H1.Add(inf);
end;

procedure TForm1.btn5Click(Sender: TObject);
begin
  key:=StrToInt(lbledt3.Text);
  edt3.Text:=H1.Readd(key).FIO;
end;

procedure TForm1.btn6Click(Sender: TObject);
begin
  Strngrd2.rowcount:=H1.n+1;
  //freeandnil(H1);
  H1.Free(Strngrd2);
  btn2.Enabled:=False;
  btn4.Enabled:=False;
  btn5.Enabled:=False;
  btn6.Enabled:=False;
  btn7.Enabled:=False;
end;

procedure TForm1.btn7Click(Sender: TObject);
begin
  mmo1.clear;
  H1.count(mmo1);
end;

end.
