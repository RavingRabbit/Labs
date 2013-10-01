unit Unit2;

interface
type
   Tinf=char;
   Tself=^self;
   self=record
      inf:Tinf;
      a:Tself;
   end;

   Tstack=class(Tobject)
      sp1,sp:Tself;
      constructor create;
      procedure add1(inf:Tinf);
      procedure read1(var inf:Tinf);
   end;


   Tzad=class(Tobject)
      stack:Tstack;
      procedure OBP(sti:string; var stp:string);
   end;


implementation

constructor Tstack.create;
begin
   inherited create;
   sp1:=nil;
end;

procedure Tstack.add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1;
   sp1:=sp;
end;

procedure Tstack.read1;
begin
   inf:=sp1.inf;
   sp:=sp1;
   sp1:=sp1.a;
   dispose(sp);
end;


procedure Tzad.OBP;
   function prior(ch:char):byte;
   begin
      case ch of
         '(',')': prior:=0;
         '+','-': prior:=1;
         '*','/': prior:=2;
         '^': prior:=3;
      end;
   end;//prior
var i:byte; pc:0..3; ch,ch1:char;
begin
   stack:=Tstack.create;
   stp:='';
   for i:=1 to length(sti) do
   begin
      ch:=sti[i];
      if not(ch in ['(',')','+','-','*','/','^']) then
         stp:=stp+ch

      else
         if ch='(' then stack.add1(ch)

         else
            if stack.sp1=nil then stack.add1(ch)

            else
               if ch=')' then
               begin
                  stack.read1(ch);
                  while ch<>'(' do
                  begin
                     stp:=stp+ch;
                     stack.read1(ch);
                  end;
               end

               else begin
                  pc:=prior(ch);
                  while(stack.sp1<>nil) and (pc<=prior(stack.sp1.inf)) do
                  begin
                     stack.read1(ch1);
                     stp:=stp+ch1;
                  end;
                  stack.add1(ch);
               end;
   end;
   while stack.sp1<>nil do
   begin
      stack.read1(ch);
      stp:=stp+ch;
   end;
end;


end.
 