unit Unit2;

interface

uses
  SysUtils, Dialogs, StdCtrls;

Type  TSel=^Sel;
      Sel=record
		    Inf:integer;
		    A1:TSel;
		    A2:TSel;
		  end;
      TList=class(Tobject)
        sp1,spk,sp,sr:TSel;
        b1,bk:boolean;
        N0:integer;
        constructor create;
        procedure Add1(inf:integer);
        procedure Addk(inf:integer);
        procedure Read1(var inf:integer);
        procedure Readk(var inf:integer);
        procedure Print1(lst:Tlistbox);
        procedure Printk(lst:Tlistbox);
        procedure AddBefore(inf:integer; N:integer);
        procedure AddAfter(inf:integer; N:integer);
        procedure Size;
        procedure Delete_identical(N:Integer);
	    end;
      procedure SortSlip(var tp:TList);
      procedure Div2SP(var tp,tq,tr:TList);
implementation

constructor TList.Create;
begin
  Inherited create;
  New(sp1);
  New(spk);
  sp1:=Nil;
  spk:=Nil;
end;

procedure TList.Add1;
begin
  New(sp);
  sp.Inf:=inf;
  sp^.A2:=Nil;
  sp^.A1:=Nil;
  if sp1=Nil then
    begin
      sp1:=sp;
      spk:=sp;
    end
  else
    begin
      sp^.A2:=sp1;
      sp1^.A1:=sp;
      sp1:=sp;
    end;
end;

procedure TList.Addk;
begin
  New(sp);
  sp.inf:=inf;
  sp^.A2:=Nil;
  sp^.A1:=Nil;
  if sp1=Nil then
    begin
      sp1:=sp;
      spk:=sp;
    end
  else
    begin
      spk^.A2:=sp;
      sp^.A1:=spk;
      spk:=sp;
    end;
end;

procedure TList.Read1;
begin
  if spk=Nil then
    begin
      ShowMessage('Список пуст');
      b1:=false;
    end
  else
    begin
      b1:=true;
      if spk<>sp1 then
        begin
          sp:=sp1;
          inf:=sp^.inf;
          sp^.A2^.A1:=Nil;
          sp1:=sp^.A2;
          Dispose(sp);
        end
      else
        begin
          sp:=spk;
          inf:=spk.inf;
          sp1:=Nil;
          spk:=Nil;
        end;
    end;
end;

procedure TList.Readk;
begin
  if sp1=Nil then
    begin
      ShowMessage('Список пуст');
      bk:=false;
    end
  else
    begin
      bk:=true;
      if spk<>sp1 then
        begin
          sp:=spk;
          inf:=sp^.inf;
          sp^.A1^.A2:=Nil;
          spk:=sp^.A1;
          Dispose(sp);
        end
      else
        begin
          sp:=sp1;
          inf:=sp1.inf;
          sp1:=Nil;
          spk:=Nil;
        end;
    end;
end;

procedure TList.Size;
begin
  N0:=0;
  sp:=sp1;
  while sp<>Nil do
    begin
      sp:=sp^.A2;
      Inc(N0);
    end;
end;

procedure TList.AddAfter;
var k:integer;
    spi:TSel;
begin
  if N=0 then
    Add1(inf);
  if N=N0 then
    Addk(inf)
  else
    begin
      if N<0 then
        ShowMessage('Введите N>=0');
      if N>N0 then
        ShowMessage('Введите N<='+IntToStr(N0));
      if (N>0) and (N<N0) then
        if sp1=Nil then
          ShowMessage('Список пуст')
        else
          begin
            k:=1;
            spi:=sp1;
            while (k<>N) and (spi<>Nil) do
              begin
                spi:=spi^.A2;
                Inc(k);
              end;
            New(sp);
            sp^.Inf:=Inf;
            sp^.A1:=spi;
            sp^.A2:=spi.A2;
            spi^.A2:=sp;
            sp^.A2^.A1:=sp;
          end;
    end;
end;

procedure TList.AddBefore;
var k:integer;
    spi:TSel;
begin
  if N=1 then
    Add1(inf);
  if N=N0+1 then
    Addk(inf)
  else
    begin
      if N<1 then
        ShowMessage('Введите N>=1');
      if N>N0+1 then
        ShowMessage('Введите N<='+IntToStr(N0+1));
      if (N>1) and (N<N0+1) then
        if sp1=Nil then
          ShowMessage('Список пуст')
        else
          begin
            k:=1;
            spi:=sp1;
            while (k<>N) and (spi<>Nil) do
              begin
                spi:=spi^.A2;
                Inc(k);
              end;
            New(sp);
		        sp^.Inf:=Inf;
		        sp^.A2:=spi;
		        sp^.A1:=spi.A1;
		        spi^.A1:=sp;
		        sp^.A1^.A2:=sp;
          end;
    end;
end;

procedure TList.Printk;
begin
  if spk<>Nil then
    begin
      lst.items.Add(IntToStr(spk.inf));
      sp:=spk;
      while sp^.A1<>Nil do
        begin
          lst.items.Add(IntToStr(sp^.A1.inf));
          sp:=sp^.A1;
        end;
    end;
end;

procedure TList.Print1;
begin
  if sp1<>Nil then
    begin
      lst.items.Add(IntToStr(sp1.inf));
      sp:=sp1;
      while sp^.A2<>Nil do
        begin
          lst.items.Add(IntToStr(sp^.A2.inf));
          sp:=sp^.A2;
        end;
    end;
end;

procedure Div2SP;
var Inf:integer;
    bl:boolean;
begin
  tq:=Tlist.create;
  tr:=Tlist.create;
  bl:=true;
  while bl do
    begin
      tp.Read1(Inf);
      tq.Addk(Inf);
      bl:=(tp.sp1<>Nil);
      if bl then
        begin
          tp.Read1(Inf);
          tr.Addk(Inf);
          bl:=(tp.sp1<>Nil);
        end;
    end;
end;

procedure SortSlip;
  procedure Slip(var tq,tr,tp:TList);
  var Inf:integer;
  begin
    tp:=TList.Create;
    while (tq.sp1<>Nil) and (tr.sp1<>Nil) do
      if tq.sp1.Inf<tr.sp1.Inf  then
        begin
          tq.Read1(Inf);
          tp.Addk(Inf);
        end
      else
        begin
          tr.Read1(Inf);
          tp.Addk(Inf);
        end;
    while tq.sp1<>Nil do
      begin
        tq.Read1(Inf);
        tp.Addk(Inf);
      end;
    while tr.sp1<>Nil do
      begin
        tr.Read1(Inf);
        tp.Addk(Inf);
      end;
  end;
var tq,tr:Tlist;
begin
  if tp.sp1<>tp.spk then
    begin
      Div2sp(tp,tq,tr);
      SortSlip(tq);
	    SortSlip(tr);
	    Slip(tq,tr,tp);
    end;
end;

procedure TList.Delete_identical;
  function identical(x,N:Integer; A:array of integer):Boolean;
  var i:Integer;
  begin
    result:=False;
    for i:=1 to (N-1) do
      if x=A[i] then result:=True;

  end;
var A:array of integer; inf,x,i:Integer;
begin
  SetLength(A,N+1);
  read1(inf);
  A[1]:=inf;
  Addk(A[1]);
  for i:=2 to N do
    begin
      read1(inf);
      A[i]:=inf;
      if (not identical(A[i],i,A)) then Addk(A[i]);
    end;
end;
    
end.
