unit Unit2;

interface

uses
  SysUtils;
Type mas=array[1..1] of extended;
     Tmas=^mas;
function polinom(x:extended;N:integer;const A:Tmas):extended;
implementation
function polinom;
var i:Integer; pol:extended;
begin
  pol:=A[N];
  for i:=N-1 downto 1 do begin
    pol:=pol*x+A[i];
  end;
  result:=pol;
end;
end.
 