using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
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
            // Get screen width.
            ScreenWidth = Convert.ToInt32(App.ScreenHeight);
        }

        public async void GetPokemon()
        {
            try
            {
                IsBusy = true;

                // Var call.
                PokemonObject result = await App.HttpWebRequest.GetPokemon(SearchFilter);

                // Set pokemon name.
                PokemonName = MethodHelpers.FirstCharToUpper(result.name);
                PokemonImage = result.sprites.other.dream_world.front_default;
                PokemonColor = MethodHelpers.SetColor(MethodHelpers.FirstCharToUpper(result.types[0].type.name));
                PokemonNumber = result.id;
                PokemonWeight = "w- " + result.weight;
                PokemonHeight = " h- " + result.height;
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

        private string _pokemonImage;
        public string PokemonImage
        {
            get
            {
                return _pokemonImage;
            }
            set
            {
                _pokemonImage = value;
                OnPropertyChanged();
            }
        }

        private int _screenWidth;
        public int ScreenWidth
        {
            get
            {
                return _screenWidth;
            }
            set
            {
                _screenWidth = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonColor;
        public string PokemonColor
        {
            get
            {
                return _pokemonColor;
            }
            set
            {
                _pokemonColor = value;
                OnPropertyChanged();
            }
        }

        private int _pokemonNumber;
        public int PokemonNumber
        {
            get
            {
                return _pokemonNumber;
            }
            set
            {
                _pokemonNumber = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonWeight;
        public string PokemonWeight
        {
            get
            {
                return _pokemonWeight;
            }
            set
            {
                _pokemonWeight = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonHeight;
        public string PokemonHeight
        {
            get
            {
                return _pokemonHeight;
            }
            set
            {
                _pokemonHeight = value;
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
