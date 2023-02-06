using System;
using System.Windows.Input;

namespace EksamenFinish.ViewModels.Commands
{
    public class CTempWorkerCommands
    {
        private VMTempWorkerCollection vm_TempWorkerCollection;

        public CTempWorkerCommands(VMTempWorkerCollection vm_TempWorkerCollection)
        {
            this.vm_TempWorkerCollection = vm_TempWorkerCollection;
        }


        public ICommand CreateTempWorkerCommand => new RelayCommand(() =>
        {
            if (!IsValidTempWorker(vm_TempWorkerCollection.SelectedTempWorker))
            {
                // Validation failed, show error message
            }
            else if (vm_TempWorkerCollection.SelectedTempWorker.Id != Guid.Empty)
            {
                // Validation failed, show error message
            }
            else
            {
                vm_TempWorkerCollection.CreateTempWorker();
            }
        }, () => true);

        public ICommand SearchTempWorkerCommand => new RelayCommand(() =>
        {
            if (vm_TempWorkerCollection.SelectedTempWorker == null)
            {
                // Validation failed, show error message
            }
            else
            {
                vm_TempWorkerCollection.SearchTempWorker();
            }
        }, () => true);

        public ICommand UpdateTempWorkerCommand => new RelayCommand(vm_TempWorkerCollection.UpdateTempWorker, () => true);
        public ICommand DeleteTempWorkerCommand => new RelayCommand(vm_TempWorkerCollection.DeleteTempWorker, () => true);
        public ICommand ClearTextCommand => new RelayCommand(vm_TempWorkerCollection.ClearTextBoxes, () => true);

        #region IsValidTempWorker

        /// <summary>
        /// Check if properties of VMTempWorker is NullOrWhiteSpace
        /// </summary>

        private bool IsValidTempWorker(VMTempWorker tempWorker)
        {
            if (string.IsNullOrWhiteSpace(tempWorker.FirstName)
                || string.IsNullOrWhiteSpace(tempWorker.LastName)
                || string.IsNullOrWhiteSpace(tempWorker.Address)
                || string.IsNullOrWhiteSpace(tempWorker.City)
                || (tempWorker.ZipCode == 0)
                || string.IsNullOrWhiteSpace(tempWorker.PersonalNumber))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion IsValidTempWorker
    }
}