unit Unit2;

interface
uses sysutils;
type mas = array [0..0] of integer;
     Tmas=^mas;
function fun(A:Tmas;N:integer;bl:boolean):integer;
implementation
function fun;
var i,min,mini,max,maxi:integer;
begin
  if bl then
   begin
    max:=A[0]; maxi:=1;
    for i:=1 to N-1 do begin
      if A[i]>max then begin max:=A[i]; maxi:=i+1 end;
    end;
    result:=maxi;
   end
  else
   begin
    min:=A[0]; mini:=1;
    for i:=1 to N-1 do begin
      if A[i]<min then begin min:=A[i]; mini:=i+1; end;
    end;
    result:=mini;
   end;
end;
end.
 