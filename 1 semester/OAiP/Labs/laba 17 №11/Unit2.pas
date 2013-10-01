unit Unit2;
interface
uses SysUtils, Grids, math;
type
  Tstek=^stek;
  stek=record Inf:Char; A:Tstek end;
  Tzad = class(TObject)
    str: string;
    mszn: array[97..200] of extended;
    stk: Tstek;
    constructor create;
    Procedure add1(var P:Tstek; S:char);
    Procedure read1(var p:Tstek; var S:char);
    Function calculate(strp:string):extended;
    Function rang(ch:char):byte;
    procedure read_mas(strngrd:TStringGrid);
    Procedure convert(var stri,strp:string);
    end;
implementation

constructor Tzad.create;
begin
  inherited create;
end;

procedure Tzad.read_mas;
var i:Byte;
begin
  For i:=1 to 7 do mszn[ord(StrnGrd.Cells[0,i][1])]:=StrToFloat(StrnGrd.Cells[1,i]);
end;

Procedure Tzad.add1(var P:Tstek;S:char);
Var Pt:Tstek;
Begin
  if p=nil then
    begin
      New(P);
      P^.inf:=s;
      P^.A:=nil;
    end
  else
    begin
      New(Pt);
      Pt^.inf:=s;
      Pt^.A:=p;
      P:=pt;
    end;
end;

Procedure Tzad.Read1(var p:Tstek; var S:char);
Var Pt:Tstek;
Begin
  S:=p^.inf;
  Pt:=p;
  p:=p^.A;
  Dispose(pt);
End;

Function Tzad.calculate(strp:string):extended;
var ch,ch1,ch2,chr:char; op1,op2:extended; i:byte;
begin
  chr:='{';
  for i:=1 to Length(strp) do
    begin
      ch:=strp[i];
      if not (ch in	['/','-','+','*','^']) then
        add1(stk,ch)
      else
        begin
          Read1(stk,ch1);
          Read1(stk,ch2);
          op1:=mszn[ord(ch1)];
          op2:=mszn[ord(ch2)];
          case ch of
            '+':result:=op2+op1;
            '-':result:=op2-op1;
            '*':result:=op2*op1;
            '/':result:=op2/op1;
            '^':result:=Power(op2,op1);
          end;
          mszn[ord(chr)]:=result;;
          add1(stk,chr);
          inc(Chr);
        end;
    end;
end;

Function Tzad.rang(ch:char):byte;
begin
  case ch of
    '(',')': Result:=0;
    '+','-': Result:=1;
    '*','/': Result:=2;
    '^': Result:=3;
  end;
end;

Procedure Tzad.convert(var stri,strp : string);
Var stk:Tstek; n,i:byte; ch,ch1:char; bl:boolean;
begin
  strp:='';
  n:=length(stri);
  stk:=nil;
  for i:=1 to n do
    begin
      ch:=stri[i];
      if ch in['/','-','+','*','^','(',')'] then
        if ch='(' then add1(stk,ch)
          else
            if ch=')' then
              begin
                Read1(stk,ch);
                While ch<>'(' do
                  begin
                    strp:=strp+ch;
                    Read1(stk,ch);
                  end
              end
            else
              if stk=Nil then add1(stk,ch)
                else
                  begin
                    Repeat
                      Read1(stk,ch1);
                      bl:=(rang(ch1)>=rang(ch));
                      if bl then strp:=strp+ch1 else add1(stk,ch1);
                    Until(stk=Nil) or (Not bl);
                    add1(stk,ch);
                  end
      else strp:=strp+ch;
    end;
  While stk<>nil do begin Read1(stk,ch);strp:=strp+ch end;
end;
end.
 