unit Matrix;

interface

uses Row, Cell, LinkedList, LinkedListIterator, sysutils;

type
  TMatrix = class
  private
    _matrix: array of TRow;
    _rowCount, _colCount: integer;
    procedure Add(rowIndex, colIndex: Integer; value: Integer);
    function GetCellValueByIndex(rowIndex, colIndex: Integer): Integer;
  public
    constructor Create(rowCount, colCount: Integer);
    destructor Destroy(); override;
    function Summarize(Matrix: TMatrix): Tmatrix;
    function Transpose(): Tmatrix;
    function Multiply(Matrix: TMatrix): Tmatrix;
    function ToString(): string;
    property RowCount: Integer read _rowCount;
    property ColCount: Integer read _colCount;
    property Data[i,j: Integer]: Integer read GetCellValueByIndex write Add; default;
  end;

implementation

function TMatrix.Multiply(Matrix: TMatrix): TMatrix; //умножаем Self на Matrix
var i,j,k,s: Integer; NewMatrix: TMatrix;
begin
  if (_colCount = Matrix.rowCount) then
    begin
      NewMatrix := TMatrix.create(_rowcount, Matrix._colCount);
      for i:=1 to _rowCount do
        for j:=1 to Matrix.colCount do
          begin
            s := 0;
            for k:=1 to Matrix.rowCount do
              s := s + Self[i,k]*Matrix[k,j];
            NewMatrix[i,j] := s;
          end;
      result := NewMatrix;
    end
  else
    result := Nil;
end;

function TMatrix.Summarize(matrix: TMatrix): Tmatrix;
var i: integer; resultMatrix: TMatrix;
begin
  if ((_rowcount <> matrix.rowCount) or (_colcount <> matrix.colCount)) then
      result := Nil
  else
    begin
      resultMatrix := TMatrix.create(_rowcount, _colcount);
      for i := 1 to rowCount do
        resultMatrix._matrix[i] := _matrix[i].summarize(matrix._matrix[i]);
      Result := resultMatrix;
    end;
end;

function TMatrix.Transpose(): Tmatrix;
var i, tmp: integer; Cell: TCell; NewMatrix: TMatrix; iterator: TLinkeListIterator;
begin
  NewMatrix := TMatrix.create(_colCount, _rowCount);
  for i := 1 to _rowCount do
    begin
      iterator := _matrix[i].getRow.GetIterator();
      while (not iterator.IsDone) do
        begin
          Cell := iterator.Current as TCell;
          tmp := Cell.rowIndex;
          Cell.rowIndex := Cell.colIndex;
          Cell.colIndex := tmp;
          NewMatrix[Cell.rowIndex, Cell.colIndex] := Cell.value;
          iterator.Next();
        end;
    end;
  result := NewMatrix;
end;

function TMatrix.ToString(): string;
var i: Integer;
begin
  for i := 1 to rowCount do
    begin
      if not _matrix[i].IsEmpty then
          result := result + _matrix[i].ToString+#13#10;
    end;
end;

procedure TMatrix.Add(rowIndex, colIndex: Integer; value: Integer);
var Cell: TCell;
begin
  if value <> 0 then
  begin
    Cell := TCell.create(rowIndex, colIndex, value);
    _matrix[rowIndex].Add(Cell);
  end;
end;

function TMatrix.GetCellValueByIndex(rowIndex, colIndex: Integer): Integer;
begin
  result := _matrix[rowIndex].GetCellByIndex(colIndex).Value;
end;

constructor TMatrix.Create(rowCount, colCount:integer);
var i: integer;
begin
  inherited create;
  _rowCount := rowCount;
  _colCount := colCount;
  setlength(_matrix, rowCount);
  for i := 1 to rowCount do
      _matrix[i] := Trow.create();
end;

destructor TMatrix.Destroy();
var i: integer;
begin
  for i := 1 to rowCount do
    _matrix[i].Destroy();
  setlength(_matrix,1);
  inherited;
end;

end.
