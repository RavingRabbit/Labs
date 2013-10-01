{$Apptype Console}
program Main;


uses
  sysutils,
  LinkedList in 'DataStructures\LinkedList.pas',
  LinkedListException in 'DataStructures\LinkedListException.pas',
  LinkedListItem in 'DataStructures\LinkedListItem.pas',
  LinkedListIterator in 'DataStructures\LinkedListIterator.pas',
  EventArgs in 'Core\EventArgs.pas',
  LinkedListEventArgs in 'DataStructures\LinkedListEventArgs.pas',
  Matrix in 'DataStructures\Matrix.pas',
  Row in 'DataStructures\Row.pas',
  Object_ in 'Core\Object_.pas',
  Cell in 'IntegralDataTypes\Cell.pas';

procedure fillInMatrix(Matrix: Tmatrix; zapolnenost: extended);
var i,j,k: integer; N: int64;
begin
  if zapolnenost > 100 then
    zapolnenost := 100;
  k := 0;
  randomize;
  N := round(matrix.rowCount*matrix.colCount*zapolnenost/100);
  while (k < N) do
    begin
      i := random(matrix.rowCount)+1;
      j := random(matrix.colCount)+1;
      //if matrix[i,j] = 0 then
        //begin
          matrix[i,j] := random(9)+1;
          inc(k);
        //end;
    end;
end;

var
  matrix1, matrix2, resultMatrix:Tmatrix;
  rowCount, colCount: integer;
  zapolnenost: extended;
begin
  writeln('matrix -> RowCount: ');
  Read(rowCount);
  writeln('matrix -> ColCount: ');
  Read(colCount);
  writeln('matrix -> % zapolnentosti: ');
  Read(zapolnenost);
  matrix1 := Tmatrix.create(rowCount, colCount);
  fillInMatrix(Matrix1, zapolnenost);
  writeln;
  writeln('Second matrix -> RowCount: ');
  Read(rowCount);
  writeln('Second matrix -> ColCount: ');
  Read(colCount);
  writeln('Second matrix -> % zapolnentosti: ');
  Read(zapolnenost);
  matrix2 := Tmatrix.create(rowCount, colCount);
  resultMatrix := Tmatrix.create(rowCount, colCount);
  fillInMatrix(Matrix2, zapolnenost);
  writeln;
  writeln('First matrix:');
  write(matrix1.ToString);
  writeln('');
  writeln('Second matrix:');
  write(matrix2.ToString);
  writeln('');
  resultMatrix := matrix1.multiply(Matrix2);
  writeln('Multiply:');
  if resultMatrix <> Nil then
    write(resultMatrix.ToString)
  else
    writeln('I cant multiply these matrix :(');
  writeln('');
  resultMatrix := matrix1.summarize(Matrix2);
  writeln('Summ:');
  if resultMatrix <> Nil then
    write(resultMatrix.ToString)
  else
    writeln('I cant summarize these matrix :(');
  writeln('');
  resultMatrix := matrix1.transpose;
  writeln('Transpose:');
  write(resultMatrix.ToString);
  readln(rowCount);
end.
