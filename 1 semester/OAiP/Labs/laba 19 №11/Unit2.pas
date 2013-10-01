unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, StdCtrls;
type
  Tkey=Word;
  Tinf=record
    Fio:string;
    key:Tkey;
    end;
  Tsel=^sel;
    sel=record
    inf:Tinf;
    A:Tsel;
    end;
  Ms=array[0..0] of Tsel;
  Tms=^Ms;

  THesh=class(Tobject)
    M,n:Word;
    sp,sp1:Tsel;
    H:Tms;
    Constructor create(M0:word);
    Destructor Free(var sgrid:Tstringgrid);
    Procedure Add(Inf:Tinf);
    Function Read(key:Tkey):Tinf; //без удаления
    Function Readd(key:Tkey):Tinf; //с удалением
    procedure count(var memo:Tmemo);
 end;

implementation

procedure THesh.count(var memo:Tmemo);
var i,j:word;
begin
  for i:=0 to M-1 do
    begin
      j:=0;
      While H[i]<>Nil do
        begin
          H[i]:= H[i]^.A;
          inc(j);
				end;
      memo.lines.add('В '+inttostr(i)+'-м стеке '+inttostr(j)+' элементов');
    end;
end;

Constructor THesh.create(M0:word);
var i:word;
begin
  Inherited create;
  M:=M0; n:=0;
  Getmem(H,M*4); //Размещаем М указателей
  for i:=0 to M-1 do H[i]:=Nil;
end;

Destructor THesh.Free;// прочесть и удалить
var i,j:word;
begin j:=0;
  {for i:=0 to M-1 do
    begin
      While H[i]<>Nil do
        begin Inc(j);
          sp:=H[i];
          SGrid.Cells[0,j]:=sp^.inf.Fio;
          SGrid.Cells[1,j]:=IntToStr(sp^.inf.key);
          H[i]:= H[i]^.A;
          dispose(sp);
				end;
    end;}
  FreeMem(H,4*M);
  inherited destroy;
end;

Procedure THesh.Add;
var i:Tkey; p:Tsel;
begin
  i:=inf.key mod M;
  New(p); Inc(n);
  p^.Inf:=Inf;
  p^.A:=H[i];
  H[i]:=p;
end;

Function THesh.Read;
var i:Tkey;
begin
  i:=key mod M;
  sp:=H[i];
  While (sp<>Nil) and (sp^.inf.key<>key) do
    sp:=sp^.A;
  if sp<>Nil then Result:=sp^.inf
  else ShowMessage('ключ не найден');
end;

function THesh.Readd;
var i:Tkey;
begin
  i:=key mod M;
  sp:=H[i];
  if sp=Nil then ShowMessage('ключ не найден')
  else
    begin
      if sp^.inf.key=key then
        begin
          Result:=sp^.inf;
          H[i]:=H[i].A;
          dispose(sp);
          Dec(n);
        end
      else
        Begin  //ключ не в первой записи
          While (sp.A<>Nil) and (sp.A.inf.key<>key)
          do sp:=sp^.A;

          if sp.A<>Nil then
            begin
              Result:=sp.A.inf;
              sp1:=sp.A;
              sp.A:=sp.A.A;
              dispose(sp1); Dec(n);
            end
          else ShowMessage('ключ не найден');
        end;
    end;
end;
end.
