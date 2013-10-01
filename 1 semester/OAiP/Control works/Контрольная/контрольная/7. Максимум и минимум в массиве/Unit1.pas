unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit2, XPMan;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    btn1: TButton;
    btn2: TButton;
    edt1: TEdit;
    btn3: TButton;
    mmo1: TMemo;
    chk1: TCheckBox;
    procedure FormCreate(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  N:integer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='5';
mmo1.Clear;
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
strngrd1.ColCount:=strtoint(edt1.Text);
N:=strtoint(edt1.Text);
end;

procedure TForm1.btn3Click(Sender: TObject);
var i:integer;
begin
N:=strtoint(edt1.Text);
randomize;
for i:=0 to N-1 do
  begin
    strngrd1.Cells[i,0]:=inttostr(random(15));
  end;
end;

procedure TForm1.btn1Click(Sender: TObject);
var A:Tmas; i:integer;  bl:boolean;
begin
  bl:=chk1.Checked;
  N:=strtoint(edt1.Text);
  getmem(a,sizeof(integer)*N);
  for i:=0 to N-1 do begin
    A[i]:=strtoint(strngrd1.Cells[i,0]);
  end;
  mmo1.lines.add('Номер элемента = '+inttostr(fun(A,N,bl)));
  freemem(a,sizeof(integer)*N);
end;

end.
