using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab3.FileEditor.Model;
using Microsoft.Win32;

namespace Lab3.FileEditor.ViewModel
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly RelayCommand _closeFileCommand;
        private readonly IFileEditor _fileEditor;
        private readonly RelayCommand _openFileCommand;
        private readonly RelayCommand _selectFileCommand;
        private String _filePath = String.Empty;
        private Boolean _isReadOnly = true;
        private String _status = "Select file.";
        private SolidColorBrush _statusColor;

        public MainWindowViewModel()
        {
            _fileEditor = new Model.FileEditor();
            _selectFileCommand = new RelayCommand(SelectFile);
            _openFileCommand = new RelayCommand(() => OpenFileAsync(), () => !_fileEditor.IsFileOpened);
            _closeFileCommand = new RelayCommand(() => CloseFileAsync(), () => _fileEditor.IsFileOpened);
            StatusColor = Brushes.CornflowerBlue;
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
            bool? result = selectFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                FilePath = selectFileDialog.FileName;
            }
        }

        private async Task OpenFileAsync()
        {
            if (!File.Exists(FilePath))
            {
                Status = "File does not exists!";
                return;
            }
            try
            {
                await _fileEditor.OpenFileAsync(FilePath, FileEditorMode.Edit);
                IsReadOnly = false;
            }
            catch (InvalidOperationException)
            {
                IsReadOnly = true;
            }
            if (IsReadOnly)
            {
                await _fileEditor.OpenFileAsync(FilePath, FileEditorMode.ReadOnly);
                /*MessageBox.Show("File is used by another process. " +
                                "File will be opened in read-only mode and added to queue for access.", "Access denied.",
                    MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.None);*/
                await _fileEditor.RegisterForAccessWaitingAsync(() =>
                {
                    CloseFileAsync().Wait();
                    OpenFileAsync().Wait();
                    /*MessageBox.Show("Write access granted.", "Access granted.", MessageBoxButton.OK,
                        MessageBoxImage.Information, MessageBoxResult.None);*/
                    UpdateStatus();
                });
            }
            FileContents = _fileEditor.Contents;
            UpdateStatus();
        }

        private async Task CloseFileAsync()
        {
            if (_fileEditor.IsContentsChanged)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes?", "Confirmation",
                    MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    await _fileEditor.CloseFileAsync(true);
                }
                if (result == MessageBoxResult.No)
                {
                    await _fileEditor.CloseFileAsync(false);
                }
            }
            else
            {
                await _fileEditor.CloseFileAsync(false);
            }
            IsReadOnly = true;
            RaisePropertyChanged(() => FileContents);
            UpdateStatus();
        }

        public SolidColorBrush StatusColor
        {
            get
            {
                return _statusColor;
            }
            set
            {
                if (value == _statusColor)
                    return;
                _statusColor = value;
                RaisePropertyChanged(() => StatusColor);
            }
        }

        private void UpdateStatus()
        {
            _openFileCommand.RaiseCanExecuteChanged();
            _closeFileCommand.RaiseCanExecuteChanged();
            if (!_fileEditor.IsFileOpened)
            {
                Status = "Select file.";
                StatusColor = Brushes.CornflowerBlue;
                return;
            }
            if (_fileEditor.FileEditorMode == FileEditorMode.ReadOnly)
            {
                IsReadOnly = true;
                Status = "File is opened in read-only mode.";
                StatusColor = Brushes.Orange;
            }
            else
            {
                IsReadOnly = false;
                Status = "File is opened in writer mode.";
                StatusColor = Brushes.Green;
            }
        }
    }
}