unit Unit2;

interface
uses SysUtils, StdCtrls;
procedure limit(a,e,x0,x1:Extended);
var x,d:Extended; i:integer;
implementation
procedure limit;
begin
  i:=0;
  repeat
   inc(i);
   x:=(1/2)*(x1+a/x0);
   d:=Abs(x-x1);
   x0:= x1;
   x1:=x;
  until (d<e) or (i>100);
end;
end.
 