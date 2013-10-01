unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, XPMan, unit2, Grids, StdCtrls;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    btn1: TButton;
    edt1: TEdit;
    btn2: TButton;
    lbl1: TLabel;
    btn3: TButton;
    lbl2: TLabel;
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btn3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  A:Tlistms;
implementation

{$R *.dfm}

procedure TForm1.btn1Click(Sender: TObject);
Var i,j:word;
begin
  A:=Tlistms.create(strtoint(edt1.text),strtoint(edt1.text));
  for i:=1 to strtoint(edt1.text) do
    for j:=1 to strtoint(edt1.text) do
      begin
        A.add(i,j,strtoint(strngrd1.cells[i,j]));
      end;
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
  strngrd1.ColCount:=strtoint(edt1.Text)+1;
  strngrd1.RowCount:=strtoint(edt1.Text)+1;
end;

procedure TForm1.FormCreate(Sender: TObject);
var i,j:word;
begin
  for i:=1 to strtoint(edt1.Text) do strngrd1.cells[0,i]:=inttostr(i);
  for j:=1 to strtoint(edt1.Text) do strngrd1.cells[j,0]:=inttostr(j);
end;

procedure TForm1.btn3Click(Sender: TObject);
var s:extended; i:word;
begin
  s:=0;
  for i:=1 to strtoint(edt1.Text) do
    s:=s+A.read(i,i);
  lbl2.Caption:=floattostr(s);
end;

end.
