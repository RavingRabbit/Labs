unit Unit2;
interface
uses SysUtils, StdCtrls;
type fun=function (x:Extended):Extended;
procedure Tabl(fun:fun;xn,xk:extended; m: word);
implementation
procedure Tabl (fun:fun;xn,xk:extended; m: word);
var x,h,y:Extended;
 begin
  x:=xn;
  h:=(xk-xn)/m;
  repeat
   y:=fun(x);
   x:=x+h;
  until x>(xk+h/2);
 end;
end.
