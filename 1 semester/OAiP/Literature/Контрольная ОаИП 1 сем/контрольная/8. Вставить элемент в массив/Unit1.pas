unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, Unit2, XPMan;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    strngrd2: TStringGrid;
    edt1: TEdit;
    btn1: TButton;
    edt2: TEdit;
    btn2: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Text:='5';
edt2.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
  strngrd1.ColCount:=strtoint(edt1.text);
end;

procedure TForm1.btn2Click(Sender: TObject);
var A:Tmas; c,N,i:integer;
begin
   c:=strtoint(edt2.Text);
   N:=strtoint(edt1.text);
   strngrd2.colcount:=N+1;
   getmem(A,sizeof(integer)*(N+2));
   for i:=0 to N-1 do
     A[i]:=strtoint(strngrd1.cells[i,0]);
   insert(A,N,c);
   for i:=0 to N do
   strngrd2.Cells[i,0]:=inttostr(A[i]);
   freemem(A,sizeof(integer)*(N+2));
end;

end.
