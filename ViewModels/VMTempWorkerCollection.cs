using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EksamenFinish.ViewModels
{
    //ViewModel for TempWorker collection
    public class VMTempWorkerCollection : INotifyPropertyChanged
    {
        
        public VMTempWorkerCollection(VMTempWorker selectedTempWorker)
        {
            SelectedTempWorker = selectedTempWorker;
        }

        private VMTempWorker _selectedTempWorker;

        public VMTempWorker SelectedTempWorker
        {
            get => _selectedTempWorker;
            set
            {
                _selectedTempWorker = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        private ObservableCollection<VMTempWorker> _tempWorkers;

        public ObservableCollection<VMTempWorker> TempWorkers
        {
            get => _tempWorkers;
            set
            {
                _tempWorkers = value;
                OnPropertyChanged(nameof(TempWorkers));
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}