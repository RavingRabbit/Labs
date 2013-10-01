unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, xpman, unit2, Menus;
type
  TForm1 = class(TForm)
    btn3: TButton;
    btn5: TButton;
    btn6: TBitBtn;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    mmo1: TMemo;
    dlgOpen1: TOpenDialog;
    dlgSave1: TSaveDialog;
    btn8: TButton;
    mm1: TMainMenu;
    N1: TMenuItem;
    N2: TMenuItem;
    N3: TMenuItem;
    cbb1: TComboBox;
    btn1: TButton;
    btn2: TButton;
    procedure FormCreate(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
    procedure N1Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  Vedomosti:Vedomost;
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
  Vedomosti:=Vedomost.Create;
  edt1.Clear; edt2.Clear; edt3.Clear; mmo1.Clear;
  btn5.Hide; btn8.Hide; btn1.Hide; btn3.Hide; cbb1.Hide; btn2.hide;
  Vedomosti.N_zap:=0;

end;

procedure TForm1.btn5Click(Sender: TObject); //ввести запись
begin
  try
    Vedomosti.add_zap(edt1.text, edt2.text, edt3.text);
    edt1.Clear; edt2.Clear; edt3.Clear;
    mmo1.Lines.Add('ФИО: '+vedomosti.arr[Vedomosti.N_zap].FIO+' | Адрес: '+vedomosti.arr[Vedomosti.N_zap].Address+' | Средний балл: '+floattostr(vedomosti.arr[Vedomosti.N_zap].Avrg_mark));
    except ShowMessage('заполните все поля') end;
end;

procedure TForm1.btn8Click(Sender: TObject); //удалить по фио
begin
  Vedomosti.delete_abiturien(edt1.text,mmo1);
end;

procedure TForm1.N1Click(Sender: TObject);
begin
  mmo1.clear;
  dlgSave1.Title:='Создать новый файл';
  if dlgSave1.Execute then
    begin
      AssignFile(Vedomosti.File_zap, dlgSave1.FileName);
      Rewrite(Vedomosti.File_zap);
      btn5.show; btn8.Show; btn1.Show; btn3.Show; cbb1.Show; btn2.Show;
    end;
end;

procedure TForm1.N2Click(Sender: TObject);
var i:Word;
begin
  mmo1.clear;
  with Vedomosti do begin
    read_file(dlgOpen1);
    for i:=1 to N_zap do
      mmo1.Lines.Add('ФИО: '+arr[i].FIO+' | Адрес: '+arr[i].Address+' | Средний балл: '+floattostr(arr[i].Avrg_mark));
  end;
  Btn5.Show; btn8.Show; btn1.Show; btn3.Show; cbb1.Show; btn2.Show;
end;

procedure TForm1.N3Click(Sender: TObject);
begin
  Vedomosti.save_file(mmo1, dlgSave1);
end;

procedure TForm1.btn1Click(Sender: TObject);
var i:Word;
begin
  mmo1.clear;
  with Vedomosti do begin
    i:=find(edt1.text);
    if find(edt1.text)=N_zap+1 then showmessage('Элемент не найден')
    else mmo1.Lines.add('ФИО: '+arr[i].FIO+' | Адрес: '+arr[i].Address+' | Средний балл: '+floattostr(arr[i].Avrg_mark));
  end;
end;

procedure TForm1.btn3Click(Sender: TObject);
var i:Word;
begin
  mmo1.clear;
  case cbb1.ItemIndex of
    0: Vedomosti.sortirovka_sli(1,Vedomosti.N_zap);
    1: Vedomosti.sortirovka_QuickSort;
    else Vedomosti.sortirovka_sli(1,Vedomosti.N_zap);
  end;
  with Vedomosti do
    for i:=1 to N_zap do mmo1.Lines.add('ФИО: '+arr[i].FIO+' | Адрес: '+arr[i].Address+' | Средний балл: '+floattostr(arr[i].Avrg_mark));
end;

procedure TForm1.btn2Click(Sender: TObject);
begin
  Vedomosti.Binary_Search(strtofloat(edt3.text), mmo1);
end;

end.


