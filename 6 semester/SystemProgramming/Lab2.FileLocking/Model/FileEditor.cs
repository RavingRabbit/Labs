using System;
using System.IO;
using RavingDev.Common;

namespace Lab2.FileLocking.Model
{
    public sealed class FileEditor : IFileEditor
    {
        private readonly IFileLocker _fileLocker;
        private String _contents;
        private FileEditorMode _mode;

        public FileEditor()
        {
            _fileLocker = new FileLocker();
            _contents = null;
            IsFileOpened = false;
            _mode = default (FileEditorMode);
        }

        public String Contents
        {
            get
            {
                if (!IsFileOpened)
                {
                    throw new InvalidOperationException("File is not opened.");
                }
                return _contents;
            }
        }

        public String FilePath { get; private set; }

        public FileEditorMode FileEditorMode
        {
            get { return _mode; }
        }

        public bool IsFileOpened { get; private set; }

        public Boolean IsContentsChanged { get; private set; }

        public void OpenFile(String filePath, FileEditorMode editorMode)
        {
            Requires.NotNull(filePath, "filePath");

            FilePath = filePath;
            _mode = editorMode;
            if (_mode == FileEditorMode.Edit)
            {
                if (_fileLocker.IsFileLocked(FilePath))
                {
                    throw new InvalidOperationException("Cannot open file.");
                }
                _fileLocker.LockFile(FilePath);
            }
            _contents = File.ReadAllText(FilePath);
            IsFileOpened = true;
        }

        public void UpdateContents(String newContents)
        {
            Requires.NotNull(newContents, "newContents");

            if (!IsFileOpened || _mode == FileEditorMode.ReadOnly)
            {
                throw new InvalidOperationException("Cannot edit file.");
            }
            if (_contents == newContents)
                return;
            IsContentsChanged = true;
            _contents = newContents;
        }

        public void Save()
        {
            if (!IsFileOpened || _mode == FileEditorMode.ReadOnly)
            {
                throw new InvalidOperationException("Cannot edit file.");
            }

            File.WriteAllText(FilePath, _contents);
        }

        public void CloseFile(Boolean saveChanges)
        {
            if (saveChanges)
            {
                Save();
            }
            if (_fileLocker.IsFileLockedByCurrentProcess(FilePath))
            {
                _fileLocker.UnlockFile(FilePath);
            }
            IsFileOpened = false;
            IsContentsChanged = false;
            _contents = null;
        }
    }
}
