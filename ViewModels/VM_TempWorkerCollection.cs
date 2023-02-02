using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EksamenFinish.ViewModels
{
    //ViewModel for TempWorker collection
    public class VM_TempWorkerCollection : INotifyPropertyChanged
    {
        
        public VM_TempWorkerCollection(VM_TempWorker selectedTempWorker)
        {
            SelectedTempWorker = selectedTempWorker;
        }

        private VM_TempWorker _selectedTempWorker;

        public VM_TempWorker SelectedTempWorker
        {
            get => _selectedTempWorker;
            set
            {
                _selectedTempWorker = value;
                OnPropertyChanged(nameof(SelectedTempWorker));
            }
        }

        private ObservableCollection<VM_TempWorker> _tempWorkers;

        public ObservableCollection<VM_TempWorker> TempWorkers
        {
            get => _tempWorkers;
            set
            {
                _tempWorkers = value;
                OnPropertyChanged(nameof(TempWorkers));
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