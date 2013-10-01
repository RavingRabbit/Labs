unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math, unit2;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    edt1: TEdit;
    lbl2: TLabel;
    edt2: TEdit;
    lbl3: TLabel;
    lbl4: TLabel;
    edt3: TEdit;
    edt4: TEdit;
    btn1: TButton;
    mmo1: TMemo;
    lbl5: TLabel;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);

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
edt1.text:='0,2';
  edt2.text:='1';
  edt3.text:='5';
  edt4.text:='0,001';
  mmo1.Clear;
end;
 function fun1 (x:Extended):Extended;
  var e,a,s:Extended; n:Integer; edt4: TEdit;
begin
    a:=1; S:=1; n:=0;

    while(Abs(a)>e) do begin
      Inc(n);
      a:=(-1)*a*sqr(x)/((2*n)*(2*n-1));
      s:=s+a*(2*sqr(n)+1);
    end;
    Result:=s;
end;

procedure TForm1.btn1Click(Sender: TObject);
var xn,xk,e,m:Extended;
begin
  mmo1.Clear;
  mmo1.Lines.Add('Результаты ст. гр. 152003 Игнатенко А.А.');
  xn:=StrToFloat(edt1.text);
  mmo1.Lines.Add('Xn='+floattostrF(xn,ffFixed,6,2));
  xk:=StrToFloat(edt2.text);
  mmo1.Lines.Add('Xk='+floattostrF(xk,ffFixed,6,2));
  m:=StrToFloat(edt3.Text);
  mmo1.Lines.Add('M='+floattostrf(m,fffixed,8,3));
  e:=strtofloat(edt4.text);
  mmo1.lines.add('e='+floattostrf(e,fffixed,8,5));
  Tabl(fun1,xn,xk,e,m,mmo1);
end;

end.
