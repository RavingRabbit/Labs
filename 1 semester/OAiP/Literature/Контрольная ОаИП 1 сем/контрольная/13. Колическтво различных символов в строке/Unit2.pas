unit Unit2;

interface
uses sysutils;
procedure st(var s:string);
implementation

procedure st;
var a:set of char; i,j,k:integer;
begin
  j:=length(s);
  k:=0;
  a:=[];
  for i:=1 to j do begin
    if not (s[i] in a) then
      begin
        include(a,s[i]);
        inc(k);
      end;
  end;
  s:='В строке '+inttostr(k)+' различных символа';
end;
end.
 