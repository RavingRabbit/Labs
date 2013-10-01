unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

Type
  PSel=^TSel;
  TSel=record
    inf:integer;
    A:PSel;
  end;
  TStak=class
    s,r,N:integer;
    sp1,spk,sp:PSel;
    sa,sk:extended;
   constructor create;
   procedure Adds(Inf:integer);
   procedure Reads(var Inf:integer);
   procedure Min;
   procedure KolDoMin(x:integer);
   procedure Print(M:TMemo);
   procedure SortBublAfter;
   procedure SortBublInf;
   procedure SrAr;
   procedure SKR(sa:extended;N:integer);
  end;

implementation

constructor TStak.create;
begin
  Inherited create;
  sp1:=Nil;
end;

procedure TStak.Adds;
begin
  New(sp);
  sp^.Inf:=Inf;
  sp^.A:=sp1;
  sp1:=sp;
end;

procedure TStak.Reads;
begin
  if sp=Nil then
    ShowMessage('Стек пуст')
  else
    begin
      Inf:=sp1^.Inf;
      sp:=sp1;
      sp1:=sp1^.A;
      Dispose(sp);
    end;
end;

procedure TStak.SortBublAfter;
  procedure RevAfter(spi:Psel);
  var sp:Psel;
  begin
    sp:=spi^.A^.A;
		spi^.A^.A:=sp^.A;
		sp^.A:=spi^.A;
		spi^.A:=sp;
  end;
var spt:Psel;
begin
	spt:=Nil;
	Repeat
    sp:=sp1;
    while sp^.A^.A<>spt do
      begin
        if sp^.A^.Inf>sp^.A^.A^.Inf then
          RevAfter(sp);
        sp:=sp^.A;
      end;
    spt:=sp^.A;
  Until sp1^.A^.A=spt;
end;

procedure TStak.SortBublInf;
  procedure RevInf(spi:Psel);
  var Inf:integer;
  begin
    Inf:=spi^.Inf;
    spi^.Inf:=sp^.A^.Inf;
    spi^.A^.inf:=Inf;
  end;
var spt:Psel;
begin
	spt:=Nil;
	Repeat
	  sp:=sp1;
	  while sp^.A<>spt do
      begin
	      if sp^.Inf>sp^.A^.Inf then
          RevInf(sp);
	      sp:=sp^.A;
      end;
    spt:=sp;
	Until sp1^.A=spt;
end;

procedure TStak.Min;
begin
  sp:=sp1;
  r:=sp1.inf;
  while sp^.A<>Nil do
    begin
      if (sp^.A.inf<r) then
        r:=sp^.A.inf;
      sp:=sp^.A;
    end;
end;

procedure TStak.KolDoMin;
begin
  sp:=sp1;
  if sp1.inf=x then
    s:=0
  else
    begin
      s:=1;
      while (sp^.A.inf<>x) and (sp^.A<>Nil) do
        begin
          sp:=sp^.A;
          Inc(s);
        end;
    end;
end;

procedure TStak.Print;
begin
  sp:=sp1;
  if sp=Nil then
    ShowMessage('Стек пуст')
  else
    begin
      M.Lines.Add(IntToStr(sp.inf));
      while sp^.A<>Nil do
        begin
          M.Lines.Add(IntToStr(sp^.A.inf));
          sp:=sp^.A;
        end;
    end;
end;

procedure TStak.SrAr;
var sum:integer;
begin
  sp:=sp1;
  if sp=Nil then
    ShowMessage('Стек пуст')
  else
    begin
      sum:=sp.Inf;
      N:=1;
      while sp^.A<>Nil do
        begin
          sum:=sum+sp^.A.inf;
          Inc(N);
          sp:=sp^.A;
        end;
      sa:=sum/N;
    end;
end;

procedure TStak.SKR;
var q:extended;
begin
  sp:=sp1;
  if sp=Nil then
    ShowMessage('Стек пуст')
  else
    begin
      q:=sqr(sp.inf-sa);
      while sp^.A<>Nil do
        begin
          q:=q+sqr(sp^.A.inf-sa);
          sp:=sp^.A;
        end;
      sk:=sqrt(q/N);
    end;
end;

end.
