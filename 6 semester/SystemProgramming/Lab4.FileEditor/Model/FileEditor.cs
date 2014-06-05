using System;
using System.IO;
using System.Threading.Tasks;
using Lab4.ResourceLocking;
using RavingDev.Common;

namespace Lab4.FileEditor.Model
{
    public sealed class FileEditor : IFileEditor
    {
        internal static FileEditor Instance;

        private readonly IResourceLocker _resourceLocker;
        private string _contents;
        private FileEditorMode _mode;

        public FileEditor()
        {
            _resourceLocker = new ResourceLocker();
            _contents = null;
            IsFileOpened = false;
            _mode = default (FileEditorMode);
            Instance = this;
        }

        public string Contents
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

        public string FilePath { get; private set; }

        public FileEditorMode FileEditorMode
        {
            get { return _mode; }
        }

        public bool IsFileOpened { get; private set; }

        public bool IsContentsChanged { get; private set; }

        public void OpenFile(string filePath, FileEditorMode editorMode)
        {
            Requires.NotNull(filePath, "filePath");

            FilePath = filePath;
            _mode = editorMode;
            if (_mode == FileEditorMode.Edit)
            {
                if (!_resourceLocker.TryLockResource(FilePath))
                {
                    throw new InvalidOperationException("Cannot open file. File is locked.");
                }
            }
            _contents = File.ReadAllText(FilePath);
            IsFileOpened = true;
        }

        public void RegisterForAccessWaiting(Action callback)
        {
            if (!IsFileOpened || FileEditorMode == FileEditorMode.Edit)
            {
                throw new InvalidOperationException();
            }
            _resourceLocker.RegisterCallbackForAccessWaiting(FilePath, callback);
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
            if (!IsFileOpened) return;
            if (saveChanges)
            {
                Save();
            }
            if (FileEditorMode == FileEditorMode.Edit)
            {
                _resourceLocker.UnlockResource(FilePath);
            }
            else
            {
                _resourceLocker.RemoveFromQueueForAccess(FilePath);
            }
            IsFileOpened = false;
            IsContentsChanged = false;
            _contents = null;
        }

        public void ReopenFileInEditorMode()
        {
            _mode = FileEditorMode.Edit;
            _contents = File.ReadAllText(FilePath);
            IsFileOpened = true;
        }
    }
}