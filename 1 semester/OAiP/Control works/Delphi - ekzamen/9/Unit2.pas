unit Unit2;

interface
type
   tinf=record
      w,c:integer;
   end;

   Tmas= array [1..20] of Tinf;

   Tzad=class(Tobject)
      a:Tmas;
      n,wt,ct,cmax,wmax:integer;
      sopt:set of byte;
      procedure minw;
   end;

implementation

procedure Tzad.minw;
   function imin:integer;
   var i,ic,wc:integer;
   begin
      ic:=0;
      wc:=wmax;
      for i:=1 to n do
         if not(i in sopt) and (a[i].w<wc) then
         begin
            ic:=i;
            wc:=a[i].w;
         end;
      result:=ic;
   end;      //imin

var i:integer;
begin
   i:=imin;
   wt:=a[i].w;
   ct:=a[i].c;
   while wt<=wmax do
   begin
      include(sopt,i);
      i:=imin;
      wt:=wt+a[i].w;
      ct:=ct+a[i].c;
   end;
   cmax:=ct-a[i].c;
end;

end.
 