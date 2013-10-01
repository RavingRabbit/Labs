unit Unit2;

interface
uses sysutils;
Type
  Trec=class(Tobject)
    Function recursivno(n:integer):extended;
    Function recurrentno(n:integer):extended;
  end;
implementation
function Trec.recursivno;
begin
  if n=1 then result:=2/3 else result:=1/(n+recursivno(n-1));
end;

function Trec.recurrentno;
var i:integer; y:extended;
begin
  y:=2/3;
  for i:=2 to n do y:=1/(i+y);
  result:=y;
end;
end.
 