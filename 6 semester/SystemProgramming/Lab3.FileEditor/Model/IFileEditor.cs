using System;
using System.Threading.Tasks;

namespace Lab3.FileEditor.Model
{
    public interface IFileEditor
    {
        String Contents { get; }

        String FilePath { get; }

        FileEditorMode FileEditorMode { get; }

        Boolean IsFileOpened { get; }

        Boolean IsContentsChanged { get; }

        Task OpenFileAsync(String filePath, FileEditorMode editorMode);

        Task RegisterForAccessWaitingAsync(Action callback);

        void UpdateContents(String newContents);

        void Save();

        Task CloseFileAsync(Boolean saveChanges);
    }
}