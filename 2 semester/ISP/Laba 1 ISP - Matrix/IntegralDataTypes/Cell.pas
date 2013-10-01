unit Cell;

interface

uses
      Object_, SysUtils;

type
      TCell = class(TObject_)
      private
            _rowIndex, _colIndex: Integer;
            _value: Integer;
      private
            function CoreToString(): string; override;
      public
            constructor Create(rowIndex, colIndex: Integer; value: Integer);
      public
            property Value: Integer read _value write _value;
            property RowIndex: Integer read _rowIndex write _rowIndex;
            property ColIndex: Integer read _colIndex write _colIndex;
            class function GetEmptyCell(): TCell;
      end;

implementation

var
  EmptyCell_: TCell;

constructor TCell.Create(rowIndex, colIndex, value: integer);
begin
      inherited create;
      _value := value;
      _rowIndex := rowIndex;
      _colIndex := colIndex;
end;

function TCell.CoreToString(): string;
begin
      Result := '['+IntToStr(_rowIndex)+','+IntToStr(_colIndex)+']='+IntToStr(_value); //[i,j]=val
end;

class function TCell.GetEmptyCell(): TCell;
begin
  Result := EmptyCell_;
end;

initialization
  EmptyCell_ := TCell.Create(-1, -1, 0);

finalization
  EmptyCell_.Free();

end.
