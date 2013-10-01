unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, unit2, StdCtrls, XPMan;

type
  TForm1 = class(TForm)
    edt1: TEdit;
    btn1: TButton;
    edt2: TEdit;
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
edt1.Text:='4567';
edt2.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
var N:integer;
begin
  N:=strtoint(edt1.Text);
  zamena(N);
  edt2.Text:=inttostr(N);
end;

end.
