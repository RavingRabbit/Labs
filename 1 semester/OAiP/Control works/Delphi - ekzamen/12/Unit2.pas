unit Unit2;

interface
uses sysutils, grids;
type
   tkey=integer;
   Tinf=record
      f:string[50];
      k:Tkey;
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
      procedure wrt1b(var sgrid:Tstringgrid);
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
   end;//del

begin
   del(proot);
   if self<>nil then
      inherited destroy;
end;


procedure tzad.addb;
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



procedure Tzad.wrt1b;
var i:word;

   procedure wrt(p:Tself);
   begin
      if p<>nil then
      begin
         wrt(p.a1);
         sgrid.Cells[0,i]:=p.inf.f;
         sgrid.Cells[1,i]:=inttostr(p.inf.k);
         inc(i);
         wrt(p.a2);
      end;
   end;//wrt

begin
   i:=1;
   p:=proot;
   wrt(p);
end;

end.
 