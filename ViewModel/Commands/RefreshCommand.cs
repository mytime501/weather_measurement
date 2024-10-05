using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    internal class RefreshCommand : ICommand
    {
        public parameter VM { get; set; }
        public RefreshCommand(parameter vm)
        {
            VM = vm;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(VM.MyText != null)
            {
                if (VM.MyText == "")
                {
                    VM.GetWeather();
                }
                else if (VM.Cities.Contains(VM.MyText))
                {
                    VM.SelectedCity = VM.MyText;
                }
                else
                {
                    VM.Cities.Add(VM.MyText);
                    VM.SelectedCity = VM.MyText;
                }
            }
        }
    }
}
