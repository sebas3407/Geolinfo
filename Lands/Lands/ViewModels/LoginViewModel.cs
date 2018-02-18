namespace Lands.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;
    using Lands.Views;

    public class LoginViewModel : INotifyPropertyChanged
    {

        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));

                }
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }

        public bool isRunning;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if(isRunning != value)
                {
                    IsRunning = value;
                    PropertyChanged?.Invoke(this,new PropertyChangedEventArgs("IsRunning"));
                }
            }
        }

        public bool IsRemembered
        {
            get;
            set;
        }
        #endregion

        #region Commands

        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please, enter a email", "OK");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please, enter a password", "OK");
                return;
            }

            if (Email == "sebas" && Password == "1234")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }

            else
            {
                Email = string.Empty;
                Password = string.Empty;
                await Application.Current.MainPage.DisplayAlert("Error", "Email or password invalid", "Ok");
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }
        #endregion
    }
}