unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Edit1: TEdit;
    Label1: TLabel;
    Edit2: TEdit;
    Label2: TLabel;
    BitBtn1: TBitBtn;
    procedure FormCreate(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var i :word; ch:char;
begin
   edit1.text:='ab*c-d+';
   edit2.Clear;
   stringgrid1.Cells[0,0]:='Переменная';
   stringgrid1.Cells[1,0]:='Значение';
   ch:='a';
   randomize;
   for i:=1 to stringgrid1.RowCount-1 do
   begin
      stringgrid1.Cells[0,i]:=ch;
      inc(ch);
      stringgrid1.Cells[1,i]:=inttostr(1+random(10));
   end;


end;

procedure TForm1.BitBtn1Click(Sender: TObject);
var i:word;
begin
   zad:=Tzad.Create;
   for i:=1 to stringgrid1.RowCount-1 do
      zad.zn[stringgrid1.Cells[0,i][1]]:=strtofloat(stringgrid1.Cells[1,i]);
   edit2.Text:=floattostr(zad.AV(edit1.Text));
   zad.Free;
end;

end.
