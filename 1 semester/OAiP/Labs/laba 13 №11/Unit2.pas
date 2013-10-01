unit Unit2;

interface
uses   Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Buttons, xpman;
type
  abiturient = record
    FIO:string[50];
    Address:string[100];
    Avrg_mark:real;
    end;
  Vedomosti_arr = array [0..1000] of abiturient;
  Vedomost = class(TObject)
    arr:Vedomosti_arr; //������ ���� ����������
    File_zap:file of abiturient;
    File_text:TextFile;
    N_zap:Word; //���������� �������
    procedure add_zap(e1,e2,e3:string);
    procedure read_file(var dlgOpen:TOpenDialog);
    procedure delete_abiturien(key:string; var memo:Tmemo);
    procedure save_file(var memo:TMemo; var dlgSave:TSaveDialog);
    function find(key:string):word;
    procedure sortirovka_sli(i,j:Integer);
    procedure sli(L,spl,R:integer);
    procedure sortirovka_QuickSort;
    procedure Binary_Search(key:Real; var memo:Tmemo);
    end;
implementation

procedure  Vedomost.add_zap; //��������� ������
begin
  inc(N_zap);
  with arr[N_zap] do begin
    FIO:=e1;
    Address:=e2;
    Avrg_mark:=strtofloat(e3);
  end;
  Write(File_zap,arr[N_zap]);
end;

procedure Vedomost.read_file; //������ ����
begin
  dlgOpen.Title:='������� ���� ����������';
  if dlgOpen.Execute then
    begin
      AssignFile(File_zap, dlgOpen.FileName);
      Reset(File_zap);
      N_zap:=0;
      while not eof(File_zap) do begin
        inc(N_zap);
        Read(File_zap,arr[N_zap]);
      end;
    end;

end;

function Vedomost.find; //����� ������
var i:word;
begin
  i:=1;
  arr[N_zap+1].FIO:=key; //������ ������
  while arr[i].FIO<>key do inc(i);
  result:=i;
end;

procedure Vedomost.delete_abiturien; //������� ������ �� ����� (���)
var i,j:word;
begin
  memo.Clear;
  i:=1;
  while i<=N_zap do
    begin
      if arr[i].FIO=key then begin Dec(N_zap); for j:=i to N_zap do arr[j]:=arr[j+1]; end;
      memo.Lines.Add('���: '+arr[i].FIO+' | �����: '+arr[i].Address+' | ������� ����: '+floattostr(arr[i].Avrg_mark));
      Inc(i);
    end;
end;

procedure Vedomost.save_file; //��������� ���������� � file:textfile
var i:Word;
begin
  dlgSave.Title:='��������� ��������� ����������';
  if dlgSave.Execute then
    begin
      AssignFile(File_text,dlgSave.filename);
      Rewrite(File_text);
      for i:=1 to N_zap do
        with arr[i] do
          Writeln(File_text,'���: ',FIO,' | �����: ',Address,' | ������� ����: ',floattostr(Avrg_mark));
      CloseFile(File_text);
    end;
end;

Procedure vedomost.sortirovka_sli;
var Spl:integer;
begin
  if i>=j then exit;
  spl:=(i+j) div 2;
  sortirovka_sli(i,spl);
  sortirovka_sli(spl+1,j);
  sli(i,spl,j);
end;

Procedure vedomost.sli;
var tmp:array [1..1000] of abiturient;
    i,j,k:Integer;
begin
    i:=L;
    j:=Spl+1;
    k:=1;
    while (i<=Spl) and (j<=R) do
    begin
      if arr[i].Avrg_mark>arr[j].Avrg_mark then
      begin
        tmp[k]:=arr[j];
        Inc(j);
      end
      else
      begin
        tmp[k]:=arr[i];
        Inc(i);
      end;
      Inc(k);
    end;
    if i<=Spl then
      for j:=i to Spl do
      begin
        tmp[k]:=arr[j];
        Inc(k);
      end
    else
      for i:=j to R do
      begin
        tmp[k]:=arr[i];
        Inc(k);
      end;
   for i:=1 to k-1 do begin arr[l+i-1]:=tmp[i]; end;
end;

procedure Vedomost.sortirovka_QuickSort;
 Var i,j,L,R,s:Word; x:real; w:abiturient;
		stak:array[1..1000] of record L,R:word end;
begin
  s:=1; stak[1].L:=1; stak[1].R:=N_zap;
  Repeat
    L:=stak[s].L; R:=stak[s].R; s:=s-1;
	  Repeat
		  i:=L; j:=R; x:=arr[(L+R) div 2].Avrg_mark;
	    Repeat
		    While arr[i].Avrg_mark<x do i:=i+1;
		      While x<arr[j].Avrg_mark do j:=j-1;
		        if i<=j then begin
		          w:=arr[i]; arr[i]:=arr[j]; arr[j]:=w; i:=i+1; j:=j-1 end;
	    until i>j;
		  if j-L<R-i then
		    begin
		      if i<R then
		        begin s:=s+1; stak[s].L:=i; stak[s].R:=R; end;
          R:=j;
		    end
       else
	  	begin
	    	if L<j then
	     	  begin s:=s+1;stak[s].L:=L;stak[s].R:=j end;
		    L:=i
	  	end;
	  until L>=R;
	until s=0;
end;

procedure Vedomost.Binary_Search;
var i,j,m:integer;
begin
  memo.clear;
  i:=1; J:=N_zap;
  while i<j do
    begin
      m:=(i+j) div 2;
      if arr[m].Avrg_mark<key then i:=m+1 else j:=m;
    end;
  Memo.Lines.add('���: '+arr[i].FIO+' | �����: '+arr[i].Address+' | ������� ����: '+floattostr(arr[i].Avrg_mark));
end;
end.
