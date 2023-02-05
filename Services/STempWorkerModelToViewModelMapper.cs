using EksamenFinish.Models;
using EksamenFinish.ViewModels;
using System.Collections.Generic;

namespace EksamenFinish.Services
{
    public class STempWorkerModelToViewModelMapper : IMapModelToViewModel<MTempWorker, VMTempWorker>
    {
        private VMTempWorkerValidation _validation;

        public VMTempWorker MapToViewModel(MTempWorker mTempWorker)
        {
            return new VMTempWorker(_validation)
            {
                Id = mTempWorker.Id,
                FirstName = mTempWorker.FirstName,
                LastName = mTempWorker.LastName,
                Address = mTempWorker.Address,
                City = mTempWorker.City,
                ZipCode = mTempWorker.ZipCode,
                PersonalNumber = mTempWorker.PersonalNumber,
                IsActive = mTempWorker.IsActive
            };
        }

        public List<VMTempWorker> MapToViewModelList(List<MTempWorker> mTempWorkers)
        {
            List<VMTempWorker> vmTempWorkers = new List<VMTempWorker>();
            foreach (var mTempWorker in mTempWorkers)
            {
                vmTempWorkers.Add(MapToViewModel(mTempWorker));
            }
            return vmTempWorkers;
        }
    }
}