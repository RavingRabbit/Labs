unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, Unit2, XPman, Buttons, StdCtrls, ComCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    tv1: TTreeView;
    btn1: TBitBtn;
    btn2: TSpeedButton;
    btn3: TBitBtn;
    btn4: TSpeedButton;
    btn5: TBitBtn;
    mmo1: TMemo;
    btn6: TBitBtn;
    btn7: TBitBtn;
    btn8: TButton;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    btn9: TButton;
    shp1: TShape;
    lbl1: TLabel;
    edt4: TEdit;
    lbl2: TLabel;
    lbl3: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure btn7Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
    procedure btn9Click(Sender: TObject);
    procedure edt4Change(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
var

  Form1: TForm1;
  Tree:Class_tree;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Tree:=Class_tree.Create;
  strngrd1.Cells[0,0]:='Flight number';
  strngrd1.Cells[1,0]:='Destination';
  Tree.N_flights:=strngrd1.RowCount-1;
  LoadKeyboardLayout('00000409', KLF_ACTIVATE);
end;

procedure TForm1.btn2Click(Sender: TObject);  //add row (+)
begin
  Inc(Tree.N_flights);
  strngrd1.RowCount:=Tree.N_flights+1;
  if (Tree.N_flights<12) and (Tree.N_flights>4) then begin
    strngrd1.height:=strngrd1.height+25;
    tv1.height:=tv1.height+25;
    mmo1.Height:=mmo1.Height+25;
    btn1.Top:=btn1.Top+25;
    btn3.Top:=btn3.Top+25;
    btn5.Top:=btn5.Top+25;
    btn6.Top:=btn6.Top+25;
    edt1.Top:=edt1.Top+25;
    edt2.Top:=edt2.Top+25;
    edt3.Top:=edt3.Top+25;
    btn8.Top:=btn8.Top+25;
    btn9.Top:=btn9.Top+25;
    shp1.Top:=shp1.Top+25;
    lbl1.Top:=lbl1.Top+25;
    lbl2.Top:=lbl2.Top+25;
    lbl3.Top:=lbl3.Top+25;
    edt4.Top:=edt4.Top+25;
    ClientHeight:=clientheight+25
  end;
end;

procedure TForm1.btn4Click(Sender: TObject);  //delete row (-)
begin
  dec(Tree.N_flights);
  strngrd1.RowCount:=Tree.N_flights+1;
  if (Tree.N_flights<11) and (Tree.N_flights>3)  then begin
  strngrd1.height:=strngrd1.height-25;
  tv1.height:=tv1.height-25;
  mmo1.Height:=mmo1.Height-25;
  btn1.Top:=btn1.Top-25;
  btn3.Top:=btn3.Top-25;
  btn5.Top:=btn5.Top-25;
  btn6.Top:=btn6.Top-25;
  edt1.Top:=edt1.Top-25;
  edt2.Top:=edt2.Top-25;
  edt3.Top:=edt3.Top-25;
  btn8.Top:=btn8.Top-25;
  btn9.Top:=btn9.Top-25;
  shp1.Top:=shp1.Top-25;
  lbl1.Top:=lbl1.Top-25;
  lbl2.Top:=lbl2.Top-25;
  lbl3.Top:=lbl3.Top-25;
  edt4.Top:=edt4.Top-25;
  ClientHeight:=clientheight-25;
  end;
end;

procedure TForm1.btn1Click(Sender: TObject); //Enter tree
begin
  tree.read_spreadsheet(strngrd1);
  btn3.Enabled:=True;
  btn5.Enabled:=True;
  btn6.Enabled:=True;
  btn8.Enabled:=True;
  btn9.Enabled:=True;
  edt4.Enabled:=True;
end;

procedure TForm1.btn3Click(Sender: TObject); //Display tree
var kl:integer;
begin
  kl:=-1;
  tv1.Items.Clear;
  Tree.display_tree(Tree.tree,kl,tv1);
  tv1.fullexpand;
end;

procedure TForm1.btn5Click(Sender: TObject); //Delete tree
begin
  Tree.delete_tree(tree.tree);
  tv1.Items.Clear;
  mmo1.Clear;
  btn3.Enabled:=False;
  btn5.Enabled:=False;
  btn6.Enabled:=False;
  btn8.Enabled:=False;
  btn9.Enabled:=False;
  edt4.Enabled:=False;
end;

procedure TForm1.btn6Click(Sender: TObject); //Display tree (memo)
begin
  mmo1.Clear;
  Tree.display_tree_memo(tree.tree,mmo1);
end;

procedure TForm1.btn7Click(Sender: TObject); //fill in
var i:word;
begin
  Randomize;
  for i:=1 to Tree.N_flights do
    begin
      Form1.strngrd1.Cells[0,i]:=inttostr(Random(20));
      Form1.strngrd1.Cells[1,i]:=chr(97+Random(10))+chr(97+Random(10))+chr(97+Random(10));
    end;
end;

procedure TForm1.btn8Click(Sender: TObject); //Find
begin
  edt2.Text:=tree.find(StrToInt(edt1.text));
end;

procedure TForm1.btn9Click(Sender: TObject); //Delete
var kl:integer;
begin
  tree.delete_sheet(strtoint(edt3.text));
  //print
  kl:=-1;
  tv1.Items.Clear;
  Tree.display_tree(Tree.tree,kl,tv1);
  tv1.fullexpand;
end;

procedure TForm1.edt4Change(Sender: TObject);
var N:integer;
begin
  N:=0;
  tree.count(tree.tree,edt4.Text[1],N);
  lbl3.caption:=inttostr(N);
end;

end.
