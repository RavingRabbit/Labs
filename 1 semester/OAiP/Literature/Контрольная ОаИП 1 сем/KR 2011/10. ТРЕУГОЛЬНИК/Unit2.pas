unit Unit2;

interface
uses sysutils, ExtCtrls, StdCtrls, Classes, Graphics;
procedure treug(x1,x2,x3,y1,y2,y3,h:extended; var img1:Timage);
implementation
procedure treug;
var s:extended; xo,yo:integer;
begin
  img1.Picture:=nil;
  xo:=img1.Width div 2;
  yo:=img1.Height;
  with img1.canvas do begin
    brush.Color:=Clyellow;
    rectangle(0,0,img1.width,img1.height);
    pen.Color:=ClBlue;
    brush.Color:=ClBlue;
    polygon([point(round(x1*h),yo-round(y1*h)),point(round(x2*h),yo-round(y2*h)),point(round(x3*h),yo-round(y3*h))]);
    font.Size:=12;
    font.Color:=clBlack;
    textout(20,20,'asdfgh');
  end;

end;

end.
 