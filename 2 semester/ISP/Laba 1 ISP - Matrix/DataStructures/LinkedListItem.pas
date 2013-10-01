unit LinkedListItem;

interface

uses
      Object_;

type
      {* Внутреннее представление *}
      TLinkedListItem = class
      private
            _obj: TObject_;
            _next: TLinkedListItem;
            _prev: TLinkedListItem;
      public
            constructor Create(const obj: TObject_);
            destructor Destroy(); override;
      public
            property Obj: TObject_ read _obj write _obj;
            {* Следующий элемент *}
            property Next: TLinkedListItem read _next write _next;
            {* Предыдущий элемент *}
            property Prev: TLinkedListItem read _prev write _prev;
      end;

implementation

constructor TLinkedListItem.Create(const obj: TObject_);
begin
      _obj := obj;
      _next := nil;
      _prev := nil;
end;

destructor TLinkedListItem.Destroy();
begin
      if (_next <> nil) then
      begin
            if (_next <> Self) then
            begin
                  _next.Free();
            end;
            _next := nil;
            _prev := nil;
      end;
      inherited;
end;

end.
