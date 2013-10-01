unit Unit2;

interface
uses sysutils;
type mas = array[0..0] of integer;
Tmas = ^mas;
procedure insert(var A:Tmas; N,c:integer);
implementation
procedure insert;
var i,j,k:integer;
begin
  i:=n-1;
  while (A[i]>c) and (i>=0) do
  begin
    A[i+1]:=A[i];
    dec(i);
  end;
  A[i+1]:=c;
end;
end.
 