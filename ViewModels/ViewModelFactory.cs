using EksamenFinish.Services;
using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public class ViewModelFactory : IViewModelFactory
    {
        private VM_TempWorkerValidation vm_TempWorkerValidation;
        private VM_TempWorker vm_TempWorker;
        private VM_TempWorkerCollection vm_TempWorkerCollection;
        private S_TempWorkerRepository s_TempWorkerRepository;

        public VM_TempWorkerValidation CreateTempWorkerValidation()
        {
            return vm_TempWorkerValidation = new VM_TempWorkerValidation();
        }

        public VM_TempWorker CreateTempWorker()
        {
            return vm_TempWorker = new VM_TempWorker(vm_TempWorkerValidation);
        }

        public VM_TempWorkerCollection CreateTempWorkerCollection()
        {
            return vm_TempWorkerCollection = new VM_TempWorkerCollection(vm_TempWorker);
        }

        public S_TempWorkerRepository CreateTempWorkerRepository()
        {
            return s_TempWorkerRepository = new S_TempWorkerRepository();
        }

        public C_TempWorkerCommands CreateTempWorkerCommands()
        {
            return new C_TempWorkerCommands(vm_TempWorker, vm_TempWorkerCollection, s_TempWorkerRepository);
        }
    }
}