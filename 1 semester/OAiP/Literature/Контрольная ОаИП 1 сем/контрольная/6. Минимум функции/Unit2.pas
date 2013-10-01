unit Unit2;

interface
uses sysutils;
type Tfn=function(x:extended):extended;
function funct(a,b,h:extended; fun:Tfn):extended;
implementation
function funct;
var x,min:extended;
begin
  x:=a; min:=fun(a);
  repeat
    x:=x+h;
    if fun(x)<min then min:=fun(x);
    until x>(b-h);
    result:=min;
end;
end.
 