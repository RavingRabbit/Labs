unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, XPMan;

type
  TForm1 = class(TForm)
    btn1: TButton;
    edt1: TEdit;
    edt2: TEdit;
    dlgOpen1: TOpenDialog;
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
edt1.text:='s';
edt2.clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
var x:char; fl:Tch;
begin
   x:=edt1.text[1];
   if dlgOpen1.Execute then begin
      assignfile(fl,dlgopen1.FileName);
      reset(fl);
      edt2.text:=x+' встречается в файле '+inttostr(kol(fl,x))+' раз.';
      closefile(fl);
   end;

end;

end.
