unit Unit2;

interface
const nok=0;
type
   Tkey=integer;
   Tinf=record
      f:string;
      k:integer;
   end;


   Tmas=array [1..50] of Tinf;
   Tzad=class(Tobject)
      a:Tmas;
      n:Integer;
      procedure sort;
      function poiskd(k:Tkey):Tinf;
   end;


implementation

procedure Tzad.sort;
var i,j:integer;  z:Tinf;
begin
   for i:=1 to n-1 do
      for j:=i+1 to n do
         if a[i].k>a[j].k then
         begin
            z:=a[i];
            a[i]:=a[j];
            a[j]:=z;
         end;
end;

function Tzad.poiskd;
   function del(L,R:word):integer;
   var m:word;
   begin
      if r<=l then result:=r
      else  begin
         m:=(l+r) div 2;
         if a[m].k<k then del:=del(m+1,r)
            else del:=del(l,m);
      end;
   end; //del
var i:integer;
begin
   i:=del(1,n);
   if a[i].k=k then result:=a[i]
      else result.k:=nok;
end;




end.
 