using System;
using System.Threading.Tasks;

namespace Lab4.FileEditor.Model
{
    public interface IFileEditor
    {
        String Contents { get; }

        String FilePath { get; }

        FileEditorMode FileEditorMode { get; }

        Boolean IsFileOpened { get; }

        Boolean IsContentsChanged { get; }

        void OpenFile(String filePath, FileEditorMode editorMode);

        void RegisterForAccessWaiting(Action callback);

        void UpdateContents(String newContents);

        void Save();

        void CloseFile(Boolean saveChanges);
    }
}