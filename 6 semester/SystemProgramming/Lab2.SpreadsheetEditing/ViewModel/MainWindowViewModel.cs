using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Lab2.SpreadsheetEditing.Model;
using Microsoft.Win32;

namespace Lab2.SpreadsheetEditing.ViewModel
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly ISpreadsheetEditor _editor;
        private readonly ICommand _selectFileCommand;
        private readonly ICommand _openFileCommand;
        private readonly ICommand _closeFileCommand;
        private readonly ICommand _useReadOnlyModeCommand;
        private readonly ICommand _useWriteModeCommand;
        private String _filePath = String.Empty;
        private String _status = "Select file.";
        private Boolean _isReadOnly = true;
        private SpreadsheetEditorMode _mode;
        private Boolean _canChangeMode;

        public MainWindowViewModel()
        {
            _canChangeMode = true;
            _editor = new SpreadsheetEditor();
            _selectFileCommand = new RelayCommand(SelectFile);
            _openFileCommand = new RelayCommand(OpenFile, () => !_editor.IsOpened);
            _closeFileCommand = new RelayCommand(CloseFile, () => _editor.IsOpened);
            _useReadOnlyModeCommand = new RelayCommand(UseReadOnlyMode);
            _useWriteModeCommand = new RelayCommand(UseWriteMode);
            _mode = SpreadsheetEditorMode.Edit;
        }

        private void UseReadOnlyMode()
        {
            _mode = SpreadsheetEditorMode.ReadOnly;
        }

        private void UseWriteMode()
        {
            _mode = SpreadsheetEditorMode.Edit;
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

        public Boolean CanChangeMode
        {
            get { return _canChangeMode; }
            set
            {
                if (_canChangeMode == value)
                    return;
                _canChangeMode = value;
                RaisePropertyChanged(() => CanChangeMode);
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

        public String CellValue
        {
            get
            {
                if (_editor.IsOpened)
                {
                    return _editor.GetCell(1, "A");
                }
                return String.Empty;
            }
            set
            {
                if (!_editor.IsOpened) return;
                if (!IsReadOnly)
                    _editor.UpdateCell(value, 1, "A");
                RaisePropertyChanged(() => CellValue);
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

        public ICommand UseReadOnlyModeCommand
        {
            get { return _useReadOnlyModeCommand; }
        }

        public ICommand UseWriteModeCommand
        {
            get { return _useWriteModeCommand; }
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
                _editor.OpenSpreadsheet(FilePath, _mode);
                CanChangeMode = false;
                IsReadOnly = _mode == SpreadsheetEditorMode.ReadOnly;
            }
            catch (Exception e)
            {
                MessageBox.Show("File cannot be opened. " + e.Message);
            }
            RaisePropertyChanged(() => CellValue);
            UpdateStatus();
        }

        private void CloseFile()
        {
            _editor.CloseSpreadsheet();
            IsReadOnly = true;
            CanChangeMode = true;
            RaisePropertyChanged(() => CellValue);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            if (!_editor.IsOpened)
            {
                Status = "Select file.";
                return;
            }
            if (_editor.EditorMode == SpreadsheetEditorMode.ReadOnly)
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
