unit Unit2;

interface
uses SysUtils, Graphics, Classes;
var ColrBack:Tcolor;
Type
 Tviz=class(Tobject)   // Абстрактный родительский класс
  ColrLine : Tcolor;
  Canvas : Tcanvas;
  x, y, r1, r2 : word;
  Procedure Ris;virtual;abstract;   // Перекрываемый метод для рисования
  Procedure Draw(bl:boolean);
  procedure Show;  // Показать изображение
  procedure Hide;    // Стереть изображение
  procedure MovTo(dx,dy,dr:integer);  // Сдвинуть и изменить размер
  end;
 Tkvad=class(Tviz)   // Класс рисования квадрата
  x1,y1,x2,y2:word;
  Constructor Create(x0,y0,r01,r02:word; colrLine0:Tcolor;canvas0:Tcanvas);
  Procedure Ris; override;
  end;
 TTrPr=class(Tkvad)   // Класс рисования треугольника
  Constructor Create(x0,y0,r01,r02:word; colrLine0:Tcolor;canvas0:Tcanvas);
  Procedure Ris; override;
  end;
implementation

Constructor Tkvad.Create;
begin
 canvas:=canvas0;
 colrLine:=colrLine0;
 x:=x0; y:=y0;
 r1:=r01; //полширины прямоугольника
 r2:=r02; //полвысоты прямоугольника
end;

Procedure Tkvad.ris;  // Рисование квадрата
Begin
 x1:=x-r1;  x2:=x+r1;
 y1:=y+2*r2;  y2:=y;
 Canvas.Rectangle(x1,y1,x2,y2);
end;

Constructor TTrPr.Create;
begin
 Inherited Create(x0,y0,r01,r02,colrLine0,canvas0);
 colrLine:=colrLine0;
 canvas:=canvas0;
 x:=x0; y:=y0; r1:=r01; r2:=r02;
end;

Procedure TTrPr.Ris;  // Рисование дома
Begin
 Inherited ris;
 x1:=x-r1;  x2:=x+r1;  y1:=y;  y2:=y;
 Canvas.Polygon([point(x1,y1),point(x,y-round(1.5*r2)),point(x2,y1)]);
end;

Procedure Tviz.Draw; // В зависимости от значения булевой
begin     // переменной этот метод рисует картинки Ris
 with Canvas do
  begin  // либо цветом линии, либо цветом фона.
   if bl then
    begin   // В последнем случае происходит стирание
     pen.color:=colrLine;
     brush.color:=colrLine;
    end
   else
    begin
     pen.color:=colrBack;
     brush.color:=colrBack
    end;
   Ris; //Процедура ris что-то рисует (с)кэп
  end;
end;

Procedure Tviz.Show;
begin
 Draw(true);
end;

Procedure Tviz.Hide;
begin
 Draw(false);
end;

procedure Tviz.MovTo;
begin
 Hide;
 x:=x+dx; y:=y+dy; r1:=r1+dr; r2:=r2+dr;// Переход к новым координатам
 Show;
end;
end.
 