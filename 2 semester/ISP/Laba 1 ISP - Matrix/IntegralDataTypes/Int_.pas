unit Int_;

interface

uses
      Object_, SysUtils;

type
      Int = class(TObject_)
      private
            _value: Integer;
      protected
            function CoreToString(): string; override;
      public
            constructor Create(value: Integer);
      public
            property Value: Integer read _value;
      end;

implementation

constructor Int.Create(value: Integer);
begin
      _value := value;
end;

function Int.CoreToString(): string;
begin
      Result := IntToStr(_value);
end;

end.
