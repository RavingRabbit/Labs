unit LinkedList;

interface

uses
      Object_,
      LinkedListItem,
      LinkedListIterator,
      LinkedListException,
      LinkedListEventArgs,
      EventArgs,
      SysUtils,
      Cell;

type
      SortDirection = function(a, b: TObject_): boolean;

      {* Двусвязный список *}
      TLinkedList = class(TObject_)
      private
            {* начало списка *}
            _head: TLinkedListItem;
            {* конец списка *}
            _teil: TLinkedListItem;
            {* количество *}
            _count: Integer;
            {* Тип данных, хранящихся в списке *}
            _underlyingType: TObjectType;
      private
            _pushedEvent: TNotifyProperty;
            _popedEvent: TNotifyProperty;
      private
            {* Возвращает True, если objType является _underlyingType, либо наследует от _underlyingType *}
            function IsValidType(objType: TClass): Boolean;
            function GetIsEmpty(): Boolean;
            procedure DecCount();
            {* Добавляет элемент в пустой список *}
            procedure PushIntoEmpty(const obj: TObject_);
      protected
            function CoreToString(): string; override;
            procedure OnPushed(const obj: TObject_); virtual;
            procedure OnPoped(const obj: TObject_); virtual;
      public
            {* Конструктор *}
            constructor Create(underlyingType: TObjectType);
            {* Деструктор *}
            destructor Destroy(); override;
      public
            {* Возвращает последний элемент списка *}
            function PeekBack(): TObject_;
            {* Возвращает первый элемент списка *}
            function PeekFront(): TObject_;
            {* Добавляет элемент в конец списка*}
            function PushBack(const obj: TObject_): TLinkedList;
            {* Добавляет элемент в начало списка *}
            function PushFront(const obj: TObject_): TLinkedList;
            {* Удаляет последний элемент списка *}
            function PopBack(): TObject_;
            {* Удаляет первый элемент списка *}
            function PopFront(): TObject_;
            {* Возвращает True в случае присутсвия элементов x таких, что p(x) = True. *}
            function Contains(const p: Predicate): Boolean;
            {* Возвращает список элементов x таких, что p(x) = True. *}
            function Filter(const p: Predicate): TLinkedList;
            {* Возвращает итератор *}
            function GetIterator(): TLinkeListIterator;
            procedure SortBubble(Order: SortDirection);
      public
            property Count: Integer read _count;
            property UnderlyingType: TObjectType read _underlyingType;
            property IsEmpty: Boolean read GetIsEmpty;
      public
            {* События *}
            property Pushed: TNotifyProperty read _pushedEvent write _pushedEvent;
            property Poped: TNotifyProperty read _popedEvent write _popedEvent;
      public
            class function Combine(left: TLinkedList; right: TLinkedList): TLinkedList;
            property ToString: String read coreToString;
      end;

implementation

procedure TLinkedList.SortBubble(Order: SortDirection);
  var
    rab, item: TLinkedListItem;
    obj: TObject_;
begin
  rab := _head;
  while (rab <> nil) do
    begin
      item := rab.Next;
      while (item <> nil) do
        begin
          if Order(item.Obj, rab.Obj) then
          begin
            obj := item.Obj;
            item.Obj := rab.Obj;
            rab.Obj := obj;
          end;
          item := item.Next;
        end;
      rab := rab.Next;
    end;
end;

constructor TLinkedList.Create(underlyingType: TObjectType);
begin
      _head := nil;
      _teil := nil;
      _count := 0;
      _underlyingType := underlyingType;
end;

destructor TLinkedList.Destroy();
begin
      if (_head <> nil) then
      begin
            _head.destroy();
            _head := nil;
            _teil := nil;
      end;
      inherited;
end;

function TLinkedList.IsValidType(objType: TClass): Boolean;
var
      x: TClass;
begin
      x := objType;
      while (x.ClassParent <> TObject) do
      begin
            if (x = _underlyingType) then
            begin
                  Result := True;
                  Exit;
            end;
            x := x.ClassParent;
      end;
      Result := False;
end;

function TLinkedList.GetIsEmpty(): Boolean;
begin
      Result := (_count = 0);
end;

function TLinkedList.PeekBack(): TObject_;
begin
      if (not Self.IsEmpty) then
      begin
            Result := _teil.Obj;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

function TLinkedList.PeekFront(): TObject_;
begin
      if (not Self.IsEmpty) then
      begin
            Result := _head.Obj;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

