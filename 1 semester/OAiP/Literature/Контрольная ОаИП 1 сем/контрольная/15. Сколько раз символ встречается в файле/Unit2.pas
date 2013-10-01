unit Unit2;

interface
uses sysutils,Classes;
type Tch=file of char;
function kol(var fl:Tch; x:char):integer;
implementation
function kol;
var k:integer; ch:char;
begin
  k:=0;
  while not eof(fl) do
  begin
    read(fl,ch);
    if ch=x then inc(k);
  end;
  result:=k;
end;
end.
 