unit Unit2;

interface
uses sysutils, Graphics;
var   ColrBack:Tcolor;
 Type 
  Tviz=class(Tobject)   // Абстрактный родительский класс 
    ColrLine : Tcolor;    
    Canvas : Tcanvas; 
    x, y, r : word; 
    Procedure Ris;virtual;abstract;   // Перекрываемый метод для рисования 
    Procedure Draw(bl:boolean);    
    procedure Show;  // Показать изображение 
    procedure Hide;    // Стереть изображение 
    procedure MovTo(dx,dy,dr:integer);  // Сдвинуть и изменить размер  
       end; 
  TKrug=class(Tviz)   // Класс рисования круга 
    x1,y1,x2,y2:word; 
    Constructor Create(x0,y0,r0:word; colrLine0:Tcolor;canvas0:Tcanvas); 
    Procedure Ris; override; 
        end; 
  TKvad=class(Tkrug)   // Класс рисования квадрата 
    Procedure Ris; override; 
        end; 
  TKrPr=class(Tkrug)   // Класс рисования круга на квадрате 
    dy1:word; 
    Constructor Create(x0,y0,r0,dy0:word; colrLine0:Tcolor;canvas0:Tcanvas); 
    Procedure Ris; override; 
        end;
implementation
  Procedure Tviz.Draw; // В зависимости от значения булевой  
    begin     // переменной этот метод рисует картинки Ris 
    with Canvas do begin  // либо цветом линии, либо цветом фона. 
    if bl then begin   // В последнем случае происходит стирание 
            pen.color:=colrLine;     brush.color:=colrLine  
                    end 
           else begin 
            pen.color:=colrBack;     brush.color:=colrBack 
                  end; 
      Ris;       // Процедура ris что-то рисует 
    end;     end; 
 
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
  x:=x+dx;  y:=y+dy;  r:=r+dr;   // Переход к новым координатам 
  Show; 
end; 
 
   Constructor TKrug.Create; // Начальные данные для рисования круга 
    begin         // они такие-же как и для рисования квадрата, 
    colrLine:=colrLine0;  // поэтому класс Tkvad наследует его 
    canvas:=canvas0; 
     x:=x0; y:=y0; r:=r0; 
    end; 
 
  Procedure Tkrug.Ris;  // Рисование круга 
  Begin 
 x1:=x-r;  x2:=x+r;  y1:=y-r;  y2:=y+r; 
  Canvas.Ellipse(x1,y1,x2,y2); 
  end; 
 
  Procedure Tkvad.ris;  // Рисование квадрата 
  Begin 
 x1:=x-r;  x2:=x+r;  y1:=y-r;  y2:=y+r; 
  Canvas.Rectangle(x1,y1,x2,y2); 
  end; 
 
  Constructor TKrpr.Create;  // Начальные данные для рисования круга 
    Begin      // на квадрате 
  dy1:=dy0; 
  Inherited Create(x0,y0,r0,colrLine0,canvas0); // Используется метод TKrug 
  end; 
 
  Procedure TkrPr.Ris;  // Рисование квадрата под кругом 
     begin 
     Inherited ris; // Используется родительский метод рисования круга
      Canvas.Rectangle(x1,y2,x2,y2+dy1);
     end;
end.
 