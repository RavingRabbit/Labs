unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, XPMan;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    edt2: TEdit;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    btn1: TButton;
    edt3: TEdit;
    edt4: TEdit;
    lbl4: TLabel;
    lbl5: TLabel;
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
   edt1.text:='20';
   edt2.Text:='50';
   edt3.clear;
   edt4.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
var M,N,NOD,NOK:integer;
begin
 M:=strtoint(edt1.Text);
 N:=strtoint(edt2.Text);
 prog(M,N,NOD,NOK);
 edt3.Text:=inttostr(NOD);
 edt4.Text:=inttostr(NOK);
end;

end.
