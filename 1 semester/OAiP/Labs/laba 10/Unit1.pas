unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Unit2, Clipbrd, Buttons, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    img1: TImage;
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    btn4: TButton;
    btn5: TButton;
    btn6: TButton;
    btn7: TButton;
    btn8: TButton;
    btn9: TBitBtn;
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure btn7Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

var krug:Tkrug;
    kvad:Tkvad;
    krpr:Tkrpr;
    okno1:Timage; // Введена переменная для сохранения записи
    pxm1,pym1, xo,yo,ro:word; 



procedure TForm1.btn1Click(Sender: TObject);
begin
okno1:=Form1.Img1;
colrBack:=clWhite;          // Цвет фона – белый 
pxm1:=okno1.ClientWidth;         // Считывание размеров окна 
pym1:=okno1.ClientHeight; 
with okno1.canvas do begin 
pen.color:=colrBack; 
brush.color:=colrBack; 
Rectangle(0,0,Pxm1,Pym1);   // Заливка всего окна цветом фона 
                                      end; 
xo:=pxm1 div 2;   yo:=pym1 div 2;  // Вычисление координат центра окна 
ro:=10;    // Начальный размер круга и прямоугольника 
 Krug:=Tkrug.Create(xo,yo,ro,clBlack,okno1.canvas); // Цвет – черный 
 Kvad:=Tkvad.Create(xo+80,yo,ro,clBlack,okno1.canvas);  
 Krpr:=Tkrpr.Create(xo-80,yo,ro,2*ro,clBlack,okno1.canvas);
 krug.Show; // Рисование круга 
kvad.Show; // Рисование квадрата
Krpr.show; // Рисование комбинации круга и квадрата 
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
Krug.MovTo(0,0,3); 
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
Krug.MovTo(0,0,-3); 
end;

procedure TForm1.btn4Click(Sender: TObject);
begin
Kvad.MovTo(3,3,0); 
end;

procedure TForm1.btn5Click(Sender: TObject);
begin
Kvad.MovTo(-3,-3,0); 
end;

procedure TForm1.btn6Click(Sender: TObject);
begin
krpr.MovTo(10,0,0);    
okno1.Update;  // Прорисовка окна 
sleep(200);  // Задержка
krpr.MovTo(0,5,0); 
end;

procedure TForm1.btn7Click(Sender: TObject);
begin
krpr.MovTo(-10,0,0); 
okno1.Update;    
  sleep(200);
krpr.MovTo(0,-5,0); 
end;

procedure TForm1.btn8Click(Sender: TObject);
begin
Clipboard.Assign(Img1.Picture);
end;

end.
