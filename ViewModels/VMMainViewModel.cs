using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    public class VMMainViewModel
    {
        // Instance variables to store instances of other classes

        public VMTempWorkerValidation vmTempWorkerValidation { get; set; }
        public VMTempWorker vmTempWorker { get; set; }
        public VMTempWorkerCollection vmTempWorkerCollection { get; set; }
        public CTempWorkerCommands cTempWorkerCommands { get; set; }

        // Default constructor that creates an instance of ViewModelFactory
        public VMMainViewModel() : this(factory: new VMMainViewModelFactory()) { }

        // Second constructor that accepts an instance of IViewModelFactory
        public VMMainViewModel(IMainViewModelFactory factory)
        {
            // Use the passed in factory instance to create instances of other classes

            vmTempWorkerValidation = factory.CreateTempWorkerValidation();
            vmTempWorker = factory.CreateTempWorker();
            vmTempWorkerCollection = factory.CreateTempWorkerCollection();
            cTempWorkerCommands = factory.CreateTempWorkerCommands();
        }
    }
}