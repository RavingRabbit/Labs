unit Unit2;

interface
uses SysUtils, StdCtrls;
procedure algoritm(N:integer);
var M:integer;
implementation
procedure algoritm;
var ost:integer;
begin
M:=0;
repeat
  ost:=N mod 10;
  M:=M*10+ost;
  N:=N div 10;
  until N=0;
end;
end.
 