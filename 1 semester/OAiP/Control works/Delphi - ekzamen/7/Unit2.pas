unit Unit2;

interface
type
   Tkey=integer;
   Tinf=record
      f:string[50];
      k:Tkey;
   end;

   Tself=^self;
   self=record
      inf:Tinf;
      a:Tself;
   end;

   Tzad=class(Tobject)
      sp1,sp,spk:Tself;
      constructor Create;
      procedure Addk(inf:Tinf);
      procedure Read1(var inf:Tinf);
      procedure sortslip;
   end;

implementation

constructor Tzad.Create;
begin
   inherited Create;
   sp1:=nil;
   spk:=nil;
end;


procedure Tzad.Addk;
begin
   New(sp);
   sp.inf:=inf;
   sp.a:=nil;
   if sp1=nil then
   begin
      sp1:=sp;
      spk:=sp;
   end
   else begin
      spk.a:=sp;
      spk:=sp;
   end;
end;


procedure Tzad.Read1;
begin
   inf:=sp1.inf;
   sp:=sp1;
   sp1:=sp.a;
   if sp1=nil then spk:=nil;
   dispose(sp);
end;


procedure Tzad.sortslip;

   procedure div2sp(tp:Tzad;var tq,tr:Tzad);
   var c:boolean;  inf:Tinf;
   begin
      tq:=Tzad.Create;
      tr:=Tzad.Create;
      c:=false;
      while tp.sp1<>nil do
      begin
         c:=not(c);
         tp.Read1(inf);
         if c then tq.Addk(inf)
         else tr.Addk(inf);
      end;
   end; //div2sp


   procedure slip(tq,tr:Tzad; var tp:Tzad);
   var inf:Tinf;
   begin
      while (tq.sp1<>nil)and(tr.sp1<>nil) do
         if tq.sp1.inf.k<tr.sp1.inf.k then
         begin
            tq.Read1(inf);
            tp.Addk(inf);
         end
         else begin
            tr.Read1(inf);
            tp.Addk(inf);
         end;

      while tq.sp1<>nil do
      begin
         tq.Read1(inf);
         tp.Addk(inf);
      end;

      while tr.sp1<>nil do
      begin
         tr.Read1(inf);
         tp.Addk(inf);
      end;
   end; //slip

   procedure srsl(tp:Tzad);
   var tq,tr:Tzad;
   begin
      if tp.sp1<>tp.spk then
      begin
         div2sp(tp,tq,tr);
         srsl(tq);
         srsl(tr);
         slip(tq,tr,tp);
      end;
   end;//srsl

begin
   srsl(self);
end;

end.



