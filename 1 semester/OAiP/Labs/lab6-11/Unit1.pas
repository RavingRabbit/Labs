unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math, ExtCtrls, Buttons, Xpman;

type
  fun=function (x:Extended):Extended;
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
    rg1: TRadioGroup;
    btn2: TBitBtn;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  e:extended;
procedure Tabl(fun:fun;xn,xk,e:extended; m: word; Mmo1 : TMemo);  external 'lib.dll';

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  edt1.text:='0,2';
  edt2.text:='1';
  edt3.text:='5';
  edt4.text:='0,001';
  mmo1.Clear;
  rg1.itemindex:=0;
end;

function fun1 (x:Extended):Extended;
var a,s:Extended; n:Integer;
begin
    a:=1; S:=1; n:=0;
    while (Abs(a) > e) do begin
      Inc(n);
      a:=(-1)*a*sqr(x)/((2*n)*(2*n-1));
      s:=s+a*(2*sqr(n)+1);
    end;
    Result:=s;
end;

function fun2 (x:Extended):Extended;
var y:Extended;
begin
    y:=(1-sqr(x)/2)*cos(x)-x/2*sin(x);
    Result:=y;
end;

procedure TForm1.btn1Click(Sender: TObject);
var xn,xk:Extended; m:Word;
begin
  mmo1.Clear;
  mmo1.Lines.Add('Результаты ст. гр. 152003 Игнатенко А.А.');
  try
    xn:=StrToFloat(edt1.text);
    mmo1.Lines.Add('Xn='+floattostrF(xn,ffFixed,6,2));
    xk:=StrToFloat(edt2.text);
    mmo1.Lines.Add('Xk='+floattostrF(xk,ffFixed,6,2));
    e:=strtofloat(edt4.text);
    mmo1.lines.add('e='+floattostrf(e,fffixed,8,5));
  except
    on EConvertError do showmessage('Заполните поля числовыми значениями');
  end;
  try
    m:=StrToInt(edt3.Text);
    mmo1.Lines.Add('M='+inttostr(m));
  except
      on EConvertError do MessageDlg('M — целое число',mtWarning,mbOKcancel,1);
  end;

  case rg1.itemindex of
    0: Tabl(fun1,xn,xk,e,m,mmo1);
    1: Tabl(fun2,xn,xk,e,m,mmo1);
  end;
end;
end.
