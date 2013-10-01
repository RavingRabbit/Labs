unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, unit2, XPMan;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    btn1: TButton;
    img1: TImage;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.text:='0';
edt2.Text:='5';
edt3.Text:='100';
end;

function fun(x:extended):extended;
var y,a:extended; i:integer;
begin
  a:=x;
  i:=1;
  y:=0;
  repeat
    Y:=y+a;
    inc(i);
    a:=a*x/i;
  until abs(a)<0.01;
  result:=y;
end;

procedure TForm1.btn1Click(Sender: TObject);
var a,b:extended; n:integer;
begin
  a:=strtofloat(edt1.Text);
  b:=strtofloat(edt2.Text);
  n:=strtoint(edt3.Text);
  graf(a,b,n,fun,img1);
end;

end.
