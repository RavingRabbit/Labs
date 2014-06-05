using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab2.FileLocking.Model;
using Microsoft.Win32;

namespace Lab2.FileLocking.ViewModel
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly IFileEditor _fileEditor;
        private readonly ICommand _selectFileCommand;
        private readonly ICommand _openFileCommand;
        private readonly ICommand _closeFileCommand;
        private String _filePath = String.Empty;
        private String _status = "Select file.";
        private Boolean _isReadOnly = true;

        public MainWindowViewModel()
        {
            _fileEditor = new FileEditor();
            _selectFileCommand = new RelayCommand(SelectFile);
            _openFileCommand = new RelayCommand(OpenFile, () => !_fileEditor.IsFileOpened);
            _closeFileCommand = new RelayCommand(CloseFile, () => _fileEditor.IsFileOpened);
        }

        public String FilePath
        {
            get { return _filePath; }
            set
            {
                if (_filePath == value)
                    return;
                _filePath = value;
                RaisePropertyChanged(() => FilePath);
                UpdateStatus();
            }
        }

        public Boolean IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {

                if (_isReadOnly == value)
                    return;
                _isReadOnly = value;
                RaisePropertyChanged(() => IsReadOnly);
            }
        }

        public String Status
        {
            get { return _status; }
            private set
            {
                if (_status == value)
                    return;
                _status = value;
                RaisePropertyChanged(() => Status);
            }
        }

        public String FileContents
        {
            get
            {
                if (_fileEditor.IsFileOpened)
                {
                    return _fileEditor.Contents;
                }
                return String.Empty;
            }
            set
            {
                if (!_fileEditor.IsFileOpened) return;
                if (!IsReadOnly)
                    _fileEditor.UpdateContents(value);
                RaisePropertyChanged(() => FileContents);
            }
        }

        public ICommand SelectFileCommand
        {
            get { return _selectFileCommand; }
        }

        public ICommand OpenFileCommand
        {
            get { return _openFileCommand; }
        }

        public ICommand CloseFileCommand
        {
            get { return _closeFileCommand; }
        }

        private void SelectFile()
        {
            var selectFileDialog = new OpenFileDialog {Title = "Select file"};
            var result = selectFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                FilePath = selectFileDialog.FileName;
            }
        }

        private void OpenFile()
        {
            if (!File.Exists(FilePath))
            {
                Status = "File does not exists!";
                return;
            }
            try
            {
                _fileEditor.OpenFile(FilePath, FileEditorMode.Edit);
                IsReadOnly = false;
            }
            catch (InvalidOperationException)
            {
                _fileEditor.OpenFile(FilePath, FileEditorMode.ReadOnly);
                IsReadOnly = true;
                MessageBox.Show("File is used by another process. File will be opened in read-only mode.");
            }
            FileContents = _fileEditor.Contents;
            UpdateStatus();
        }

        private void CloseFile()
        {
            if (_fileEditor.IsContentsChanged)
            {
                var result = MessageBox.Show("Do you want to save changes?", "Confirmation",
                    MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    _fileEditor.CloseFile(true);
                }
                if (result == MessageBoxResult.No)
                {
                    _fileEditor.CloseFile(false);
                }
            }
            else
            {
                _fileEditor.CloseFile(false);
            }
            IsReadOnly = true;
            RaisePropertyChanged(() => FileContents);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (!_fileEditor.IsFileOpened)
            {
                Status = "Select file.";
                return;
            }
            if (_fileEditor.FileEditorMode == FileEditorMode.ReadOnly)
            {
                Status = "File is opened in read-only mode.";
            }
            else
            {
                Status = "File is opened in writer mode.";
            }
        }
    }
}
