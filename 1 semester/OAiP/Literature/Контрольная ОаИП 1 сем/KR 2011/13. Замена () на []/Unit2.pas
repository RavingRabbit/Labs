unit Unit2;

interface
uses sysutils;
type Tch = file of char;
procedure zamena(var fl:Tch; x,y:char);
implementation
procedure zamena;
var ch:char;
begin
  while not eof(fl) do
  begin
   read(fl,ch);
   if ch=x then begin
     seek(fl,filepos(fl)-1);
     write(fl,y);
   end;
  end;
end;
end.
 