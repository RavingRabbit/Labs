unit laba1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    lbl4: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
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

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  mmo1.Clear;
  edt1.Text:='6,251';
  edt2.Text:='0,827';
  edt3.Text:='25,001';
end;

procedure TForm1.btn1Click(Sender: TObject);
var a,b,c,u,x,y,z:Extended;
begin
   mmo1.Clear;
   mmo1.Lines.Add('Исходные данные:');
   x:=strtofloat(edt1.Text);
   y:=strtofloat(edt2.Text);
   z:=strtofloat(edt3.Text);
   mmo1.Lines.Add('X='+floattostrF(x,ffFixed,8,3)+',');
   mmo1.Lines.Add('Y='+floattostrF(y,ffFixed,8,3)+',');
   mmo1.Lines.Add('Z='+floattostrF(z,ffFixed,8,3)+'.');
   a:=Power(y,Power(abs(x),1/3));
   b:=Power(Cos(y),3)*abs(x-y)*(1+Sqr(Sin(z)/Sqrt(x+y)));
   c:=Exp(Abs(x-y))+x/2;
     u:=a+b/c;
     mmo1.Lines.Add('Резульаты U='+floattostrF(u,ffFixed,8,4)+'.');
end;

end.
