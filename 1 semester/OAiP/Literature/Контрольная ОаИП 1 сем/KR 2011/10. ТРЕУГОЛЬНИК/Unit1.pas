unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, ExtCtrls, StdCtrls;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    edt4: TEdit;
    edt5: TEdit;
    edt6: TEdit;
    btn1: TButton;
    img1: TImage;
    edt7: TEdit;
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
  edt1.Text:='1';
  edt2.Text:='1';
  edt3.Text:='2';
  edt4.Text:='2';
  edt5.Text:='3';
  edt6.Text:='3';
  edt7.text:='10';
end;

procedure TForm1.btn1Click(Sender: TObject);
var x1,x2,x3,y1,y2,y3,h:extended;
begin
  x1:=strtofloat(edt1.Text);
  x2:=strtofloat(edt3.Text);
  x3:=strtofloat(edt5.Text);
  y1:=strtofloat(edt2.Text);
  y2:=strtofloat(edt4.Text);
  y3:=strtofloat(edt6.Text);
  h:=strtofloat(edt7.Text);
  treug(x1,x2,x3,y1,y2,y3,h,img1);
end;

end.
