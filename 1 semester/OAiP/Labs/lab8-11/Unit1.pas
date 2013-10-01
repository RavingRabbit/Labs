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
  Fz:file of TFlight;  //���� ���� ������
  Ft:TextFile;    // ��������� ����
  Flights:array[1..1000] of TFlight; // ������ �������
  nzap,k:word;    // ��������� ������, ���������� ��������������� �������
  FileNameZ,FileNameT:string;  // ��� ����
  FlDest:array[1..1000] of TFlight; // ��������������� ������, ����������� � ���������� � ����������
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
begin
edt1.Clear; edt2.Clear; edt3.Clear; edt4.Clear;
mmo1.Clear;
btn5.Hide;
nzap:=0;
end;

procedure TForm1.btn5Click(Sender: TObject); //������ ������
begin
inc(nzap);
with Flights[nzap] do begin
  N:=StrToInt(edt1.Text);
  Plane:=edt2.Text;
  Dest:=edt3.Text;
  Time:=StrToInt(edt4.Text);
  mmo1.Lines.Add('����� '+inttostr(N)+' | ��� '+Plane+' | ����� '+Dest+' | ����� '+inttostr(time));
  end;
  Write(fz,Flights[nzap]);// ������ � ����
  edt1.Clear; edt2.Clear; edt3.Clear; edt4.Clear;
end;

procedure TForm1.btn1Click(Sender: TObject);  //�������
begin
 dlgSave1.Title :='������� ����� ����';
 if dlgSave1.Execute then  // ���������� ������������ �������
   begin
    FileNameZ:= dlgSave1.FileName;
    AssignFile(Fz, FileNameZ);     // ���������� �������� ���������� Fz c ������ �����
    Rewrite(Fz);
   end;
 btn5.show;
end;

procedure TForm1.btn2Click(Sender: TObject); //�������
begin
  dlgOpen1.Title:='������� ���� ������';
  if dlgOpen1.Execute then  // ���������� ������������ �������
   begin
    FileNameZ:= dlgOpen1.FileName;
    AssignFile(Fz, FileNameZ);
    Reset(Fz);
   end;
  nzap:=0;
  while not eof(fz) do begin
   inc(nzap);
   Read(fz,Flights[nzap]);                // ������ ������ �� �����
   with Flights[nzap] do
    mmo1.Lines.Add('����� '+inttostr(N)+' | ��� '+Plane+' | ����� '+Dest+' | ����� '+inttostr(time));
  end;
  Btn1.Show;
end;

procedure TForm1.btn3Click(Sender: TObject);  //����������
var i,j:word;
    pl:TFlight; //����� ������ ��� ���������� �������
    destin:string; //����� ����������
begin
 destin:=edt3.text;
 if not(destin='') then //��������, ����� ���� "����� ����������" �� ���� ������
  begin
   Mmo1.Clear;
   //������� ������ ������ � ������ ������� ����������
   k:=1;
   for i:=1 to nzap do
    if Flights[i].Dest=destin then
     begin
      FlDest[k]:=Flights[i];
      inc(k);
     end;
   //����������� �� �������
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
     mmo1.Lines.Add('����� '+inttostr(N)+' | ��� '+Plane+' | ����� '+Dest+' | ����� '+inttostr(time));
     edt3.Color:=clWhite;
      end
 else begin ShowMessage('������� ����� ����������, ������������ �������� ����� ������������� ����������'); edt3.Color:=clRed; end;
end;

procedure TForm1.btn4Click(Sender: TObject); //��������� ���������� � txt
var i:word;
begin
 dlgSave1.Title:='��������� ��������� ����������';
 if dlgSave1.Execute then
  begin
   FileNameT:=DlgSave1.FileName;
   AssignFile(Ft,FileNameT);
   Rewrite(Ft);
  end;
 for i:=1 to k-1 do
  with Fldest[i] do
   Writeln(Ft,'����� �����: ',n,' | ��� �������: ',plane,' | ����� ����������: ',Dest,' | ����� ������: ',time); 
CloseFile(Ft);
end;
end.

