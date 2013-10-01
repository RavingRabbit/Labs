unit Unit2;

interface
     uses SysUtils;
function fun(N:integer; bl:boolean):integer;
implementation
function fun;
var sum,ost,proizv:integer;
begin
  case bl of
  true:            //сумма
    begin
     sum:=0;
     while N<>0 do begin
       ost:= N mod 10;
       sum:= sum+ost;
       N:= n div 10;
     end;
     result:=sum;
    end;
  false:
    begin
      proizv:=1;
      while N<>0 do begin
        ost:= N mod 10;
        proizv:=proizv*ost;
        N:=N div 10;
      end;
      result:=proizv;
    end;
  end;
end;
end.
 