unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Unit2;

type
  TForm1 = class(TForm)
    LabeledEdit1: TLabeledEdit;
    Memo1: TMemo;
    Button1: TButton;
    Button2: TButton;
    Memo2: TMemo;
    Button3: TButton;
    RadioGroup1: TRadioGroup;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    LabeledEdit2: TLabeledEdit;
    Memo3: TMemo;
    Button8: TButton;
    procedure Button2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Stak:TStak;

implementation

{$R *.dfm}

procedure TForm1.Button2Click(Sender: TObject);
var x:integer;
begin
  x:=StrToInt(LabeledEdit1.Text);
  Stak.Adds(x);
  LabeledEdit1.Clear;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Memo1.Clear;
  Stak:=TStak.Create;
  Memo2.Clear;
  Memo3.Clear;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  Memo1.Clear;
  with Stak do
    begin
      Min;
      Memo1.Lines.Add('Минимальный элемент: '+IntToStr(r));
      KolDoMin(r);
      Memo1.Lines.Add('Количество элементов до минимального: '+IntToStr(s));
    end;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
  Memo2.Clear;
  Stak.Print(Memo2);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  Memo2.Clear;
  case RadioGroup1.ItemIndex of
    0:Stak.SortBublAfter;
    1:Stak.SortBublInf;
  end;
  Stak.Print(Memo2);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  Memo1.Clear;
  with Stak do
    begin
      SrAr;
      Memo1.Lines.Add('Среднее арифметическое стека: '+FloatToStr(sa));
    end;
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  Memo1.Clear;
  with Stak do
    begin
      SrAr;
      SKR(sa,N);
      Memo1.Lines.Add('Среднеквадратичное отклонение: '+FloatToStr(sk));
    end;
end;

procedure TForm1.Button7Click(Sender: TObject);
var N,i:integer;
begin
  N:=StrToInt(LabeledEdit2.Text);
  Randomize;
  for i:=1 to N do
    Stak.Adds(Random(20));
end;

procedure TForm1.Button8Click(Sender: TObject);
var b:integer;
begin
  Memo3.Clear;
  with Stak do
    begin
      Reads(b);
      Memo3.Lines.Add(IntToStr(b));
      Print(Memo2);
    end;
end;

end.
