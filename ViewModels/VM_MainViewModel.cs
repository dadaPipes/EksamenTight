using EksamenFinish.Services;
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

    //public class VM_MainViewModel
    //{
    //    // Instance variables to store instances of other classes
    //    public VM_TempWorker vm_TempWorker { get; set; }
    //    public VM_TempWorkerValidation vm_TempWorkerValidation { get; set; }
    //    public VM_TempWorkerCollection vm_TempWorkerCollection { get; set; }
    //    public C_TempWorkerCommands c_TempWorkerCommands { get; set; }

    //    // Default constructor that creates an instance of ViewModelFactory
    //    public VM_MainViewModel() : this(factory: new ViewModelFactory()) { }

    //    // Second constructor that accepts an instance of IViewModelFactory
    //    public VM_MainViewModel(IViewModelFactory factory)
    //    {
    //        // Use the passed factory instance to create instances of other classes
    //        vm_TempWorker = factory.CreateTempWorker();
    //        vm_TempWorkerValidation = factory.CreateTempWorkerValidation();
    //        vm_TempWorkerCollection = factory.CreateTempWorkerCollection();
    //        c_TempWorkerCommands = factory.CreateTempWorkerCommands();
    //    }
    //}

    
    public class VM_MainViewModel
    {
        public VM_TempWorker vm_TempWorker { get; set; }
        public S_TempWorkerRepository s_TempWorkerRepository { get; set; }
        public VM_TempWorkerValidation vm_TempWorkerValidation { get; set; }
        public VM_TempWorkerCollection vm_TempWorkerCollection { get; set; }
        public C_TempWorkerCommands c_TempWorkerCommands { get; set; }

        public VM_MainViewModel()
        {
            vm_TempWorker = new VM_TempWorker();
            vm_TempWorkerValidation= new VM_TempWorkerValidation();
            vm_TempWorkerCollection= new VM_TempWorkerCollection();
            s_TempWorkerRepository = new S_TempWorkerRepository();
            c_TempWorkerCommands = new C_TempWorkerCommands(vm_TempWorker, vm_TempWorkerCollection, s_TempWorkerRepository);
        }

    }


}