unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, StdCtrls, XPMan;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    btn1: TButton;
    mmo1: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
var
  Form1: TForm1;
function fun(x:extended):extended;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
 mmo1.Clear;
 edt1.Text:='0';
 edt2.Text:='10';
 edt3.Text:='20';
end;

function fun(x:extended):extended;
var k:integer; y,m0,m:extended;
begin
  y:=0;  m:=x;  k:=1;
  repeat
    y:=y+m;
    inc(k);
    m0:=m;
    m:=m*x/k;
  until abs(m0-m)<0.01;
  result:=y;
end;

procedure TForm1.btn1Click(Sender: TObject);
var a,b:extended; n:integer;
begin
 a:=strtofloat(edt1.text);
 b:=strtofloat(edt2.text);
 n:=strtoint(edt3.text);
 tab(a,b,n,mmo1,fun);
end;

end.
