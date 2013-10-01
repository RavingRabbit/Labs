unit Unit2;

interface

  procedure calculate(var M,N,NOD,NOK:integer);

implementation

procedure calculate;
var i,j,M0,N0:integer;
begin
  M0:=M;
  N0:=N;
  //считает NOD
  while (M0<>0) and (N0<>0) do
    begin
      If M0>N0 Then M0:=M0 Mod N0
      Else N0:=N0 Mod M0;
    end;
  NOD:=M0+N0;
  //считаем NOK
  NOK:=(N*M) div NOD;
end;
end.
