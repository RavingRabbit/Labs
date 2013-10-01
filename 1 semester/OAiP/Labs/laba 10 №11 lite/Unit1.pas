unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, Clipbrd, Buttons, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    img1: TImage;
    btn1: TButton;
    btn8: TButton;
    btn9: TBitBtn;
    btn2: TButton;
    btn3: TButton;
    procedure btn1Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  i,k:integer;
implementation

{$R *.dfm}

var
 TrPr:TTrPr;
 okno:Tkvad;
 dver:Tkvad;
 okno1:Timage; // Введена переменная для сохранения записи
 pxm1,pym1,xo,yo:word;



procedure TForm1.btn1Click(Sender: TObject);
begin
 okno1:=Form1.Img1;
 colrBack:=clGradientActiveCaption;          // Цвет фона – белый
 pxm1:=okno1.ClientWidth;         // Считывание размеров окна
 pym1:=okno1.ClientHeight;
 with okno1.canvas do begin
  pen.color:=colrBack;
  brush.color:=colrBack;
  Rectangle(0,0,Pxm1,Pym1);   // Заливка всего окна цветом фона
 end;
 xo:=pxm1 div 2;   yo:=pym1 div 2;  // Вычисление координат центра окна
 TrPr:=TTrPr.Create(xo,yo,70,70,clblack,okno1.canvas);
 TrPr.show; // Рисование дома(комбинации круга и квадрата)
 okno:=Tkvad.create(xo,yo+20,20,20,clwhite,okno1.canvas);
 okno.show;
 dver:=Tkvad.create(xo+50,yo+75,13,30,clOlive,okno1.canvas);
 dver.show;
end;



procedure TForm1.btn8Click(Sender: TObject);
begin
 Clipboard.Assign(Img1.Picture);
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
 inc(i);
 if odd(i) then
 Dver.MovTo(27,0,0)
 else
 begin
 dver.hide;
 TrPr:=TTrPr.Create(xo,yo,70,70,clblack,okno1.canvas);
 TrPr.show; // Рисование дома(комбинации круга и квадрата)
 dver:=Tkvad.create(xo+50,yo+75,13,30,clOlive,okno1.canvas);
 dver.show;
 if odd(k) then  begin
 okno:=Tkvad.create(xo,yo+20,20,20,clwhite,okno1.canvas);
 okno.show;
 okno:=Tkvad.create(xo,yo+20,20,15,clgray,okno1.canvas);
 okno.show end
 else
 okno:=Tkvad.create(xo,yo+20,20,20,clwhite,okno1.canvas);
 okno.show
 end;
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
 inc(k);
 if odd(k) then begin
 okno:=Tkvad.create(xo,yo+20,20,15,clgray,okno1.canvas);
 okno.show end
 else begin
 okno:=Tkvad.create(xo,yo+20,20,20,clwhite,okno1.canvas);
 okno.show
 end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
i:=0;
k:=0;
end;

end.
