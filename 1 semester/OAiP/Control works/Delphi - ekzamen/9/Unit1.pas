unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Label1: TLabel;
    Edit1: TEdit;
    Label2: TLabel;
    Edit2: TEdit;
    Memo1: TMemo;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  zad:Tzad;
  i,n0,wmax0:integer;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
   stringgrid1.Cells[1,0]:='Вес';
   stringgrid1.Cells[2,0]:='Цена';
   n0:=10;
   edit1.Text:=inttostr(n0);
   wmax0:=40;
   edit2.text:=inttostr(wmax0);
   memo1.Clear;
   randomize;
   for i:=1 to n0 do
   begin
      stringgrid1.Cells[0,i]:=inttostr(i);
      stringgrid1.Cells[1,i]:=inttostr(1+random(20));
      stringgrid1.Cells[2,i]:=inttostr(1+random(30));
   end;



end;

procedure TForm1.Button1Click(Sender: TObject);
begin
   zad:=Tzad.Create;
   n0:=strtoint(edit1.text);
   wmax0:=strtoint(edit2.Text);
   with zad do
   begin
      n:=n0;
      wmax:=wmax0;
      for i:=1 to n do
      begin
         a[i].w:=strtoint(stringgrid1.Cells[1,i]);
         a[i].c:=strtoint(stringgrid1.Cells[2,i]);
      end;
      minw;
      memo1.Lines.Add('Результаты метода полного перебора.');
      memo1.Lines.Add('Номер  Вес   Цена');
      for i:=1 to n do
        if i in sopt then
            memo1.Lines.Add(inttostr(i)+'            '+inttostr(a[i].w)
              +'      '+inttostr(a[i].c));
      memo1.Lines.Add('Макс вес = '+inttostr(wmax)
         +' Макс цена = '+inttostr(cmax));
   end;



end;

end.
