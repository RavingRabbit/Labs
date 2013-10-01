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
    btn1: TButton;
    edt4: TEdit;
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
edt1.Text:='0';
edt2.Text:='10';
edt3.Text:='0,354';
edt4.Clear;
end;

function fun(x:extended):extended;
begin
  result:=sqr(x-1);
end;

procedure TForm1.btn1Click(Sender: TObject);
var a,b,h:extended;
begin
  a:=strtofloat(edt1.Text);
  b:=strtofloat(edt2.Text);
  h:=strtofloat(edt3.Text);
  edt4.Text:=floattostr(funct(a,b,h,fun));
end;

end.
