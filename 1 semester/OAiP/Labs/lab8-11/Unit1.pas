unit Unit1;
interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons;
type
  TForm1 = class(TForm)
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    btn4: TButton;
    btn5: TButton;
    btn6: TBitBtn;
    lbl1: TLabel;
    lbl2: TLabel;
    lbl3: TLabel;
    lbl4: TLabel;
    edt1: TEdit;
    edt2: TEdit;
    edt3: TEdit;
    edt4: TEdit;
    mmo1: TMemo;
    dlgOpen1: TOpenDialog;
    dlgSave1: TSaveDialog;
    procedure FormCreate(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn4Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
Type
  TFlight = record
    N:Word;
    Plane:string[20];
    Dest:string[100];
    Time:word;
    end;
var
  Form1: TForm1;
  Fz:file of TFlight;  //Файл типа запись
  Ft:TextFile;    // Текстовой файл
  Flights:array[1..1000] of TFlight; // Массив записей
  nzap,k:word;    // Количетво запсей, количество отсортированных записей
  FileNameZ,FileNameT:string;  // Имя файл
  FlDest:array[1..1000] of TFlight; // Отсортированный массив, понадобится в сортировке и сохранении
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Clear; edt2.Clear; edt3.Clear; edt4.Clear;
mmo1.Clear;
btn5.Hide;
nzap:=0;
end;

procedure TForm1.btn5Click(Sender: TObject); //ввести запись
begin
inc(nzap);
with Flights[nzap] do begin
  N:=StrToInt(edt1.Text);
  Plane:=edt2.Text;
  Dest:=edt3.Text;
  Time:=StrToInt(edt4.Text);
  mmo1.Lines.Add('Номер '+inttostr(N)+' | Тип '+Plane+' | Пункт '+Dest+' | Время '+inttostr(time));
  end;
  Write(fz,Flights[nzap]);// Запись в файл
  edt1.Clear; edt2.Clear; edt3.Clear; edt4.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);  //создать
begin
 dlgSave1.Title :='Создать новый файл';
 if dlgSave1.Execute then  // Выполнение стандартного диалога
   begin
    FileNameZ:= dlgSave1.FileName;
    AssignFile(Fz, FileNameZ);     // Связывание файловой переменной Fz c именем файла
    Rewrite(Fz);
   end;
 btn5.show;
end;

procedure TForm1.btn2Click(Sender: TObject); //открыть
begin
  dlgOpen1.Title:='Открыть базу рейсов';
  if dlgOpen1.Execute then  // Выполнение стандартного диалога
   begin
    FileNameZ:= dlgOpen1.FileName;
    AssignFile(Fz, FileNameZ);
    Reset(Fz);
   end;
  nzap:=0;
  while not eof(fz) do begin
   inc(nzap);
   Read(fz,Flights[nzap]);                // Чтение записи из файла
   with Flights[nzap] do
    mmo1.Lines.Add('Номер '+inttostr(N)+' | Тип '+Plane+' | Пункт '+Dest+' | Время '+inttostr(time));
  end;
  Btn1.Show;
end;

procedure TForm1.btn3Click(Sender: TObject);  //сортировка
var i,j:word;
    pl:TFlight; //буфер обмена при сортировки записей
    destin:string; //пункт назначения
begin
 destin:=edt3.text;
 if not(destin='') then //проферка, чтобы поле "пункт назначения" не было пустым
  begin
   Mmo1.Clear;
   //выделим массив рейсов с нужным пунктом назначения
   k:=1;
   for i:=1 to nzap do
    if Flights[i].Dest=destin then
     begin
      FlDest[k]:=Flights[i];
      inc(k);
     end;
   //отсортируем по времени
   for i:=1 to k-2 do
    for j:=i+1 to k-1 do
     if FlDest[i].time > FlDest[j].time then
      begin
       pl:=FlDest[i];
       FlDest[i]:=FlDest[j];
       FlDest[j]:=pl;
      end;
   for i:=1 to k-1 do
    with FlDest[i] do
     mmo1.Lines.Add('Номер '+inttostr(N)+' | Тип '+Plane+' | Пункт '+Dest+' | Время '+inttostr(time));
     edt3.Color:=clWhite;
      end
 else begin ShowMessage('Введите пункт назначения, относительно которого будет производиться сортировка'); edt3.Color:=clRed; end;
end;

procedure TForm1.btn4Click(Sender: TObject); //сохранить сортировки в txt
var i:word;
begin
 dlgSave1.Title:='Сохранить результат сортировки';
 if dlgSave1.Execute then
  begin
   FileNameT:=DlgSave1.FileName;
   AssignFile(Ft,FileNameT);
   Rewrite(Ft);
  end;
 for i:=1 to k-1 do
  with Fldest[i] do
   Writeln(Ft,'Номер рейса: ',n,' | Тип самолёта: ',plane,' | Пункт назначения: ',Dest,' | Время вылета: ',time); 
CloseFile(Ft);
end;
end.

