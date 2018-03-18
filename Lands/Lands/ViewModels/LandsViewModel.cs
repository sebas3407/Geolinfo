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

        private ObservableCollection<LandItemViewModel> lands;
        public ObservableCollection<LandItemViewModel> Lands
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
                Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }

            else
            {
                Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel().Where(
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
            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            IsRefreshing = false;
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {

            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
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
