unit Unit2;

interface
uses sysutils;
procedure zamena(var N:integer);
implementation
procedure zamena;
var i,k,ost,M:integer;
begin
   M:=0;
   while N<>0 do begin
     ost:=N mod 10;
     M:=M*10+ost;
     N:= n div 10;
   end;
   N:=M;
end;
end.
 