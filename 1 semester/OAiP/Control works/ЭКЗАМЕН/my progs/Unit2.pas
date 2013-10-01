unit Unit2;

interface
uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs;
var
colorback:Tcolor;

  type
  tabs=class(tobject)
  colorln: TColor;
  canvas: tcanvas;
  x,y,r: word;
  procedure draw(b:boolean);
  procedure ris(); virtual; abstract;
  procedure show;
  procedure hide;
  procedure moveto(dx,dy:integer);
  end;

  Tclass=class(tabs)
  constructor create(x0,y0,r0:word;colorln0:tcolor;canvas0: tcanvas);
  procedure ris(); override;
  end;

implementation
constructor tclass.create(x0,y0,r0:word;colorln0:tcolor;canvas0: tcanvas);
begin
 x:=x0;
 y:=y0;
 r:=r0;
 colorln:=colorln0;
 canvas:=canvas0;
end;

procedure tabs.draw(b:boolean);
begin
 with canvas do
  if b then begin pen.color:=colorln; brush.color:=colorln; end
  else begin
            pen.Color:=ColorBack;
            brush.Color:=ColorBack;
  end;
ris();
end;

procedure tclass.ris();
begin
Canvas.Ellipse(x-r, y-r, x+r, y+r);
end;

procedure tabs.show;
begin
draw(true);
end;

procedure tabs.hide;
begin
draw(false);
end;

procedure tabs.moveto(dx,dy:integer);
begin
hide();
y:=y+dy;
x:=x+dx;
show();
end;

end.
 