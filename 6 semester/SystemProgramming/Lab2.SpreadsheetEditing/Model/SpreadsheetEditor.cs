using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using RavingDev.Common;

namespace Lab2.SpreadsheetEditing.Model
{
    public sealed class SpreadsheetEditor : ISpreadsheetEditor
    {
        private SpreadsheetEditorMode _mode;
        private SpreadsheetDocument _spreadsheet; 

        public SpreadsheetEditor()
        {
            IsOpened = false;
            _mode = default (SpreadsheetEditorMode);
        }

        public SpreadsheetEditorMode EditorMode
        {
            get { return _mode; }
        }

        public Boolean IsOpened { get; private set; }

        public void OpenSpreadsheet(String filePath, SpreadsheetEditorMode editorMode)
        {
            Requires.NotNull(filePath, "filePath");

            _mode = editorMode;

            try
            {
                _spreadsheet = SpreadsheetDocument.Open(filePath, _mode == SpreadsheetEditorMode.Edit);
            }
            catch (OpenXmlPackageException e)
            {
                throw new InvalidOperationException("Cannot open file." + e.Message);
            }
            IsOpened = true;
        }

        public String GetCell(UInt32 rowIndex, String columnName)
        {
            Requires.NotNull(columnName, "columnName");

            if (!IsOpened)
            {
                throw new InvalidOperationException("Cannot get cell value.");
            }
            WorksheetPart worksheetPart = GetWorksheetPartByName(_spreadsheet, "Sheet1");
            if (worksheetPart != null)
            {
                Cell cell = GetCell(worksheetPart.Worksheet,
                                         columnName, rowIndex);
                return cell.CellValue.Text;
            }
            return String.Empty;
        }

        private static WorksheetPart
             GetWorksheetPartByName(SpreadsheetDocument document,
             string sheetName)
        {
            IEnumerable<Sheet> sheets =
               document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
               Elements<Sheet>().Where(s => s.Name == sheetName);

            var enumerable = sheets as Sheet[] ?? sheets.ToArray();
            if (!enumerable.Any())
            {
                // The specified worksheet does not exist.

                return null;
            }

            string relationshipId = enumerable.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)
                 document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;

        }
        public void UpdateCell(String text, UInt32 rowIndex, String columnName)
        {
            Requires.NotNull(text, "text");
            Requires.NotNull(columnName, "columnName");

            if (!IsOpened || _mode == SpreadsheetEditorMode.ReadOnly)
            {
                throw new InvalidOperationException("Cannot edit file.");
            }
            //var sheet =_spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>();
            WorksheetPart worksheetPart = _spreadsheet.WorkbookPart.GetPartsOfType<WorksheetPart>().FirstOrDefault();
            if (worksheetPart != null)
            {
                Cell cell = GetCell(worksheetPart.Worksheet,
                                         columnName, rowIndex);

                cell.CellValue = new CellValue(text);
                cell.DataType =
                    new EnumValue<CellValues>(CellValues.String);

                // Save the worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        // Given a worksheet, a column name, and a row index, 
        // gets the cell at the specified column and 
        private static Cell GetCell(Worksheet worksheet,
                  string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().First(c => String.Compare(c.CellReference.Value, columnName + rowIndex,
                StringComparison.OrdinalIgnoreCase) == 0);
        }


        // Given a worksheet and a row index, return the row.
        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            var rows = worksheet.GetFirstChild<SheetData>().Elements<Row>().ToArray();
            return rows.FirstOrDefault(r => r.RowIndex == rowIndex);
        }

        public void CloseSpreadsheet()
        {
            _spreadsheet.Close();
            IsOpened = false;
        }
    }
}
