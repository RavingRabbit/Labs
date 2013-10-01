unit Unit2;

interface
uses sysutils, StdCtrls;
procedure proc(s1:string; var memo:tmemo);
implementation
procedure proc;
var n,i,j,k:integer; s2,x:string;
begin
  memo.lines.add(s1);
  x:='';
  n:=length(s1);
  s1:=s1+' ';
  n:=n+1;
  s2:='';
  for i:=1 to n do
   if s1[i]<>' ' then s2:=s2+s1[i]
    else if s2<>'' then
     if not (odd(strtoint(s2))) then
      begin x:=x+s2+' ';  s2:=''; end else s2:='';
  memo.lines.add(x);
end;
end.
 