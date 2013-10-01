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
  Vedomosti_arr = array of abiturient;
  Vedomost = class(TObject)
    arr:Vedomosti_arr; //массив всех ведомостей
    File_zap:file of abiturient;
    N_zap:Word; //количество записей
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

procedure  Vedomost.add_zap; //добавляем запись
begin
  inc(N_zap);
  SetLength(arr,N_zap+1);
  with arr[N_zap] do begin
    FIO:=e1;
    Address:=e2;
    Avrg_mark:=strtofloat(e3);
  end;
  Write(File_zap,arr[N_zap]);
end;

procedure Vedomost.read_file; //читаем файл
begin
  dlgOpen.Title:='Открыть базу ведомостей';
  if dlgOpen.Execute then
    begin
      AssignFile(File_zap, dlgOpen.FileName);
      Reset(File_zap);
      N_zap:=0;
      SetLength(arr,filesize(File_zap)+1);
      while not eof(File_zap) do begin
        inc(N_zap);
        Read(File_zap,arr[N_zap]);
      end;
    end;

end;

function Vedomost.find; //найти запись
var i:word;
begin
  i:=1;
  arr[N_zap+1].FIO:=key; //вводим барьер
  while arr[i].FIO<>key do inc(i);
  result:=i;
end;

procedure Vedomost.delete_abiturien; //удаляем запись по ключу (ФИО)
var i,j:word;
begin
  memo.Clear;
  i:=0;
  while i<=N_zap do
    begin
    inc(i);
    if arr[i].FIO=key then
      begin
        for j:=i to (N_zap-1) do arr[j]:=arr[j+1];
        SetLength(arr, N_zap);
        Dec(N_zap);
      end;
    end;
  for i:=1 to N_zap do
    memo.Lines.Add('ФИО: '+arr[i].FIO+' | Адрес: '+arr[i].Address+' | Средний балл: '+floattostr(arr[i].Avrg_mark));
end;

procedure Vedomost.save_file; //сохраняем результаты
var i:Word; file_data:file of abiturient;
begin
  dlgSave.Title:='Сохранить результат сортировки';
  if dlgSave.Execute then
    begin
      AssignFile(File_data,dlgSave.filename);
      Rewrite(File_data);
      for i:=1 to N_zap do Write(File_data,arr[i]);
      CloseFile(File_data);
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
var tmp:array of abiturient;
    i,j,k:Integer;
begin
  SetLength(tmp,N_zap+1);
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
		stak:array of record L,R:word end;
begin
  setlength(stak,N_zap);
  s:=1; stak[1].L:=1; stak[1].R:=N_zap;
  Repeat
    L:=stak[s].L; R:=stak[s].R; s:=s-1;
	  Repeat
		  i:=L; j:=R; x:=arr[(L+R) div 2].Avrg_mark;
	    Repeat
		    While arr[i].Avrg_mark<x do i:=i+1;
		      While x<arr[j].Avrg_mark do j:=j-1;
		        if i<=j then
              begin w:=arr[i]; arr[i]:=arr[j]; arr[j]:=w; i:=i+1; j:=j-1 end;
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
  Memo.Lines.add('ФИО: '+arr[i].FIO+' | Адрес: '+arr[i].Address+' | Средний балл: '+floattostr(arr[i].Avrg_mark));
end;
end.
