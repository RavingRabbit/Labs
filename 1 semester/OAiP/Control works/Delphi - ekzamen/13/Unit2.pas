unit Unit2;

interface
const nok=0;
type
   Tkey=integer;
   tinf=record
      f:string[50];
      k:Tkey;
   end;

   Tself=^self;
   self=record
      inf:Tinf;
      a:Tself;
   end;

   Tmas=array [1..1] of Tself;
   Pmas=^Tmas;

   Tzad=class(Tobject)
      M:integer;
      H:Pmas;
      sp:Tself;
      constructor create(M0:Integer);
      procedure Add(inf:Tinf);
      function  Read(k:Tkey):Tinf;
   end;



implementation

Constructor Tzad.create;
var i:word;
begin
   inherited create;
   m:=m0;
   getmem(h,m*4);
   for i:=1 to m do
      h[i]:=nil;
end;


procedure Tzad.Add;
var i:word;
begin
   new(sp);
   sp.inf:=inf;
   i:=inf.k mod m;
   sp.a:=h[i];
   h[i]:=sp;
end;


function Tzad.Read;
var i:word;
begin
   i:=k mod m;
   sp:=h[i];
   if sp<>nil then
   begin
      while (sp<>nil)and(sp.inf.k<>k) do
         sp:=sp.a;
      if sp.inf.k=k then result:=sp.inf
      else result.k:=nok;
   end
   else result.k:=nok;
end;


end.
 