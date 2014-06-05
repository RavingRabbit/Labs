using System;

namespace Lab2.SpreadsheetEditing.Model
{
    public interface ISpreadsheetEditor
    {
        SpreadsheetEditorMode EditorMode { get; }

        Boolean IsOpened { get; }

        void OpenSpreadsheet(String filePath, SpreadsheetEditorMode editorMode);

        String GetCell(UInt32 rowIndex, String columnName);

        void UpdateCell(String text, UInt32 rowIndex, String columnName);

        void CloseSpreadsheet();
    }
}
