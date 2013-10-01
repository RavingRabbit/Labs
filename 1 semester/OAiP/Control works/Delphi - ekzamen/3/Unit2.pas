unit Unit2;

interface
uses Graphics;
type

   tviz=class(Tobject)
      x,y,r:Integer;
      krcolor,kvcolor,bgcolor:Tcolor;
      canvas:Tcanvas;
      procedure ris; virtual;abstract;
      procedure draw(bl:boolean);
      procedure show;
      procedure hide;
      procedure moveto(dx,dy,dr:integer);
   end;

   tzad=class(Tviz)
      constructor Create(x0,y0,r0:integer;canvas0:Tcanvas);
      procedure ris; override;
   end;


implementation

procedure Tviz.draw;
begin
   if bl then
   begin
      krcolor:=clred;
      kvcolor:=clgreen;
      canvas.Pen.Color:=clblack;
   end
   else
   begin
      krcolor:=bgcolor;
      kvcolor:=bgcolor;
      canvas.Pen.Color:=bgcolor;
   end;
   ris;
end;

Procedure Tviz.show;
begin
   draw(true);
end;

Procedure Tviz.hide;
begin
   draw(False);
end;

procedure Tviz.moveto;
begin
   hide;
   x:=x+dx;
   y:=y+dy;
   r:=r+dr;
   show;
end;


constructor Tzad.Create;
begin
   inherited create;
   x:=x0;
   y:=y0;
   r:=r0;
   canvas:=canvas0;
   bgcolor:=clwhite;
end;

procedure Tzad.ris;
var kvr:integer;
begin
   canvas.Brush.Color:=krcolor;
   canvas.Ellipse(x-r,y-r,x+r,y+r);
   canvas.Brush.Color:=kvcolor;
   kvr:=round(r/sqrt(2));
   canvas.Rectangle(x-kvr,y-kvr,x+kvr,y+kvr);
end;



end.
 
