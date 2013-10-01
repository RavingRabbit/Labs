unit Unit2;

interface
uses sysutils,StdCtrls;
type Tfn = function(x:extended):extended;
procedure tab(a,b:extended; n:integer; fun:Tfn; var fl:textfile);
implementation
procedure tab;
var i:integer; x,h:extended;
begin
  h:=(b-a)/n;
  x:=a;
  while x<b do begin
    writeln(fl,'x = ',floattostr(x),', y = ',floattostrF(fun(x),fffixed,6,2));
    x:=x+h;
  end;
end;
end.
