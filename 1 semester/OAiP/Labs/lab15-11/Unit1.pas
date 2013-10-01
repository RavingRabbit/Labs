unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, StdCtrls, XPMan, Buttons, ExtCtrls, Unit3;

type
  TForm1 = class(TForm)
    lst1: TListBox;
    edt1: TEdit;
    btn3: TButton;
    Button1: TButton;
    edt3: TEdit;
    btn1: TButton;
    lbl2: TLabel;
    edt4: TEdit;
    btn4: TBitBtn;
    shp1: TShape;
    btn5: TButton;
    lst2: TListBox;
    img1: TImage;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure FormDblClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  list: Tlist;
  zad: Tzad;
implementation

{$R *.dfm}

procedure TForm1.btn1Click(Sender: TObject);
begin
  list.Add1(strtoint(edt1.Text));
  list.Print(lst1);
  edt3.enabled:=true;
  Button1.enabled:=true;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  list:=Tlist.create;
  zad:=Tzad.create;
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
  zad.Print(lst2);
end;

procedure TForm1.Button1Click(Sender: TObject);
var inf:Integer;
begin
  list.read1(inf);
  list.Print(lst1);
  edt3.Text:=IntToStr(inf);
end;

procedure TForm1.btn4Click(Sender: TObject);
begin
  zad.add_random(StrToInt(edt4.text));
  btn5.Enabled:=True;
  btn3.Enabled:=True;
end;

procedure TForm1.btn5Click(Sender: TObject);
begin
  zad.replace;
  zad.Print(lst2);
end;

procedure TForm1.FormDblClick(Sender: TObject);
begin
  Img1.Picture.LoadFromFile('Trollface.bmp');
  img1.Show;
end;

end.
