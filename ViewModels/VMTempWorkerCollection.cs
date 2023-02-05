using EksamenFinish.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EksamenFinish.ViewModels
{
    //ViewModel for TempWorker collection
    public class VMTempWorkerCollection : INotifyPropertyChanged
    {
        private STempWorkerRepository _sTempWorkerRepo;

        public VMTempWorkerCollection(VMTempWorker selectedTempWorker, STempWorkerRepository sTempWorkerRepo)
        {
            SelectedTempWorker = selectedTempWorker;
            _sTempWorkerRepo = sTempWorkerRepo;
            TempWorkers = new ObservableCollection<VMTempWorker>();
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

        public ObservableCollection<VMTempWorker> TempWorkers { get; set; }

        public void CreateTempWorker()
        {
            _sTempWorkerRepo.CreateTempWorker(SelectedTempWorker);
            TempWorkers.Add(SelectedTempWorker);
            ClearTextBoxes();
        }

        public void SearchTempWorker()
        {
            TempWorkers.Clear();

            foreach (var tempWorker in _sTempWorkerRepo.SearchTempWorkers(SelectedTempWorker))
            {
                TempWorkers.Add(tempWorker);
            }
        }

        public void UpdateTempWorker()
        {
            _sTempWorkerRepo.UpdateTempWorker(SelectedTempWorker);
        }

        public void DeleteTempWorker()
        {
            _sTempWorkerRepo.DeleteTempWorker(SelectedTempWorker);

            TempWorkers.Remove(SelectedTempWorker);
        }

        public void ClearTextBoxes()
        {
            SelectedTempWorker = new VMTempWorker();
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