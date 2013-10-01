unit Unit2;

interface
type
   tinf=char;

   Psel=^sel;
   sel=record
      inf:Tinf;
      a:psel;
   end;

   Tzad=class(Tobject)
   sp,sp1:Psel;
      zn:array['a'..'ÿ'] of extended;
      constructor create;
      procedure add1(inf:Tinf);
      procedure read1(var Inf:Tinf);
      procedure OBP(var si,sp:string);
   end;



implementation
constructor Tzad.create;
begin
   inherited create;
   sp1:=nil;
end;



procedure Tzad.add1;
begin
   new(sp);
   sp.inf:=inf;
   sp.a:=sp1;
   sp1:=sp;
end;


procedure Tzad.read1;
begin
   sp:=sp1;
   inf:=sp.inf;
   sp1:=sp.a;
   dispose(sp);
end;


procedure Tzad.OBP(var si,sp:string);
   function prior(ch:char):byte;
   begin
      case ch of
         '(',')': prior:=0;
         '+','-': prior:=1;
         '*','/': Prior:=2;
         '^': prior:=3;
      end;
   end; //prior

var pc:0..3; i:word;
   ch,ch1:char;
begin
   sp:='';
   for i:=1 to length(si) do
   begin
      ch:=si[i];
      if not(ch in [')','(','+','-','*','/','^']) then
         sp:=sp+ch
      else
        begin
         if sp1=nil then
           add1(ch)
         else
           if ch='(' then
             add1(ch)
           else
             if ch=')' then
               begin
                 read1(ch);
                 while ch<>'(' do
                   begin
                     sp:=sp+ch;
                     read1(ch);
                   end;
               end
             else
               begin
                 pc:=prior(ch);
                 while (sp1<>nil) and (pc<=prior(sp1.inf)) do
                 begin
                   read1(ch1);
                   sp:=sp+ch1;
                 end;
                 add1(ch);
               end;
        end;
   end;
   while sp1<>nil do
   begin
      read1(ch);
      sp:=sp+ch;
   end;

end;




end.
 