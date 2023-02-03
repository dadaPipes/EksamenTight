using EksamenFinish.Models;
using EksamenFinish.ViewModels;
using System.Collections.Generic;

namespace EksamenFinish.Services
{
    public class S_TempWorkerMapper
    {
        private VM_TempWorkerValidation vm_TempWorkerValidation;

        public S_TempWorkerMapper(VM_TempWorkerValidation vm_TempWorkerValidation)
        {
            this.vm_TempWorkerValidation = vm_TempWorkerValidation;
        }

        public VM_TempWorker MapModelToViewModel(M_TempWorker m_tempWorker)
        {
            return new VM_TempWorker(vm_TempWorkerValidation)
            {
                Id = m_tempWorker.Id,
                FirstName = m_tempWorker.FirstName,
                LastName = m_tempWorker.LastName,
                Address = m_tempWorker.Address,
                City = m_tempWorker.City,
                ZipCode = m_tempWorker.ZipCode,
                PersonalNumber = m_tempWorker.PersonalNumber,
                IsActive = m_tempWorker.IsActive
            };
        }

        public M_TempWorker MapViewModelToModel(VM_TempWorker vm_tempWorker)
        {
            return new M_TempWorker()
            {
                Id = vm_tempWorker.Id,
                FirstName = vm_tempWorker.FirstName,
                LastName = vm_tempWorker.LastName,
                Address = vm_tempWorker.Address,
                City = vm_tempWorker.City,
                ZipCode = vm_tempWorker.ZipCode,
                PersonalNumber = vm_tempWorker.PersonalNumber,
                IsActive = vm_tempWorker.IsActive
            };
        }

        public List<VM_TempWorker> MapModelListToViewModelList(List<M_TempWorker> m_tempWorkers)
        {
            List<VM_TempWorker> vm_tempWorkers = new List<VM_TempWorker>();
            foreach (var m_tempWorker in m_tempWorkers)
            {
                vm_tempWorkers.Add(MapModelToViewModel(m_tempWorker));
            }
            return vm_tempWorkers;
        }
    }
}
