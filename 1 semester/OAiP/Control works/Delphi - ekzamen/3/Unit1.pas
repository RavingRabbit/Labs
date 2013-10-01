unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, unit2;

type
  TForm1 = class(TForm)
    Image1: TImage;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
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

procedure TForm1.Button1Click(Sender: TObject);
var x0,y0,r0:Integer;  canvas0:Tcanvas;
begin
   x0:=image1.Width div 2;
   y0:=image1.Height div 2;
   r0:=50;
   canvas0:=Image1.Canvas;
   zad:=Tzad.Create(x0,y0,r0,canvas0);
   zad.show;


end;

procedure TForm1.Button2Click(Sender: TObject);
begin
   zad.moveto(0,-10,0);
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
   zad.moveto(0,10,0);

end;

procedure TForm1.Button4Click(Sender: TObject);
begin
   zad.moveto(-10,0,0);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
   zad.moveto(10,0,0);
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
   zad.Free;
   image1.Picture:=nil;
end;

end.
