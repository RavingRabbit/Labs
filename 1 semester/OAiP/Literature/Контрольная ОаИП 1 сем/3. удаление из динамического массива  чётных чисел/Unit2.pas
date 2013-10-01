unit Unit2;

interface
uses SysUtils, Grids, StdCtrls;
type
  Pmas1 = array[1..1] of Integer;
  Tm = ^Pmas1;
procedure algoritm(var mas1:Tm; var n,n1:integer);
implementation
 procedure algoritm;
 begin
   {$R-}
  n:=n*2;
  n1:=n1*2;
 end;
end.
