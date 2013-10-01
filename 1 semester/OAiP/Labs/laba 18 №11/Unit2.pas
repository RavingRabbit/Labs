unit Unit2;

interface
uses Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, Buttons, StdCtrls, ComCtrls;
type
  Tflight = record
    Number:Integer;
    Destination:string;
    end;
  Ttree = ^tree;
  tree = record
    flight:Tflight;
    A1:Ttree;
    A2:Ttree;
    end;
  Class_tree = class
    N_flights:Word;
    Array_of_flights:array of Tflight;
    tree:Ttree;
    procedure create_sheet(var p:Ttree; flight:Tflight); //create a new sheet
    procedure add_sheet(flight:Tflight); //add sheet to the tree
    procedure read_spreadsheet(StringGrid:TStringGrid);
    procedure Enter_tree(); //convert an array into a tree
    procedure delete_tree(var p:Ttree);
    procedure display_tree(p:Ttree; var kl:Integer; var TreeView:TTreeView);
    procedure display_tree_memo(p:Ttree; var memo:Tmemo);
    function find(k:Integer):string;
    procedure delete_sheet(k:integer);
    procedure count(p:Ttree; ch:char; var N:integer);
    end;

implementation

procedure class_tree.create_sheet(var p:Ttree; flight:Tflight);
begin
  New(p);
  p^.flight:=flight;
  p^.A1:=nil;
  p^.A2:=nil;
end;

procedure class_tree.add_sheet(flight:Tflight);
var p,q:Ttree; bl:Boolean;
begin
  p:=tree;
  While p<>Nil do
    begin
      q:=p;
      bl:=flight.number < p^.flight.number;
      if bl then p:=p^.A1 else p:=p^.A2;
    end;
  create_sheet(p,flight); if bl then q^.A1:=p else q^.A2:=p;
end;

procedure Class_tree.read_spreadsheet(StringGrid:TStringGrid);
var i:word;
begin
  SetLength(Array_of_flights, N_flights+1);
  try
    for i:=1 to N_flights do
      begin
        Array_of_flights[i].Number:=StrToInt(StringGrid.Cells[0,i]);
        Array_of_flights[i].Destination:=StringGrid.Cells[1,i];
      end;
  except ShowMessage('Fill in the table') end;
  Enter_tree;
end;

procedure class_tree.Enter_tree();
  Function BL(i,j:Word):Ttree;
  Var p:Ttree; m:Word;
	  begin
		  if i>j then p:=Nil
		  else
        begin
			    m:=(i+j) div 2;
			    New(p); p^.flight:=Array_of_flights[m];
			    p^.A1:=BL(i,m-1);
			    p^.A2:=BL(m+1,j);
			  end;
		  result:=p;
	  end;
begin
  tree:=BL(1,N_flights);
end;

procedure class_tree.delete_tree(var p:Ttree);
begin
  if p<>nil then
    begin
      delete_tree(p^.A1);
      delete_tree(p^.A2);
      Dispose(p);
      p:=nil;
    end;
end;

procedure class_tree.display_tree(p:Ttree; var kl:Integer; var TreeView:TTreeView);
begin
  if p <> Nil then
    begin
      if kl=-1 then
        TreeView.Items.AddFirst(Nil, p^.flight.destination+' '+IntToStr(p^.flight.number))
      else
        TreeView.Items.AddChildFirst(TreeView.Items[kl], p^.flight.destination+' '+IntToStr(p^.flight.number));
      Inc(kl);
      display_tree(p^.A1,kl,TreeView);
      display_tree(p^.A2,kl,TreeView);
      Dec(kl);
    end;
end;

procedure class_tree.display_tree_memo(p:Ttree; var memo:Tmemo);
begin
  if p<>nil then
    begin
      memo.lines.add(p^.flight.destination+'  '+inttostr(p^.flight.number));
      display_tree_memo(p^.A1, memo);
      display_tree_memo(p^.A2, memo);
    end;
end;

function class_tree.find(k:Integer):string;
var P:Ttree; 
begin p:=tree;
  While(p<>Nil) and (p^.flight.number<>k) do
    if k<p^.flight.number then p:=p^.A2 else p:=p^.A1;
    if p<>Nil then result:=p^.flight.destination
      else result:='not found';
end;

procedure class_tree.delete_sheet(k:integer);
var v,w,q,p:Ttree;
begin
  p:=tree;
  while (p<>Nil) and (p^.flight.number<>k) do
		begin
      q:=p;
        if p^.flight.number>k then p:=p^.A1
        else p:=p^.A2;
		end;
	if p<>Nil then
    begin
	    if p=tree then
        begin
          New(q); q^.A1:=p;
        end;
	    if (p^.A1=Nil) and (p^.A2=Nil) then
	      if q^.A1=P then q^.A1:=Nil
			  else q^.A2:=Nil
	    else
	      if P^.A1=Nil then
	        if q^.A1=P then q^.A1:=p^.A2
				  else q^.A2:=p^.A2
	      else
          if p^.A2=Nil then
	          if q^.A1=P then q^.A1:=p^.A1
				    else q^.A2:=p^.A1
	        else
		        begin
		          w:=p^.A1;
              if w^.A2=Nil then w^.A2:=p^.A2
		          else
                begin
			            Repeat
                    v:=w; w:=w^.A2;
			            Until w^.A2=Nil;
			            v^.A2:=w^.A1;
			            w^.A1:=p^.A1;
			            w^.A2:=p^.A2;
			          end;
		          if q^.A1=P then q^.A1:=w
					    else q^.A2:=w;
		        end;
	    if p=tree then
        begin
          tree:=q^.A1; Dispose(q);
        end;
	    Dispose(p);
    end;
end;


procedure class_tree.count(p:Ttree; ch:char; var N:integer);
begin
  if p<>nil then
    begin
      if p^.flight.Destination[1]=ch then inc(N);
      count(p^.A1,ch,N);
      count(p^.A2,ch,N);
    end;
end;

end.
