unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Math, ExtCtrls, Buttons, Xpman, ComCtrls,
  TeEngine, Series, TeeProcs, Chart, Clipbrd;

type
  TForm1 = class(TForm)
    btn2: TBitBtn;
    pgc1: TPageControl;
    ts1: TTabSheet;
    ts3: TTabSheet;
    cht1: TChart;
    YSeries1: TLineSeries;
    lbl4: TLabel;
    lbl5: TLabel;
    lbl6: TLabel;
    lbl7: TLabel;
    lbl8: TLabel;
    edt4: TEdit;
    edt5: TEdit;
    edt6: TEdit;
    edt7: TEdit;
    btn3: TButton;
    pb1: TProgressBar;
    lbl1: TLabel;
    edt1: TEdit;
    lbl2: TLabel;
    edt2: TEdit;
    lbl3: TLabel;
    edt3: TEdit;
    img1: TImage;
    btn1: TButton;
    btn4: TButton;
    btn5: TButton;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  xn,xk:Extended;
  xomin,xomax,yomin,yomax:extended;
  m,i,delt:integer;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  edt1.text:='-5';
  edt2.text:='5';
  edt3.text:='150';
  edt4.text:='-5';
  edt5.text:='5';
  edt6.text:='-3';
  edt7.text:='10';
end;

function fun(x:Extended):Extended;
var y:Extended;
begin
 y:=(1-sqr(x)/2)*cos(x)-(x/2)*sin(x);
 Result:=y;
end;

procedure TForm1.btn1Click(Sender: TObject); //Image
var xmax,ymax,xo,yo,po:integer;
    hx,hy,x,h,y:Extended;
begin
  po:=30;
  img1.Picture:=nil;
  try
    xn:=StrToFloat(edt1.Text);
    xk:=StrToFloat(edt2.Text);
    xomin:=StrToFloat(edt4.Text);
    xomax:=StrToFloat(edt5.Text);
    yomin:=StrToFloat(edt6.Text);
    yomax:=StrToFloat(edt7.Text);
  except
    on EConvertError do showmessage('Заполните поля числовыми значениями');
  end;
  try
    m:=StrToInt(edt3.Text);
  except
    on EConvertError do MessageDlg('M — целое число',mtWarning,mbOKcancel,1);
  end;
  with Img1.Canvas do begin
    Pen.Color:=clBlack;
    xmax:=Img1.Width-2*po;
    ymax:=Img1.Height-2*po;
    //Строим оси координат
    yo:=ymax div 2;
    xo:=xmax div 2;
    MoveTo(po+0,po+yo); LineTo(po+xmax,po+yo);
    MoveTo(po+0,po+0); LineTo(po+0,po+ymax);
    Font.Size:=12;
    Textout(po div 4,yo+po,'0');
    Textout(po div 4,po,FloatToStr(yomax));
    Textout(po div 4,ymax-po,FloatToStr(yomin));
    Pen.Color:=clRed;
    Pen.Width:=2;
    hx:=(xomax-xomin)/xmax; //Масштабные коэффициенты, устанавливающие шаг
    hy:=(yomax-yomin)/ymax;
    //Вывод графика
    h:=(xk-xn)/(m-1);
    x:=xn;
    y:=fun(x);     // Первая точка
    MoveTo(po+Round(xo-x/hx),po+Round(yo-y/hy));
    for i:=1 to m do begin
      pb1.Position:=Round(100*i/m);
      x:=x+h;
      y:=fun(x);
      LineTo(po+Round(xo-x/hx),po+Round(yo-y/hy));
    end;
  end;
end;

procedure TForm1.btn3Click(Sender: TObject); //Chart
var x,h,y:Extended;
begin
  try
    xn:=StrToFloat(edt1.Text);
    xk:=StrToFloat(edt2.Text);
    xomin:=StrToFloat(edt4.Text);
    xomax:=StrToFloat(edt5.Text);
    yomin:=StrToFloat(edt6.Text);
    yomax:=StrToFloat(edt7.Text);
  except
    on EConvertError do showmessage('Заполните поля числовыми значениями');
  end;
  try
    m:=StrToInt(edt3.Text);
  except
    on EConvertError do MessageDlg('M — целое число',mtWarning,mbOKcancel,1);
  end;
  with Cht1 do begin
    LeftAxis.Automatic:=False;
    LeftAxis.Minimum:=yomin;
    LeftAxis.Maximum:=yomax;
    BottomAxis.Automatic:=False;
    BottomAxis.Minimum:=xomin;
    BottomAxis.Maximum:=xomax;
    SeriesList[0].Clear;
    h:=(xk-xn)/(m-1);     x:=xn;
    for i:=1 to m do begin
      pb1.Position:=Round(100*i/m);
      y:=fun(x);
      SeriesList[0].AddXY(x,y);
      x:=x+h;
    end;
  end;
end;
procedure TForm1.btn4Click(Sender: TObject);
begin
Cht1.CopyToClipboardMetafile(True);
end;

procedure TForm1.btn5Click(Sender: TObject);
begin
Clipboard.Assign(Img1.Picture);
end;

end.
