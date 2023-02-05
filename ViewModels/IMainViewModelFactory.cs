using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public interface IMainViewModelFactory
    {
        VMTempWorkerValidation CreateTempWorkerValidation();
        VMTempWorker CreateTempWorker();
        VMTempWorkerCollection CreateTempWorkerCollection();
        CTempWorkerCommands CreateTempWorkerCommands();
    }
}   