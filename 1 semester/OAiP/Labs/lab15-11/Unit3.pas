unit Unit3; //класс для решения 11 варианта

interface
uses Unit2,SysUtils, Dialogs;
type Tzad = class(Tlist)
   procedure add_random(N:Integer);
   function find_max():integer;
   function find_min():integer;
   procedure replace;
   end;
implementation
procedure Tzad.add_random;
var i:Word;
begin
  sp1:=nil;
  randomize;
  for i:=1 to n do
    Inherited Add1(Random(100));
end;

function Tzad.find_max():integer;
var i:word;
begin
  sp:=sp1;
  result:=sp^.Inf;
  sp:=sp^.A;
  While sp <> Nil do
    begin
      if result<sp^.Inf then result:=sp^.Inf;
    	sp:=sp^.A;
    end;
end;

function Tzad.find_min():integer;
var i:word;
begin
  sp:=sp1;
  result:=sp^.Inf;
  sp:=sp^.A;
  While sp <> Nil do
    begin
      if result>sp^.Inf then result:=sp^.Inf;
    	sp:=sp^.A;
    end;
end;

procedure Tzad.replace;
var max,min:integer;
begin
  if sp1 <> Nil then
    begin
      max:=find_max();
      min:=find_min();
      sp:=sp1;
      While sp <> Nil do
        begin
          if (sp^.Inf=max) or (sp^.Inf=min) then
            if sp^.Inf=max then sp^.Inf:=min
            else sp^.Inf:=max;
    	    sp:=sp^.A;
        end;
    end
  else showmessage('Стек пустой :( Совсем пустой!');
end;
end.
