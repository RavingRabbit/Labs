unit LinkedListEventArgs;

interface

uses
      Object_, EventArgs;


type
      TLinkedListEventArgs = class(TEventArgs)
      private
            _obj: TObject_;
      public
            constructor Create(const obj: TObject_);
      public
            property Obj: TObject_ read _obj;
      end;

implementation

constructor TLinkedListEventArgs.Create(const obj: TObject_);
begin
      _obj := obj;
end;

end.
