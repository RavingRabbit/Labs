unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    StringGrid2: TStringGrid;
    Button1: TButton;
    Button2: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  i,n:word;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var j:word;
begin
   n:=10;
   edit1.Text:=inttostr(n);
   stringgrid1.RowCount:=n+1;
   stringgrid1.Cells[0,0]:='Фамилия';
   stringgrid1.Cells[1,0]:='Ключ';
   stringgrid2.Cells[0,0]:='Фамилия';
   stringgrid2.Cells[1,0]:='Ключ';
   randomize;
   for i:=1 to n do
   begin
      j:=1+random(100);
      stringgrid1.Cells[1,i]:=inttostr(j);
      stringgrid1.Cells[0,i]:=chr(j)+chr(j+50)+chr(j+100);
   end;


end;

procedure TForm1.Button1Click(Sender: TObject);
var inf:Tinf;
begin
   zad:=Tzad.create;
   n:=strtoint(edit1.text);
   stringgrid1.RowCount:=n+1;
   for i:=1 to n do
   begin
      inf.f:=stringgrid1.Cells[0,i];
      inf.k:=strtoint(stringgrid1.Cells[1,i]);
      zad.addb(inf);
   end;

end;

procedure TForm1.Button2Click(Sender: TObject);
begin
   zad.wrt1b(Stringgrid2);
   zad.free;
end;

end.
