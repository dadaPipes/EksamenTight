using EksamenFinish.Models;
using EksamenFinish.ViewModels;

namespace EksamenFinish.Services
{
    public class STempWorkerViewModelToModelMapper : IMapViewModelToModel<MTempWorker, VMTempWorker>
    {
        public MTempWorker MapToModel(VMTempWorker vm_tempWorker)
        {
            return new MTempWorker
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
    }
}