unit Unit2;

interface
uses sysutils, TeEngine, Series, TeeProcs, Chart, Math;
type
Complex = record re,im:extended end;
Tfn = function(x:extended):complex;
procedure graf(a,b:extended; n:integer; f:Tfn; cht1:Tchart);
implementation

procedure graf;
var h,x:extended; y:complex; i:word;
begin
  cht1.SeriesList[0].Clear;
  cht1.SeriesList[1].Clear;
  h:=(b-a)/n;
  x:=a;
  for i:=1 to n do begin
    y:=f(x);
    cht1.SeriesList[0].AddXY(x,y.re);
    cht1.SeriesList[1].AddXY(x,y.im);
    x:=x+h;
  end;
end;

end.
 