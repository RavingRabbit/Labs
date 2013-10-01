Unit Unit2;
Interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, XPMan, Grids;
Type

  Tinf=record
    a:extended;
    j:word;
    end;
  Tsel=^sel;
    sel=record
    inf:Tinf;
    A:Tsel;
    end;
  Tlists=class(Tobject)
    sp1,sp:Tsel;
    procedure adds(inf:Tinf);
    procedure addsj(inf:tinf);
    function readsj(j:word):extended;
    procedure dels;
    end;
  Tmslists= array[1..1] of TLists;
  TListms=class(TLists)
    ms:^Tmslists;
    m,n:word;
    constructor create(m0,n0:word);
    destructor free;
    Procedure add(i,j:word;a:extended);
    Procedure addj(i,j:word;a:extended);
    Function read(i,j:word):extended;
    Procedure Print(StG:TStringGrid);
    end;

implementation

Procedure TLists.Adds(Inf:Tinf);
begin
  New(sp);
  sp^.Inf:=Inf;
  sp^.A:=sp1;
  sp1:=sp;
end;

Procedure TLists.addsj(Inf:Tinf);
 var spt:Tsel; j:word;
begin
  New(sp);
  sp^.Inf:=inf;
  if sp1=nil then
    begin sp1:=sp; sp1^.A:=nil end
  else
    if sp1^.inf.j>=inf.j then
      begin  sp^.A:=sp1; sp1:=sp end
    else
      begin            
        spt:=sp1;
        while (spt^.A<>nil) and (spt^.A^.inf.j<inf.j)
          do spt:=spt^.A;
        sp^.A:=spt^.A; spt^.A:=sp;
      end;
end;

Function Tlists.readsj(j:word):extended;
begin
  sp:=sp1;
  while (sp<>Nil) and (sp^.inf.j<>j)
    do sp:=sp.A;
	if sp=nil then result:=0
  else result:=sp^.Inf.a;
end;

Procedure TLists.dels;
begin
  sp:=sp1;
  sp1:=sp1^.A;
  Dispose(sp);
end;

constructor TListms.create(m0,n0:word);
Var i:word;
begin m:=m0; n:=n0;
  inherited create;
  GetMem(ms,4*m);
  for i:=1 to m do
    begin
      ms[i]:=Tlists.create;
      ms[i].sp1:=nil
    end;
end;

destructor TListms.free;
Var i:word;
begin
  for i:=1 to m do
    while ms[i].sp1<>nil do
      begin ms[i].dels;ms[i].Free end;
  FreeMem(ms,4*m);
end;

Procedure TListms.add(i,j:word;a:extended);
Var inf:Tinf;
begin
  inf.a:=a;
  inf.j:=j;
  ms[i].adds(inf);
end;

Procedure TListms.addj(i,j:word;a:extended);
var inf:Tinf;
begin
  inf.a:=a; inf.j:=j;
  ms[i].addsj(inf);
end;

Function TListms.read(i,j:word):extended;
Var inf:Tinf;
begin
  result:=ms[i].readsj(j);
end;

Procedure TListms.Print(stg:TStringGrid);
Var i,j:word;
begin
  for i:=1 to m do
    for j:=1 to n do
      StG.Cells[j,i]:=FloatToStr(ms[i].readsj(j))
end;
end.

