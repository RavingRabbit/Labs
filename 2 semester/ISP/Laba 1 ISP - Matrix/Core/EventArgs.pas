unit EventArgs;

interface

type
      Predicate = function(const obj: TObject): Boolean of object;

      TEventArgs = class
      public
            constructor Create();
      end;

      TNotifyProperty = procedure(sender: TObject; e: TEventArgs) of object;

implementation

constructor TEventArgs.Create();
begin
      inherited;
end;

end.
