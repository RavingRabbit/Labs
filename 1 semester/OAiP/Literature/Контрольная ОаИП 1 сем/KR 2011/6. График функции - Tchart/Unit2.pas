unit Unit2;

interface
uses sysutils,StdCtrls,Classes, Graphics, Chart;
type Tfn = function(x:extended):extended;
procedure tab(a,b:extended; n:integer; fun:Tfn; var cht1:Tchart);
implementation
procedure tab;
var i:integer; x,h:extended;
begin
  h:=(b-a)/n;
  x:=a;
  cht1.SeriesList[0].Clear;
  for i:=1 to n do  begin
    cht1.SeriesList[0].AddXY(x,fun(x));
    x:=x+h;
  end;
end;
end.
