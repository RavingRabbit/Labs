unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, unit2, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  ob:tclass;
  x0,y0:word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
x0:=Image1.Width div 2;
y0:=Image1.Height div 2;
ColorBack:=clWhite;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
ob:= tclass.create(x0,y0,30,clblack,image1.canvas);
ob.show;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
ob.Free;
end;

end.
