using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Services;
using Xamarin.Forms;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Properties

        private ObservableCollection<Land> lands;
        public ObservableCollection<Land> Lands
        {
            get { return lands; }
            set { SetValue(ref lands, value); }
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set {SetValue(ref isRefreshing,value); }
        }

        private string filter;
        public string Filter
        {
            get { return filter; }
            set 
            {
                SetValue(ref filter,value); 
                SearchCommand.Execute(null);
            }
        }

        List<Land> landsList; 

        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if(string.IsNullOrEmpty(Filter))
            {
                Lands = new ObservableCollection<Land>(landsList);
            }

            else
            {
                Lands = new ObservableCollection<Land>(landsList.Where(
                    l => l.Name.ToLower().Contains(Filter.ToLower()) || 
                    l.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }

        #endregion

        #region Methods
        async void LoadLands()
        {
            IsRefreshing = true;
            var connection = await apiService.CheckConnection();

            if(!connection.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error",connection.Message,"Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");

            if(!response.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            landsList = (List<Land>)response.Result;
            Lands = new ObservableCollection<Land>(landsList);
            IsRefreshing = false;
        }
        #endregion

        #region Constructors
        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }
        #endregion
    }
}
