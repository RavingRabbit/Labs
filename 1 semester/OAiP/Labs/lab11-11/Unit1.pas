unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, unit2, XPMan, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    rg1: TRadioGroup;
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

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  edt1.clear;
  edt2.Text:='9';
  rg1.ItemIndex:=0;
end;

procedure TForm1.btn1Click(Sender: TObject);
var n:integer; rec:Trec;
begin
  n:=strtoint(edt2.text);
  case rg1.ItemIndex of
    0: edt1.text:='Рекуррентно '+floattostrf(rec.recurrentno(n),fffixed,6,5);
    1: edt1.text:='Рекурсивно '+floattostrf(rec.recursivno(n),fffixed,6,5);
  end;
end;

end.
