unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2;

type
  TForm1 = class(TForm)
    lbl1: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    btn1: TButton;
    lbl2: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  N:integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='1578';
edt2.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
N:=strtoint(edt1.Text);
algoritm(N);
edt2.Text:=intToStr(M);
end;

end.
