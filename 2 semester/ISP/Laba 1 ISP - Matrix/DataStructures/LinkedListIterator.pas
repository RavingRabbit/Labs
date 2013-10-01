unit LinkedListIterator;

interface

uses
      Object_, LinkedListItem, LinkedListException, SysUtils;

type
      {* Итератор *}
      TLinkeListIterator = class
      private
            _item: TLinkedListItem;
            _current: TLinkedListItem;
      private
            function GetIsDone(): Boolean;
            function GetObj(): TObject_;
      public
            constructor Create(const item: TLinkedListItem);
            destructor Destroy(); override;
      public
            {* Перемещает указатель *}
            procedure Next();
            {* Устанавливает указатель на начало списка *}
            procedure Reset();
      public
            {* Возвращает True, если достигнут конец списка *}
            property IsDone: Boolean read GetIsDone;
            property Current: TObject_ read GetObj;
      end;

implementation

constructor TLinkeListIterator.Create(const item: TLinkedListItem);
begin
      _item := item;
      _current := item;
end;

destructor TLinkeListIterator.Destroy();
begin
      inherited;
end;

procedure TLinkeListIterator.Next();
begin
      if (not IsDone) then
      begin
            _current := _current.Next;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

procedure TLinkeListIterator.Reset();
begin
      _current := _item;
end;

function TLinkeListIterator.GetIsDone(): Boolean;
begin
      Result := (_current = nil);
end;

function TLinkeListIterator.GetObj(): TObject_;
begin
      if (not IsDone) then
      begin
            Result := _current.Obj;
      end
      else begin
            raise ELinkedListException.Create(Format('Access violation exception', []));
      end;
end;

end.
