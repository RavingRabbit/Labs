using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Lab3.FileLocking;
using RavingDev.Common;

namespace Lab3.FileEditor.Model
{
    public sealed class FileEditor : IFileEditor
    {
        private readonly IFileLocker _fileLocker;
        private String _contents;
        private FileEditorMode _mode;

        public FileEditor()
        {
            _fileLocker = new FileLocker(ConfigurationManager.AppSettings.Get("arbiterAppName"));
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

        public async Task OpenFileAsync(String filePath, FileEditorMode editorMode)
        {
            Requires.NotNull(filePath, "filePath");

            FilePath = filePath;
            _mode = editorMode;
            if (_mode == FileEditorMode.Edit)
            {
                if (!(await _fileLocker.TryLockFileAsync(filePath)))
                {
                    throw new InvalidOperationException("Cannot open file. File is locked.");
                }
            }
            _contents = File.ReadAllText(FilePath);
            IsFileOpened = true;
        }

        public async Task RegisterForAccessWaitingAsync(Action callback)
        {
            if (!IsFileOpened || FileEditorMode == FileEditorMode.Edit)
            {
                throw new InvalidOperationException();
            }
            await _fileLocker.RegisterForAccessWaitingAsync(FilePath, callback);
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

        public async Task CloseFileAsync(Boolean saveChanges)
        {
            if (!IsFileOpened) return;
            if (saveChanges)
            {
                Save();
            }
            if (FileEditorMode == FileEditorMode.Edit)
            {
                await _fileLocker.UnlockFileAsync(FilePath);
            }
            else
            {
                await _fileLocker.RemoveFromQueueForAccessAsync(FilePath);
            }
            IsFileOpened = false;
            IsContentsChanged = false;
            _contents = null;
        }
    }
}