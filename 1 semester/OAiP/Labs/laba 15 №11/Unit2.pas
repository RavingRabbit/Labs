unit Unit2; //родительский класс

interface
uses SysUtils, StdCtrls, Dialogs;
Type
  Tinf=integer;
  TSel=^Sel; // указатель на запись
  Sel=Record
    inf:TInf; // информация
    A:TSel; // указатель на предыдущий элемент стека
    End;

  Tlist=class(Tobject)
    sp1,spk,sp:Tsel;
    constructor create;
    procedure Add1(Inf:Tinf);
    procedure Read1(var Inf:Tinf);
    procedure Print(lst:Tlistbox);
    procedure AddAfter(spi:Tsel; Inf:TInf);
    procedure AddBefore(spi:Tsel;Inf:Tinf);
    end;

implementation

constructor Tlist.create;
begin
  inherited create;
  sp1:=nil;
end;

Procedure Tlist.Add1;
begin
  New(sp);
	sp^.Inf:=Inf;
	sp^.A:=sp1;
	sp1:=sp;
end;

Procedure Tlist.Read1(var Inf:Tinf);
begin
  if sp1 <> Nil then
    begin
      Inf:=sp1^.Inf;
      sp:=sp1;
      sp1:=sp1^.A;
      Dispose(sp)
    end
    else showmessage('Стек пустой :( Совсем пустой!');
end;

Procedure Tlist.Print;
begin
  lst.Clear;
  sp:=sp1;
  While sp <> Nil do
    begin
      lst.items.Add(inttostr(sp^.Inf));
    	sp:=sp^.A;
    end;
end;

Procedure Tlist.AddAfter(spi:Tsel;Inf:TInf);
begin
  New(sp);
	sp^.Inf:=Inf;
	sp^.A:=spi^.A;
	spi^.A:=sp;
end;

Procedure Tlist.AddBefore(spi:Tsel;Inf:Tinf);
begin
  AddAfter(spi,spi^.Inf);
  spi^.Inf:=Inf;
end;

end.
