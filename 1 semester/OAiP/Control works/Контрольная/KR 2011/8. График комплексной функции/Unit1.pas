unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, XPMan, TeEngine, Series, TeeProcs, Chart, Math, Unit2;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    btn1: TButton;
    cht1: TChart;
    YSeries1: TLineSeries;
    YSeries2: TLineSeries;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

function Mulc(x,y:Complex):Complex;
function myfc(x:extended):Complex;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='0';
edt2.Text:='10';
edt3.Text:='150';
end;


function Mulc(x,y:Complex):Complex;//x*y
begin
   Mulc.re:=x.re*y.re-x.im*y.im;
   Mulc.im:=x.re*y.im+x.im*y.re;
end;

function myfc;
var a,b:complex;
begin
  a.re:=2; a.im:=x;
  b.re:=x; b.im:=-2;
  result:=mulc(a,b);
end;


procedure TForm1.btn1Click(Sender: TObject);
var a,b:extended; n:integer;
begin
   a:=strtofloat(edt1.text);
   b:=strtofloat(edt2.text);
   n:=strtoint(edt3.text);
   graf(a,b,n,myfc,cht1);
end;

end.
