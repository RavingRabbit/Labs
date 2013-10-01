unit Row;

interface

uses LinkedList, Cell, Object_, SysUtils, LinkedListIterator;
type

  TRow = class
  private
    _cells: TLinkedList;
    _isSorted: Boolean;
    function getIsEmpty(): Boolean;
  public
    constructor Create();
    destructor Destroy(); override;
    procedure Sort();
    procedure Add(Cell: TCell);
    function GetCellByIndex(const indx: Integer): TCell;
    function Summarize(Row: TRow): TRow;
    function ToString(): string;
    property IsSortred: Boolean read _isSorted;
    property IsEmpty: Boolean read getIsEmpty;
    property GetRow: TLinkedList read _cells;
  end;

implementation

function TRow.ToString(): string;
begin
  Sort();
  result := _cells.ToString;
end;

function TRow.getIsEmpty(): Boolean;
begin
  result := _cells.IsEmpty;
end;

function sortUp(a, b: TObject_): boolean; // Less
begin
  Result := ((a as TCell).colIndex < (b as TCell).colIndex);
end;

procedure TRow.Sort();
begin
  if not _isSorted then
    _cells.SortBubble(sortUp);
end;

function TRow.Summarize(Row: TRow): TRow;
var resultRow: TRow; Cell, Cell1, Cell2: TCell; iterator1, iterator2: TLinkeListIterator; bool:boolean;
begin
  resultRow := TRow.create;
  iterator1 := Row._cells.GetIterator();
  if Row.IsEmpty then
    begin
      result := self;
      exit;
    end
  else
    if self.IsEmpty then
      begin
        result := Row;
        exit;
      end;
  while(not iterator1.IsDone) do
    begin
      Cell := TCell.Create(0,0,0);
      Cell1 := iterator1.Current as TCell;
      bool := false;
      iterator2 := _cells.GetIterator();
      while (not iterator2.IsDone) do
        begin
          Cell2 := iterator2.Current as TCell;
          if Cell1.colIndex = Cell2.colIndex then
            begin
              Cell.value := Cell1.value + Cell2.value;
              Cell.rowIndex := Cell1.rowIndex;
              Cell.colIndex := Cell1.colIndex;
              resultRow.add(Cell);
              bool := true;
              break;
            end;
          iterator2.Next();
        end;
      if bool = false then
          resultRow.add(Cell1);
      iterator1.Next;
    end;
  resultRow.sort;
  Result := resultRow;
end;

constructor TRow.Create();
begin
  inherited Create;
  _cells := TLinkedList.Create(TCell);
  _isSorted := True;
end;

destructor TRow.Destroy();
begin
  _cells.Destroy;
  inherited Destroy;
end;

procedure TRow.Add(Cell: TCell);
var tmpCell: TCell; iterator: TLinkeListIterator; bool: boolean;
begin
  bool := true;
  iterator := _cells.GetIterator();
  while (not iterator.IsDone) do
    begin
      tmpCell := iterator.Current as TCell;
      if ((tmpCell.rowIndex = Cell.rowIndex) and (tmpCell.colIndex = Cell.colIndex)) then
        begin
          tmpCell.value := Cell.value;
          bool := false;
        end;
      iterator.Next();
    end;
  if bool then
    begin
      if not _cells.IsEmpty then
        begin
          tmpCell :=  _cells.PeekBack as TCell;
          if tmpCell.colIndex > Cell.colIndex then
            _isSorted := false;
        end;
      _cells.PushBack(Cell);
    end;
end;

function TRow.GetCellByIndex(const indx: Integer): TCell;
var Cell: TCell; iterator: TLinkeListIterator;
begin
  iterator := _cells.GetIterator();
  while (not iterator.IsDone) do
    begin
      Cell := iterator.Current as TCell;
      if Cell.colIndex = indx then
        begin
          result := Cell;
          exit;
        end;
      iterator.Next();
    end;
  result := TCell.GetEmptyCell();
end;

end.
 