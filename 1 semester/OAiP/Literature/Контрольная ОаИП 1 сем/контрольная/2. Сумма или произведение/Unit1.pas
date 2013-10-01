unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, unit2, Xpman, ExtCtrls;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    btn1: TButton;
    edt2: TEdit;
    rg1: TRadioGroup;
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
  edt1.Text:='134';
  edt2.Clear;
  rg1.ItemIndex:=0;
end;

procedure TForm1.btn1Click(Sender: TObject);
var N:integer; bl:boolean;
begin
 N:=strtoint(edt1.Text);
 case rg1.itemindex of
 0:  bl:=true;
 1: bl:=false;
 end;
 edt2.Text:=inttostr(fun(N,bl));
end;

end.
