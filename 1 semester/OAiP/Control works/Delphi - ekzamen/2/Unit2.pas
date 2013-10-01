unit Unit2;

interface
type
   Tkey=integer;
   Tinf=record
      f:string;
      k:Tkey;
   end;
   Tmas=array [1..50] of Tinf;

   Tzad=class(Tobject)
      a:Tmas;
      n:Integer;
      procedure sortslip;
   end;

implementation

procedure  Tzad.sortslip;
   procedure slip(L,m,R:word);
   var i,j,k:word; c:Tmas;
   begin
      i:=L;
      j:=m+1;
      k:=1;

      while(i<=m) and (j<=r) do
         if a[i].k<a[j].k then
         begin
            c[k]:=a[i];
            inc(i);
            inc(k);
         end
         else begin
            c[k]:=a[j];
            inc(k);
            inc(j);
         end;

      while i<=m do
      begin
         c[k]:=a[i];
         inc(i);
         inc(k);
      end;

      while j<=r do
      begin
         c[k]:=a[j];
         inc(k);
         inc(j);
      end;

      k:=1;
      for i:=l to r do
      begin
         a[i]:=c[k];
         inc(k);
      end;
   end; //slip;

   procedure srsl(L,R:word);
   var m:Word;
   begin
      if l<>r then
      begin
         m:=(l+r) div 2;
         srsl(l,m);
         srsl(m+1,r);
         slip(l,m,r);
      end;
   end;//srsl

begin
   srsl(1,n);
end;


end.
 