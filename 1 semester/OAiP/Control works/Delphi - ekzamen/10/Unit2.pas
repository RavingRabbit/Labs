unit Unit2;

interface
type
   Tinf=char;
   Tself=^self;
   self=record
      inf:Tinf;
      a:Tself;
   end;

   TStack=class(Tobject)
      sp1,sp:Tself;
      constructor create;
      procedure Add1(inf:Tinf);
      procedure Read1(var inf:Tinf);
   end;

   Tzad=class(Tobject)
      stack:Tstack;
      zn:array ['a'..'ÿ'] of extended;
      function AV(stp:string):extended;
   end;


implementation

constructor Tstack.create;
begin
   inherited create;
   sp1:=nil;
end;


procedure Tstack.Add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1;
   sp1:=sp;
end;


procedure Tstack.Read1;
begin
   sp:=sp1;
   inf:=sp1.inf;
   sp1:=sp1.a;
   dispose(sp);
end;


function Tzad.AV;
var i:integer; chr,ch1,ch2,ch:char;
   op1,op2,rez:extended;
begin
   stack:=Tstack.create;
   chr:=succ('z');
   for i:=1 to length(stp) do
   begin
      ch:=stp[i];
      if not(ch in ['+','-','*','/','^']) then stack.Add1(ch)
      else begin
         stack.Read1(ch2);
         stack.Read1(ch1);
         op1:=zn[ch1];
         op2:=zn[ch2];
         case ch of
            '+': rez:=op1+op2;
            '-': rez:=op1-op2;
            '*': rez:=op1*op2;
            '/': rez:=op1/op2;
            '^': rez:=exp(op2*ln(op1));
         end;
         zn[chr]:=rez;
         stack.Add1(chr);
         inc(chr);
      end;
   end;
   result:=rez;
   stack.Free;
end;

end.
 