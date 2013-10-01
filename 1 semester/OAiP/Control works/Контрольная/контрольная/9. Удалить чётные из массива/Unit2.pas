unit Unit2;

interface
uses sysutils;
type
  mas = array[0..0] of integer;
  Tmas = ^mas;
procedure del(var A:Tmas;var n,n1:integer);
implementation
procedure del;
var i,j:integer;
begin
 n1:=0;
 for i:=0 to n-1 do
   begin
    if not (A[i] mod 2 = 0) then
     begin
      A[n1]:=A[i];
      inc(n1);
     end;
   end;
end;
end.
 