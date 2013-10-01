unit Unit2;

interface
type
   tkey=integer;
   Tinf=record
      f:string;
      k:Tkey;
   end;

   Tmas= array [1..50] of Tinf;

   Tzad= class(Tobject)
      a:Tmas;
      n:Integer;
      procedure quicksort;
   end;

implementation

procedure Tzad.quicksort;
   procedure sort(L,R:word);
   var i,j:word; z:Tinf; x:Tkey;
   begin
      i:=L;
      j:=R;
      x:=a[(l+r)div 2].k;
      repeat
         while a[i].k<x do inc(i);
         while a[j].k>x do dec(j);
         if i<=j then
         begin
            z:=a[i];
            a[i]:=a[j];
            a[j]:=z;
            inc(i);
            dec(j);
         end;
      until j<i;
      if L<=j then sort(L,j);
      if i<=R then sort(i,R);
   end;//sort

begin
   sort(1,n);
end;

end.
 