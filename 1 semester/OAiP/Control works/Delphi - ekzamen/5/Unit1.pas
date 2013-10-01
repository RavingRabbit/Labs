unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Grids, unit2;

type
  TForm1 = class(TForm)
    StringGrid1: TStringGrid;
    Memo1: TMemo;
    Button1: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
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
  i,n0,wmax0:Integer;

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
var oct0:integer;
begin
   zad:=Tzad.Create;
   wmax0:=strtoint(edit2.Text);
   n0:=strtoint(edit1.Text);
   with zad do
   begin
      n:=n0;
      wmax:=wmax0;
      oct0:=0;
      for i:=1 to n do
      begin
         a[i].w:=strtoint(stringgrid1.Cells[1,i]);
         a[i].c:=strtoint(stringgrid1.Cells[2,i]);
         oct0:=oct0+a[i].c;
      end;
      cmax:=0;
      s:=[];
      sopt:=[];
      vg(1,0,oct0);

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
