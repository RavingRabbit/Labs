unit Unit2;

interface
type
   Tkey=integer;

   Tinf=record
      f:String[50];
      k:Tkey;
   end;

   Tself=^self;
   self=record
      inf:Tinf;
      a:Tself;
   end;

   Tzad=class(Tobject)
      sp,sp1:Tself;
      constructor create;
      procedure Add1(inf:Tinf);
      procedure read1(var inf:Tinf);
      procedure sortb;
   end;


implementation

constructor Tzad.create;
begin
   inherited create;
   new(sp1);
   sp1.a:=nil;
end;

procedure Tzad.Add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1.a;
   sp1.a:=sp;
end;

procedure Tzad.read1;
begin
   sp:=sp1.a;
   inf:=sp.inf;
   sp1.a:=sp.a;
   dispose(sp);
end;


procedure Tzad.sortb;
   procedure revafter(spi:Tself);
   var sp:Tself;
   begin
      sp:=spi.a.a;
      spi.a.a:=sp.a;
      sp.a:=spi.a;
      spi.a:=sp;
   end;
var spt:Tself;
begin
   spt:=nil;
   repeat
      sp:=sp1;
      while sp.a.a<>spt do
      begin
         if sp.a.inf.k>sp.a.a.inf.k then revafter(sp);
         sp:=sp.a;
      end;
      spt:=sp.a;
   until spt=sp1.a.a;   
end;




end.
 