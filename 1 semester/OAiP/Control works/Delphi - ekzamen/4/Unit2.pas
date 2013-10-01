unit Unit2;

interface
Type
   Tinf=record
      w,c:integer;
   end;

   Tmas=array [1..50] of Tinf;

   Tzad= class(Tobject)
      a:Tmas;
      wt,ct,wmax,cmax,n:Integer;
      s,sopt:set of byte;
      procedure PP(i:byte);
   end;


implementation

procedure Tzad.PP;
begin
   wt:=wt+a[i].w;
   ct:=ct+a[i].c;
   include(s,i);
   if i<n then pp(i+1)
   else if (wt<=wmax) and (ct>=cmax) then
   begin
      sopt:=s;
      cmax:=ct;
   end;

   exclude(s,i);
   wt:=wt-a[i].w;
   ct:=ct-a[i].c;
   if i<n then pp(i+1)
   else if (wt<=wmax) and (ct>=cmax) then
   begin
      sopt:=s;
      cmax:=ct;
   end;

end;

end.
 