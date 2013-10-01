unit Object_;

interface

type
      TObject_ = class
      protected
            function CoreToString(): string; virtual; abstract;
      public
            constructor Create();
            destructor Destroy(); override;
      public
            function ToString(): string;
      end;

      TObjectType = class of TObject_;

implementation

constructor TObject_.Create();
begin
      inherited;
end;

destructor TObject_.Destroy();
begin
      inherited;
end;

function TObject_.ToString(): string;
begin
      Result := Self.CoreToString();
end;

end.
