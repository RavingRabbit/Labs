using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using GalaSoft.MvvmLight;

namespace Lab3.FileLocking.Arbiter
{
    public sealed class AccessTableItem
    {
        public String FilePath { get; set; }

        public Int32 ProcessId { get; set; }

        public String InQueueProcessId { get; set; }
    }

    public sealed class MainWindowViewModel : ViewModelBase
    {
        private readonly FileAccessArbiter _fileAccessArbiter;
        private IReadOnlyCollection<AccessTableItem> _accessTable;

        public MainWindowViewModel(FileAccessArbiter fileAccessArbiter)
        {
            _fileAccessArbiter = fileAccessArbiter;
            _fileAccessArbiter.StateChanged += (sender, args) => UpdateAccessTable();
            UpdateAccessTable();
        }

        public IReadOnlyCollection<AccessTableItem> AccessTable
        {
            get { return _accessTable; }
            set
            {
                if (value.Equals(_accessTable)) return;
                _accessTable = value;
                RaisePropertyChanged(() => AccessTable);
            }
        }

        private void UpdateAccessTable()
        {
            AccessTable = GenerateAccessTable().ToList();
        }

        private IEnumerable<AccessTableItem> GenerateAccessTable()
        {
            Dictionary<string, Process> lockedFiles = _fileAccessArbiter.LockedFiles;
            Dictionary<string, Process[]> fileAccessQueue = _fileAccessArbiter.FileAccessQueue;
            foreach (var lockedFile in lockedFiles)
            {
                var item = new AccessTableItem {FilePath = lockedFile.Key, ProcessId = lockedFile.Value.Id};
                if (fileAccessQueue.ContainsKey(lockedFile.Key))
                {
                    List<string> ids =
                        fileAccessQueue[lockedFile.Key].Select(
                            process => process.Id.ToString(CultureInfo.InvariantCulture)).ToList();
                    if (ids.Count != 0)
                    {
                        item.InQueueProcessId = ids.Aggregate((s, s1) => s + " " + s1);
                    }
                }
                yield return item;
            }
        }
    }
}