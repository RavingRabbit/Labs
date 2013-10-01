unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, XPMan, Unit2;
type
  TForm1 = class(TForm)
    edt1: TEdit;
    lbl1: TLabel;
    edt2: TEdit;
    lbl2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure edt1KeyPress(Sender: TObject; var Key: Char);
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
 edt1.Clear;
 edt2.Clear;
end;

procedure TForm1.edt1KeyPress(Sender: TObject; var Key: Char);
begin
 if Key = #13 then edt2.Text:=Convert(edt1.Text);
end;

end.
