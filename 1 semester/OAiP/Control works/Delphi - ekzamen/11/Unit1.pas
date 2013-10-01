unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, unit2, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Edit2: TEdit;
    Label2: TLabel;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
   edit2.Clear;
   edit1.Text:='(a+b)*(c^d)';
end;

procedure TForm1.Button1Click(Sender: TObject);
var s:String;
begin
   zad:=Tzad.Create;
   zad.OBP(edit1.Text,s);
   edit2.Text:=s;
end;

end.
