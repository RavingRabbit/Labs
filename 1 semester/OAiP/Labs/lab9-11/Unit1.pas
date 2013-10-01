unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math, ExtCtrls, Buttons, Xpman, ComCtrls,
  TeEngine, Series, TeeProcs, Chart;

type
  TForm1 = class(TForm)
    btn2: TBitBtn;
    pgc1: TPageControl;
    ts1: TTabSheet;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    ts2: TTabSheet;
    img1: TImage;
    btn1: TButton;
    lbl4: TLabel;
    edt4: TEdit;
    lbl5: TLabel;
    lbl6: TLabel;
    lbl7: TLabel;
    lbl8: TLabel;
    edt5: TEdit;
    edt6: TEdit;
    edt7: TEdit;
    edt8: TEdit;
    lbl9: TLabel;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
type mas1=array[1..4] of Integer;
     mas2=array[1..6] of Extended;
var
  Form1: TForm1;
  xn,xk:Extended;
  xomin,xomax,yomin,yomax:extended;
  m,i,delt:integer;
  x,y:mas1; //массив координат
  d:mas2; //массив сторон и диагоналей 4-угольника
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  edt1.text:='1';
  edt2.text:='1';
  edt3.text:='2';
  edt4.text:='2';
  edt5.text:='0';
  edt6.text:='6';
  edt7.text:='2';
  edt8.text:='1';
end;

function max(x,y:mas1):Integer;    //находим максимальную координату
var max1,max2:Integer;
begin
  max1:=x[1];
  for i:=2 to 4 do begin
    if x[i]>max1 then max1:=x[i];
  end;
  max2:=y[1];
  for i:=2 to 4 do begin
    if y[i]>max2 then max2:=y[i];
  end;
  if max1>max2 then result:=max1 else result:=max2;
end;

function dlina(x,y:mas1):mas2; //найдём длинны сторон и диагоналей
begin
 //стороны
 d[1]:=sqrt(sqr(x[1]-x[2])+sqr(y[1]-y[2]));
 d[2]:=sqrt(sqr(x[2]-x[3])+sqr(y[2]-y[3]));
 d[3]:=sqrt(sqr(x[3]-x[4])+sqr(y[3]-y[4]));
 d[4]:=sqrt(sqr(x[1]-x[4])+sqr(y[1]-y[4]));
 //диагонали
 d[5]:=sqrt(sqr(x[1]-x[3])+sqr(y[1]-y[3]));
 d[6]:=sqrt(sqr(x[2]-x[4])+sqr(y[2]-y[4]));
 result:=d;
end;

function angles(x,y:mas1):boolean; //проверка на параллельность противоположных сторон
var ax,bx,cx,dx,ay,by,cy,dy,fi1,fi2:Extended;
begin
 //вектор первой стороны
 ax:=x[2]-x[1];
 ay:=y[2]-y[1];
 //вектор второй стороны
 bx:=x[3]-x[2];
 by:=y[3]-y[2];
 //вектор третьей стороны
 cx:=x[4]-x[3];
 cy:=y[4]-y[3];
 //и, наконец, четвёртой
 dx:=x[1]-x[4];
 dy:=y[1]-y[4];
 //найдём, равны ли косинусы углов единице
 fi1:=abs(ax*cx+ay*cy)/(Sqrt(Sqr(ax)+sqr(ay))*sqrt(Sqr(cx)+sqr(cy)));
 fi2:=abs(bx*dx+by*dy)/(Sqrt(Sqr(bx)+sqr(by))*sqrt(Sqr(dx)+sqr(dy)));
 //косинус параллельных = 1
 if (fi1=1) or (fi2=1) then result:=True else result:=False;
end;

procedure TForm1.btn1Click(Sender: TObject); //Image
var xmax,ymax,xo,yo:integer;
    n:Extended;
begin
 img1.Picture:=nil;
 x[1]:=StrToInt(edt1.Text);
 x[2]:=StrToInt(edt2.Text);
 x[3]:=StrToInt(edt3.Text);
 x[4]:=StrToInt(edt4.Text);
 y[1]:=StrToInt(edt5.Text);
 y[2]:=StrToInt(edt6.Text);
 y[3]:=StrToInt(edt7.Text);
 y[4]:=StrToInt(edt8.Text);
  //определим, какая перед нами фигурка
  dlina(x,y);
  begin
   if (d[5]=d[6]) and (d[1]=d[2]) and (d[1]=d[3]) and (d[1]=d[4]) then   //если (диагонали равны) and (стороны равны) — квадрат
    lbl9.Caption:='Квадрат'
   else
    if (d[1]=d[2]) and (d[1]=d[3]) and (d[1]=d[4]) then  //если только стороны равны — ромб
     lbl9.Caption:='Ромб'
    else
     if angles(x,y) then  //если какая-то пара противоположных сторон параллельна - трапеция
      lbl9.Caption:='Трапеция'
     else
      lbl9.Caption:='Произвольный четырёхугольник';
  end;
  //а теперь рисуем её
    xmax:=Img1.Width;
    ymax:=Img1.Height;
    xo:=xmax div 2;
    yo:=ymax div 2;
    img1.Canvas.Pen.Color:=clRed;
    img1.Canvas.Pen.Width:=3;
    n:=xmax div Max(x,y); //Масштабный коэффициент
    x[1]:=Round(x[1]*n);
    x[2]:=Round(x[2]*n);
    x[3]:=Round(x[3]*n);
    x[4]:=Round(x[4]*n);
    y[1]:=Round(y[1]*n);
    y[2]:=Round(y[2]*n);
    y[3]:=Round(y[3]*n);
    y[4]:=Round(y[4]*n);
    Img1.Canvas.Polygon([point(xmax-x[1],ymax-y[1]),point(xmax-x[2],ymax-y[2]),point(xmax-x[3],ymax-y[3]),point(xmax-x[4],ymax-y[4])]);
end;
end.