function TLinkedList.PushBack(const obj: TObject_): TLinkedList;
begin
      if (IsValidType(obj.ClassType)) then
      begin
            if (IsEmpty) then
            begin
                  PushIntoEmpty(obj);
            end
            else begin
                  _teil.Next := TLinkedListItem.Create(obj);
                  _teil.Next.Prev := _teil;
                  _teil := _teil.Next;
            end;
            Inc(_count);
            OnPushed(obj);
            Result := Self;
      end
      else begin
            raise ELinkedListException.Create(
                        Format('Incorrect Data Type ''%s''', [obj.ClassName]));
      end;
end;

function TLinkedList.PushFront(const obj: TObject_): TLinkedList;
begin
      if (IsValidType(obj.ClassType)) then
      begin
            if (IsEmpty) then
            begin
                  PushIntoEmpty(obj);
            end
            else begin
                  _head.Prev := TLinkedListItem.Create(obj);
                  _head.Prev.Next := _head;
                  _head := _head.Prev;
            end;
            Inc(_count);
            OnPushed(obj);
            Result := Self;
      end
      else begin
            raise ELinkedListException.Create(
                        Format('Incorrect Data Type ''%s''', [obj.ClassName]));
      end;
end;

procedure TLinkedList.DecCount();
begin
      Dec(_count);
      if (_count = 0) then
      begin
            _head := nil;
            _teil := nil;
      end;
end;

procedure TLinkedList.PushIntoEmpty(const obj: TObject_);
begin
      _head := TLinkedListItem.Create(obj);
      _teil := _head;
end;

function TLinkedList.PopBack(): TObject_;
var
      obj: TObject_;
begin
      if (not Self.IsEmpty) then
      begin
            obj := PeekBack();
            if (_teil <> _head) then
            begin
                  _teil := _teil.Prev;
                  _teil.Next.Prev := nil;
                  _teil.Next.Free();
                  _teil.Next := nil;
            end
            else begin
                  _teil.Free();
            end;
            DecCount();
            OnPoped(obj);
            Result := obj;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

function TLinkedList.PopFront(): TObject_;
var
      obj: TObject_;
begin
      if (not Self.IsEmpty) then
      begin
            obj := PeekFront();
            if (_head <> _teil) then
            begin
                  _head := _head.Next;
                  _head.Prev.Next := nil;
                  _head.Prev.Free();
                  _head.Prev := nil;
            end
            else begin
                  _head.Free();
            end;
            DecCount();
            OnPoped(obj);
            Result := obj;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

function TLinkedList.Contains(const p: Predicate): Boolean;
var
      x: TLinkedListItem;
begin
      x := _head;
      while (x <> nil) do
      begin
            if (p(x.Obj)) then
            begin
                  Result := True;
                  Exit;
            end;
            x := x.Next;
      end;
      Result := False;
end;

function TLinkedList.Filter(const p: Predicate): TLinkedList;
var
      x: TLinkedListItem;
begin
      Result := TLinkedList.Create(Self.UnderlyingType);
      x := _head;
      while (x <> nil) do
      begin
            if (p(x.Obj)) then
            begin
                  Result := Result.PushBack(x.Obj);
            end;
            x := x.Next;
      end;
end;

function TLinkedList.GetIterator(): TLinkeListIterator;
begin
      Result := TLinkeListIterator.Create(_head);
end;

class function TLinkedList.Combine(left: TLinkedList; right: TLinkedList): TLinkedList;
      procedure Append(var dst: TLinkedList; const src: TLinkedList);
      var
            x: TLinkedListItem;
      begin
            x := src._head;
            while (x <> nil) do
            begin
                  dst := dst.PushBack(x.Obj);
                  x := x.Next;
            end;
      end;
begin
      if (left.UnderlyingType = right.UnderlyingType) then
      begin
            Result := TLinkedList.Create(left.UnderlyingType);
            Append(Result, left);
            Append(Result, right);
      end
      else begin
            raise ELinkedListException.Create(
                        Format('The type ''%s'' does not match to the type ''%s''',
                              [left.UnderlyingType.ClassName, right.UnderlyingType.ClassName]));
      end;
end;

function TLinkedList.CoreToString(): string;
var
      x: TLinkedListItem;
begin
      Result := '';
      x := _head;
      while (x <> nil) do
      begin
            Result := Result + x.Obj.ToString();
            if (x.Next <> nil) then
            begin
                  Result := Result + ', ';
            end;
            x := x.Next;
      end;
      Result := Result;

end;

procedure TLinkedList.OnPushed(const obj: TObject_);
begin
      if (Assigned(_pushedEvent)) then
      begin
            _pushedEvent(Self, TLinkedListEventArgs.Create(obj));
      end;
end;

procedure TLinkedList.OnPoped(const obj: TObject_);
begin
      if (Assigned(_popedEvent)) then
      begin
            _popedEvent(Self, TLinkedListEventArgs.Create(obj));
      end;
end;

end.
