unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, XPman, Unit2;

type
  TForm1 = class(TForm)
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    btn4: TButton;
    btn5: TButton;
    btn6: TButton;
    btn7: TButton;
    btn8: TButton;
    btn9: TButton;
    btn10: TButton;
    btn11: TButton;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    edt4: TEdit;
    edt5: TEdit;
    lst1: TListBox;
    lst2: TListBox;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    lbl4: TLabel;
    shp1: TShape;
    shp2: TShape;
    shp3: TShape;
    shp4: TShape;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure btn7Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
    procedure btn9Click(Sender: TObject);
    procedure btn10Click(Sender: TObject);
    procedure btn11Click(Sender: TObject);

  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  List,Random_list:TList;
  b:boolean;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  List:=TList.Create;
end;

procedure TForm1.btn1Click(Sender: TObject);  //Add1
begin
  List.Add1(StrToInt(edt1.Text));
  lst1.Clear;
  List.Print1(lst1);
end;

procedure TForm1.btn2Click(Sender: TObject);  //Addk
begin
  List.Addk(StrToInt(edt1.Text));
  lst1.Clear;
  List.Print1(lst1);
end;

procedure TForm1.btn3Click(Sender: TObject); //AddBefore
var x,y:integer;
begin
  try
    x:=StrToInt(edt2.Text);
    y:=StrToInt(edt3.Text);
  except end;
  List.Size;
  List.AddBefore(y,x);
  lst1.clear;
  List.Print1(lst1);
end;

procedure TForm1.btn4Click(Sender: TObject);  //AddAfter
var x,y:integer;
begin
  try
  x:=StrToInt(edt2.Text);
  y:=StrToInt(edt3.Text);
  except end;
  List.Size;
  List.AddAfter(y,x);
  lst1.Clear;
  List.Print1(lst1);
end;

procedure TForm1.btn5Click(Sender: TObject); //Read1
var x:integer;
begin
  edt4.Clear;
  with List do
    begin
      Read1(x);
      if b1 then
      edt4.text:=IntToStr(x);
    end;
    lst1.clear;
  List.Print1(lst1);
end;

procedure TForm1.btn6Click(Sender: TObject); //Readk
var x:integer;
begin
  edt4.Clear;
  with List do
    begin
      Readk(x);
      if bk then
      edt4.text:=IntToStr(x);
    end;
  lst1.clear;
  List.Print1(lst1);
end;

procedure TForm1.btn7Click(Sender: TObject);  //Print1
begin
  lst1.clear;
  List.Print1(lst1);
end;

procedure TForm1.btn8Click(Sender: TObject);  //Printk
begin
  lst1.clear;
  List.Printk(lst1);
end;

procedure TForm1.btn9Click(Sender: TObject);  //Sort
begin
  SortSlip(List);
  lst1.clear;
  List.Print1(lst1);
end;

procedure TForm1.btn10Click(Sender: TObject);  //Random_list
var i,N:integer;
begin
  Random_list:=TList.Create;
  lst2.clear;
  N:=StrToInt(edt5.Text);
  Randomize;
  for i:=1 to N do Random_list.Add1(Random(10));
  Random_list.Print1(lst2);
  btn11.enabled:=True;
end;

procedure TForm1.btn11Click(Sender: TObject); //Delete_identical
begin
  lst2.clear;
  Random_list.Delete_identical(strtoint(edt5.text));
  Random_list.Print1(lst2);
  btn11.enabled:=False;
end;

end.
