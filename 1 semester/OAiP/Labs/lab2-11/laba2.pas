unit laba2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    lbl4: TLabel;
    mmo1: TMemo;
    chk1: TCheckBox;
    rg1: TRadioGroup;
    procedure FormCreate(Sender: TObject);
    procedure mmo1Click(Sender: TObject);
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
edt1.Text:='0,1';
edt2.Text:='0,356';
edt3.Text:='0,53';
mmo1.Lines.Add('Результаты ст. гр. 152003 Игнатенко А.А.');
rg1.ItemIndex:=0;
end;

// обработчик Memo1Click
procedure TForm1.mmo1Click(Sender: TObject);
var x,y,z,u,max,min,m: Extended;
begin
  mmo1.Clear;
  mmo1.Lines.Add('Результаты ст. гр. 152003 Игнатенко А.А.');
  x:=strtofloat(edt1.text);
  y:=StrToFloat(edt2.Text);
  z:=StrToFloat(edt3.Text);
  mmo1.Lines.Add('Исходные данные:');
  mmo1.Lines.Add('x='+floattostr(x)+',');
  mmo1.Lines.Add('y='+floattostr(y)+',');
  mmo1.Lines.Add('z='+floattostr(z)+'.');
   case rg1.ItemIndex of
    0: u:=(Exp(x)-Exp(-x))/2;
    1: u:=sqr(x);
    2: u:=Exp(x);
    end;
  if u>y then max:=u else max:=y;
  if z>max then max:=z;
  if u<y then min:=u else min:=y;
  m:=max/min+5;
  if chk1.checked then
    mmo1.LineS.add('Результат m='+inttostr(Round(m))+'.')
   else
    mmo1.LineS.Add('Результат m='+floattostrf(m,ffgeneral,8,2)+'.');
end;

end.
