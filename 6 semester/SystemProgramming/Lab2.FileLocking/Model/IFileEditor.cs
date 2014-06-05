using System;

namespace Lab2.FileLocking.Model
{
    public interface IFileEditor
    {
        String Contents { get; }

        String FilePath { get; }

        FileEditorMode FileEditorMode { get; }

        Boolean IsFileOpened { get; }

        Boolean IsContentsChanged { get; }

        void OpenFile(String filePath, FileEditorMode editorMode);

        void UpdateContents(String newContents);

        void Save();

        void CloseFile(Boolean saveChanges);
    }
}
