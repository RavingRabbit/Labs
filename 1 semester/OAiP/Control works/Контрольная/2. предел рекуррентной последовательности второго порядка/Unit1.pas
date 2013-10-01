unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, StdCtrls;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    lbl2: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    edt4: TEdit;
    lbl3: TLabel;
    lbl4: TLabel;
    mmo1: TMemo;
    btn1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  x0,x1,a,e:Extended;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='1';
edt2.Text:='2';
edt3.Text:='5';
edt4.Text:='0,001';
mmo1.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
x0:=StrToFloat(edt1.text);
x1:=StrToFloat(edt2.text);
a:=StrToFloat(edt3.Text);
e:=StrToFloat(edt4.text);
mmo1.Lines.Add('X0 = '+FloatToStr(x0)+', '+'X1 = '+FloatToStr(x1)+', '+'a = '+FloatToStr(a)+', '+'s = '+FloatToStr(e));
Limit(a,e,x0,x1);
if i=101 then
mmo1.Lines.Add('Нет сходимости')
else
mmo1.Lines.Add('Предел рекурентной последовательности = '+floattostr(x));
end;

end.
