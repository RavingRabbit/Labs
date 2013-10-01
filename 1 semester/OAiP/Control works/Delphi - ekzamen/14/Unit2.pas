unit Unit2;

interface
type
   Tkey=integer;
   Tinf=record
      f:string[50];
      k:Tkey;
   end;
   Tmas=array [1..50] of tinf;


   Tself=^self;
   self=record
      inf:Tinf;
      a1,a2:Tself;
   end;

   Tzad=class(tobject)
      p,proot:Tself;
      constructor create;
      Procedure blns(a:tmas;n:word);
      function minkB:tinf;
      destructor free;
   end;

implementation

constructor Tzad.create;
begin
   inherited create;
   proot:=nil;
end;

Destructor Tzad.free;
   procedure del(p:Tself);
   begin
      if p<>nil then
      begin
         del(p.a1);
         del(p.a2);
         dispose(p);
         p:=nil;
      end;
   end;
begin
   del(proot);
   if self<>nil then
      inherited destroy;
end;


Procedure Tzad.blns;
   function bl(L,R:word):Tself;
   var p:Tself; m:word;
   begin
      if r<l then p:=nil
      else begin
         m:=(l+r) div 2;
         new(p);
         p.inf:=a[m];
         p.a1:=bl(L,m-1);
         p.a2:=bl(m+1,R);
      end;
      result:=p;
   end;  //bl

begin
   proot:=bl(1,n);
end;



function Tzad.minkB;
begin
   p:=proot;
   while p.a1<>nil do
      p:=p.a1;
   result:=p.inf;
end;



end.

