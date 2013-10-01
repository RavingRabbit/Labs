unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls, Unit2, XPMan;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    lbl1: TLabel;
    edt2: TEdit;
    edt3: TEdit;
    lbl2: TLabel;
    lbl3: TLabel;
    btn1: TButton;
    img1: TImage;
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
edt1.text:='5';
edt2.Text:='5';
edt3.Text:='3';
end;

procedure TForm1.btn1Click(Sender: TObject);
var R,x,y:integer; h:extended;
begin
  R:=strtoint(edt1.Text);
  x:=strtoint(edt2.text);
  y:=strtoint(edt3.text);
  h:=img1.Height/(3*R);
  Ellipse(R,x,y,h,img1);
end;

end.
