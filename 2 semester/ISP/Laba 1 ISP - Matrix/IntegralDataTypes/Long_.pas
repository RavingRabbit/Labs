unit Long_;

interface

uses
      Object_, SysUtils;

type
      Long = class(TObject_)
      private
            _value: Int64;
      protected
            function CoreToString(): string; override;
      public
            constructor Create(value: Int64);
      public
            property Value: Int64 read _value;
      end;

implementation

constructor Long.Create(value: Int64);
begin
      _value := value;
end;

function Long.CoreToString(): string;
begin
      Result := IntToStr(_value);
end;

end.

