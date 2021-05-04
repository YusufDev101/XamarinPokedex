using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinPokedex.Helpers;
using XamarinPokedex.Models;

namespace XamarinPokedex.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        public string ApplicationName { get; set; } = "Xam Pokedex";

        #endregion

        public MainViewModel()
        {

        }


        public async void GetPokemon()
        {
            try
            {
                IsBusy = true;

                // Var call.
                PokemonObject result = await App.HttpWebRequest.GetPokemon(SearchFilter);

                // Set data.
                //Console.WriteLine(result);

                // Set pokemon name.
                PokemonName = MethodHelpers.FirstCharToUpper(result.name); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private string _pokemonName;
        public string PokemonName
        {
            get
            {
                return _pokemonName;
            }
            set
            {
                _pokemonName = value;
                OnPropertyChanged();
            }
        }


        private string _searchFilter;
        public string SearchFilter
        {
            get
            {
                return _searchFilter;
            }
            set
            {
                _searchFilter = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }      
    }
}
