#region Usings

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

// Parameterless constructor to avoid _validation being null when creating a new instance of VM_TempWorker in the MapperClasses.
namespace EksamenFinish.ViewModels
{
    // Used for data binding in the UI layer.
    public class VMTempWorker : INotifyPropertyChanged
    {
        private VMTempWorkerValidation _validation;

        public VMTempWorker()
        {
            _validation = new VMTempWorkerValidation();
        }

        // Constructor to accept an instance of VM_TempWorkerValidation
        public VMTempWorker(VMTempWorkerValidation validation)
        {
            _validation = validation;
        }

        private Guid _id;

        public Guid Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                if (_validation != null)
                {
                    _validation.ValidateFirstName = _firstName;
                }
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(_validation.ValidateFirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                if (_validation != null)
                {
                    _validation.ValidateLastName = _lastName;
                }
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(FullName));
                OnPropertyChanged(nameof(_validation.ValidateLastName));
            }
        }

        public string FullName => FirstName + " " + LastName;

        private string _address;

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                if (_validation != null)
                {
                    _validation.ValidateAddress = _address;
                }
                OnPropertyChanged(nameof(Address));
                OnPropertyChanged(nameof(_validation.ValidateAddress));
            }
        }

        private string _city;

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                if (_validation != null)
                {
                    _validation.ValidateCity = _city;
                }
                OnPropertyChanged(nameof(City));
                OnPropertyChanged(nameof(_validation.ValidateCity));
            }
        }

        private int _zipCode;

        public int ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                if (_validation != null)
                {
                    _validation.ValidateZipCode = _zipCode.ToString();
                }
                OnPropertyChanged(nameof(ZipCode));
                OnPropertyChanged(nameof(_validation.ValidateZipCode));
            }
        }

        private string _personalNumber;

        public string PersonalNumber
        {
            get => _personalNumber;
            set
            {
                _personalNumber = value;
                if (_validation != null)
                {
                    _validation.ValidatePersonalNumber = _personalNumber;
                }
                OnPropertyChanged(nameof(PersonalNumber));
                OnPropertyChanged(nameof(_validation.ValidatePersonalNumber));
            }
        }

        #region TempWorker bool IsActive

        // The value of the TempWorkerIsActive property is based on the values of TempWorkerIsActiveTrue and TempWorkerIsActiveFalse.

        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        private bool _IsActiveTrue;

        public bool IsActiveTrue
        {
            get => _IsActiveTrue;
            set
            {
                _IsActiveTrue = value;
                if (value)
                {
                    IsActiveFalse = false;
                    IsActive = true;
                }
                OnPropertyChanged(nameof(IsActiveTrue));
            }
        }

        private bool _IsActiveFalse;

        public bool IsActiveFalse
        {
            get => _IsActiveFalse;
            set
            {
                _IsActiveFalse = value;
                if (value)
                {
                    IsActiveTrue = false;
                    IsActive = false;
                }
                OnPropertyChanged(nameof(IsActiveFalse));
            }
        }

        #endregion TempWorker bool IsActive

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Implementation
    }
}