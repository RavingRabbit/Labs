unit Unit2;

interface
const nok=0;
type
   Tkey=integer;
   Tinf=record
      f:string[50];
      k:tkey;
   end;

   Tself=^self;
   self=record
      inf:Tinf;
      a1,a2:Tself;
   end;

   Tzad=class(Tobject)
      p,proot,q,w:Tself;
      constructor create;
      procedure addb(inf:Tinf);
      function Pioskb(k:Tkey):Tinf;
      destructor free;
   end;

implementation

constructor Tzad.create;
begin
   inherited create;
   proot:=nil;
end;


destructor Tzad.free;
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


procedure Tzad.addb;
var bl:boolean;
begin
   new(w);
   w.inf:=inf;
   w.a1:=nil;
   w.a2:=nil;
   if proot=nil then
      proot:=w
   else
   begin
      p:=proot;
      repeat
         q:=p;
         bl:=inf.k<p.inf.k;
         if bl then p:=p.a1
         else p:=p.a2;
      until p=nil;

      if bl then q.a1:=w
      else q.a2:=w;
   end;
end;


Function Tzad.Pioskb;
begin
   p:=proot;
   if p<>nil then
   begin
      while (p<>nil) and(p.inf.k<>k) do
         if k<p.inf.k then p:=p.a1
         else p:=p.a2;
      if p<>nil then result:=p.inf
      else result.k:=nok;
   end
   else result.k:=nok;
end;

end.
 