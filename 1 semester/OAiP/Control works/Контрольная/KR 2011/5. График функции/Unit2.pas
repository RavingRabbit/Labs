unit Unit2;

interface
uses  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls;
type func = function(x:extended):extended;
procedure graf(a,b:extended; n:integer; fun:func; img1:Timage);
implementation
procedure graf;
var h,y,x,kx,ky:extended;  xmax,ymax,o:integer;
begin
   img1.Picture:=nil;
   h:=(b-a)/n;
   xmax:=img1.Width;
   ymax:=img1.Height;
   o:=20;
   kx:=(b-a)/(xmax-2*o);
   ky:=(fun(b)-fun(a))/(ymax-2*o);
   x:=a;
   y:=fun(x);
   with img1.Canvas do begin
   pen.Width:=3;
   pen.color:=clred;
   moveto(o+round(x/kx),ymax-o-round(y/ky));
   while x<b do begin
    x:=x+h;
    y:=fun(x);
    lineto(o+round(x/kx),ymax-o-round(y/ky));
   end;

   pen.Width:=2;
   pen.color:=clblack;
   moveto(20,ymax-20);
   lineto(20,20);
   moveto(20,ymax-20);
   lineto(xmax-20,ymax-20);
   font.Size:=15;
   textout(xmax-40,ymax-20,'X');
   textout(5,20,'Y');
   end;
end;
end.
