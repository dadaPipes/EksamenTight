﻿using EksamenFinish.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EksamenFinish.ViewModels.Commands
{
    public class C_TempWorkerCommands
    {
        #region Fields

        private VM_TempWorker selectedTempWorker;
        private S_TempWorkerRepository s_tempWorkerRepository;
        private VM_TempWorkerCollection vm_TempWorkerCollection;

        #endregion Fields

        public C_TempWorkerCommands(VM_TempWorker selectedTempWorker, VM_TempWorkerCollection vm_TempWorkerCollection, S_TempWorkerRepository s_tempWorkerRepository)
        {
            this.selectedTempWorker = selectedTempWorker;
            this.vm_TempWorkerCollection = vm_TempWorkerCollection;
            this.s_tempWorkerRepository = s_tempWorkerRepository;
        }

        #region SearchTempWorkerCommand

        public ICommand SearchTempWorkerCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    vm_TempWorkerCollection.TempWorkers?.Clear();

                    vm_TempWorkerCollection.TempWorkers = new ObservableCollection<VM_TempWorker>(s_tempWorkerRepository.SearchTempWorkers(selectedTempWorker));
                },
                () => true);
            }
        }

        #endregion SearchTempWorkerCommand

        #region CreateTempWorkerCommand

        public ICommand CreateTempWorkerCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    s_tempWorkerRepository.CreateTempWorker(vm_TempWorkerCollection.SelectedTempWorker);
                },
                () => true);
            }
        }

        #endregion CreateTempWorkerCommand

        #region UpdateTempWorker

        public ICommand UpdateTempWorkerCommand => new RelayCommand(() =>
        {
            s_tempWorkerRepository.UpdateTempWorker(vm_TempWorkerCollection.SelectedTempWorker);
        }, () => true);

        #endregion UpdateTempWorker

        #region DeleteCommand

        public ICommand DeleteTempWorkerCommand => new RelayCommand(() =>
        {
            s_tempWorkerRepository.DeleteTempWorker(vm_TempWorkerCollection.SelectedTempWorker);
        }, () => true);

        #endregion DeleteCommand
    }
}

// ICommand validation for SearchTempWorker:

//if (string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.FirstName)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.LastName)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.Address)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.City)
//    || (vm_tempWorkerViewModel.ZipCode == 0)
//    || string.IsNullOrWhiteSpace(vm_tempWorkerViewModel.PersonalNumber))
//{
//    return false;
//}
//else
//{