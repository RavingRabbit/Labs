unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2, XPMan;

type
  TForm1 = class(TForm)
    strngrd1: TStringGrid;
    strngrd2: TStringGrid;
    btn1: TButton;
    edt1: TEdit;
    btn2: TButton;
    procedure btn1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
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

procedure TForm1.btn1Click(Sender: TObject);
var A:Tmas; i,N,n1:integer;
begin
 N:=strtoint(edt1.text);
 getmem(A,N*sizeof(integer));
 for i:=0 to N-1 do
  A[i]:=strtoint(strngrd1.Cells[i,0]);
 del(A,n,n1);
 strngrd2.ColCount:=n1;
 for i:=0 to n1-1 do
  strngrd2.cells[i,0]:=inttostr(A[i]);
 freemem(A,N*sizeof(integer));
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.text:='5';
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
strngrd1.colcount:=strtoint(edt1.text);
end;

end.
