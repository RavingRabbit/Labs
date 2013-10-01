unit Unit2;

interface
uses Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls;
procedure Ellipse(R,x,y,h:extended; img1:Timage);
implementation
procedure Ellipse;
var xo,yo:integer;
begin
  with img1 do begin
  Picture:=nil;
  xo:=width div 2;
  yo:=height div 2;
  with canvas do begin
    brush.color:=clGreen;
    rectangle(0,0,width,height);
    pen.Width:=3;
    pen.color:=clRed;
    Ellipse(round(xo-r*h),round(yo-r*h),round(xo+r*h),round(yo+r*h));
    pen.color:=clBlack;
    Ellipse(round(xo+x*h-2),round(yo-y*h-2),round(xo+x*h+2),round(yo-y*h+2));
  end;
  end;
end;
end.
 