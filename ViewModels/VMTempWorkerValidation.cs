using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EksamenFinish.ViewModels
{
    public class VMTempWorkerValidation : INotifyPropertyChanged
    {
        // //ViewModel for TempWorker validation
        // Responsible for validating the properties of a TempWorker, returning an error message if the name is invalid.

        #region Field

        //The regular expression ^[a-zA-Z]*$ is used to match any string that consists only of letters (uppercase or lowercase).
        private readonly Regex _onlyLetters = new Regex("^[a-zA-Z]*$");

        //Regular expression ^[0-9]*$ to match any string that consists only of digits.
        private readonly Regex _onlyDigits = new Regex("^[0-9]*$");

        #endregion Field

        private string _validateFirstName;
        public string ValidateFirstName
        {
            get => _validateFirstName;
            set
            {
                value ??= "";

                if (_onlyDigits.IsMatch(value))
                {
                    value = "kun bogstaver";
                }
                else if (value.Length > 50)
                {
                    value = "under 50 tegn";
                }
                else
                {
                    value = "";
                }
                _validateFirstName = value;
                OnPropertyChanged(nameof(ValidateFirstName));
            }
        }

        private string _validateLastName;

        public string ValidateLastName
        {
            get => _validateLastName;
            set
            {
                value ??= "";

                if (_onlyDigits.IsMatch(value))
                {
                    value = "kun bogstaver";
                }
                else if (value.Length > 50)
                {
                    value = "max 50 tegn";
                }
                else
                {
                    value = "";
                }
                _validateLastName = value;
                OnPropertyChanged(nameof(ValidateLastName));
            }
        }

        private string _validateAddress;

        public string ValidateAddress
        {
            get => _validateAddress;
            set
            {
                value ??= "";

                if (_onlyDigits.IsMatch(value))
                {
                    value = "kun bogstaver";
                }
                else if (value.Length > 25)
                {
                    value = "max 25 tegn";
                }
                else
                {
                    value = "";
                }
                _validateAddress = value;
                OnPropertyChanged(nameof(ValidateAddress));
            }
        }


        private string _validateCity;

        public string ValidateCity
        {
            get => _validateCity;
            set
            {
                _validateCity ??= "";
                if (!_onlyLetters.IsMatch(value))
                {
                    value = "kun bogstaver";
                }
                else if (value.Length > 50)
                {
                    value = "max 25 tegn";
                }
                else
                {
                    value = "";
                }

                _validateCity = value;
                OnPropertyChanged(nameof(ValidateCity));
            }
        }

        private string _validateZipCode;

        public string ValidateZipCode
        {
            get => _validateZipCode;
            set
            {
                _validateZipCode ??= "";

                if (!_onlyDigits.IsMatch(value))

                {
                    value = "kun tal";
                }
                else if (value.Length != 4)
                {
                    value = "kun 4 tal";
                }
                else
                {
                    value = "";
                }
                _validateZipCode = value;
                OnPropertyChanged(nameof(ValidateZipCode));
            }
        }

        private string _validatePersonalNumber;

        public string ValidatePersonalNumber
        {
            get => _validatePersonalNumber;
            set
            {
                _validatePersonalNumber ??= "";

                if (!_onlyDigits.IsMatch(value))

                {
                    value = "kun tal";
                }
                else if (value.Length != 10)
                {
                    value = "kun 10 cifre";
                }
                else
                {
                    value = "";
                }
                _validatePersonalNumber = value;
                OnPropertyChanged(nameof(ValidatePersonalNumber));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}