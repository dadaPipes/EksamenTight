using EksamenFinish.Services;
using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public interface IViewModelFactory
    {
        VM_TempWorkerValidation CreateTempWorkerValidation();

        VM_TempWorker CreateTempWorker();

        VM_TempWorkerCollection CreateTempWorkerCollection();

        S_TempWorkerRepository CreateTempWorkerRepository();

        C_TempWorkerCommands CreateTempWorkerCommands();
    }
}