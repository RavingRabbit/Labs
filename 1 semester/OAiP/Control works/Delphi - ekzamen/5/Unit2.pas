unit Unit2;

interface
type
   Tinf=record
      w,c:integer;
   end;

   Tmas=array [1..50] of Tinf;

   Tzad=class(Tobject)
      a:Tmas;
      wmax,cmax,n:integer;
      s,sopt:set of byte;
      procedure VG(i,wt,oct:Integer);
   end;


implementation

procedure Tzad.VG;
var wt1,oct1:Integer;
begin
   //попытка включения
   wt1:=wt+a[i].w;
   if wt1<=wmax then
   begin
      include(s,i);
      if i<n then vg(i+1,wt1,oct)
      else if oct>=cmax then
      begin
         sopt:=s;
         cmax:=oct;
      end;
      exclude(s,i);
   end;

   //попытка исключения
   oct1:=oct-a[i].c;
   if oct1>cmax then
      if i<n then vg(i+1,wt,oct1)
      else begin
         sopt:=s;
         cmax:=oct1;
      end;

end;

end.
