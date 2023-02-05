using EksamenFinish.ViewModels.Commands;

namespace EksamenFinish.ViewModels
{
    /*
     * In the VM_MainViewModel class, there are two constructors:
     * a default constructor and a second constructor that accepts an instance of IViewModelFactory.
     * The default constructor is calling the second constructor by using the this keyword and passing an instance of ViewModelFactory as an argument.

    This allows the default constructor to use the functionality of the second constructor without having to duplicate the code.
    The result is that the default constructor creates an instance of ViewModelFactory and passes it to the second constructor,
    which uses it to create instances of other classes.
    */

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