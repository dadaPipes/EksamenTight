using EksamenFinish.DAL;
using EksamenFinish.Models;
using EksamenFinish.Services;
using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public class VMMainViewModelFactory : IMainViewModelFactory
    {
        private DALDatabaseConnection _dalDatabaseConnection;
        private DALTempWorkerRepository _dalTempWorkerRepository;
        private IMapModelToViewModel<MTempWorker, VMTempWorker> _mapToViewModel;
        private IMapViewModelToModel<MTempWorker, VMTempWorker> _mapToModel;
        private VMTempWorkerValidation vm_TempWorkerValidation;
        private VMTempWorker vm_TempWorker;
        private VMTempWorkerCollection vm_TempWorkerCollection;
        private STempWorkerRepository s_TempWorkerRepository;

        public VMTempWorkerValidation CreateTempWorkerValidation()
        {
            return vm_TempWorkerValidation = new VMTempWorkerValidation();
        }

        public VMTempWorker CreateTempWorker()
        {
            return vm_TempWorker = new VMTempWorker(vm_TempWorkerValidation);
        }

        public VMTempWorkerCollection CreateTempWorkerCollection()
        {
            _dalDatabaseConnection = new DALDatabaseConnection();

            _dalTempWorkerRepository = new DALTempWorkerRepository(_dalDatabaseConnection);

            _mapToViewModel = new STempWorkerModelToViewModelMapper();

            _mapToModel = new STempWorkerViewModelToModelMapper();

            s_TempWorkerRepository = new STempWorkerRepository(_dalTempWorkerRepository, _mapToViewModel, _mapToModel);

            return vm_TempWorkerCollection = new VMTempWorkerCollection(vm_TempWorker, s_TempWorkerRepository);
        }

        public CTempWorkerCommands CreateTempWorkerCommands()
        {
            return new CTempWorkerCommands(vm_TempWorkerCollection);
        }
    }
}