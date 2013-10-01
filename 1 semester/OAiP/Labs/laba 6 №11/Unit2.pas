unit Unit2;

interface
uses SysUtils, StdCtrls;
  type
  fun=function (x:Extended):Extended;

  procedure Tabl(fun:fun;xn,xk,e:extended; m: word; Mmo1 : TMemo);
implementation
   procedure Tabl (fun:fun;xn,xk,e:extended; m: word; Mmo1 : TMemo);
   var x,h,y:Extended;
   begin
     x:=xn;
     h:=(xk-xn)/m;
     repeat
      y:=fun(x);
      mmo1.Lines.Add('при x='+floattostrf(x,ffFixed,6,2)+' y='+floattostrf(y,ffFixed,8,4));
      x:=x+h;
     until x>(xk+h/2);
   end;
end.
 