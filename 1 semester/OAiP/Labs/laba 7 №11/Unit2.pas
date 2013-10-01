unit Unit2;
interface
uses SysUtils, dialogs;
function Convert(str:string):string;
implementation

function preConvert(bufer:string):string;
begin
 try
  case StrToInt(bufer) of
   0000: bufer:='0';   0001: bufer:='1';
   0010: bufer:='2';
   0011: bufer:='3';
   0100: bufer:='4';
   0101: bufer:='5';
   0110: bufer:='6';
   0111: bufer:='7';
   1000: bufer:='8';
   1001: bufer:='9';
   1010: bufer:='A';
   1011: bufer:='B';
   1100: bufer:='C';
   1101: bufer:='D';
   1110: bufer:='E';
   1111: bufer:='F';
   else messagedlg('¬ведите двоичное число',mtError,[mbOK],0);
  end;
 except
  on EConvertError do messagedlg('¬ведите двоичное число',mtError,[mbOK],0);
  end;
  result:=bufer;
end;

function Convert(str:string):string;
var newStr,bufer:string; n,i,leng:integer;
begin
  leng:=Length(str);
  n:=4-(leng mod 4); //сколько нулей добавить
  if n<>4 then
   begin
    for i:=1 to n do  Insert('0',str,1);
    Leng:=leng+n;
   end;
  newStr:='';
  for i:=0 to leng div 4 - 1 do
   begin
    bufer:=copy(str,i*4+1,4);
    bufer:=preConvert(bufer);
    newStr:=newStr+bufer;
   end;
 Result:=newStr;
end;
end.
