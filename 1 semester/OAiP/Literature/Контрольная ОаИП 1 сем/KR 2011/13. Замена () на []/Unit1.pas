unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Unit2, XPMan;

type
  TForm1 = class(TForm)
    btn1: TButton;
    dlgOpen1: TOpenDialog;
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

procedure TForm1.btn1Click(Sender: TObject);
var fl:Tch; namefl:string;
begin
 if dlgOpen1.execute then
 begin
       Namefl:=dlgOpen1.FileName;
       AssignFile(fl,Namefl);
       Reset(fl);
       zamena(fl,'(','[');
       seek(fl,0);
       zamena(fl,')',']');
       closefile(fl);
 end;
end;

end.
