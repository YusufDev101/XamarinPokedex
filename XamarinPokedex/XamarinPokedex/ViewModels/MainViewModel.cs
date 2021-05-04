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
                PokemonImage = result.sprites.front_default;
                PokemonColor = SetColor(MethodHelpers.FirstCharToUpper(result.types[0].type.name));
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

        private string SetColor(string name)
        {
            switch (name)
            {
                case "Bug":
                    return "#92bc2c";
                case "Dark":
                    return "#595761";
                case "Dragon":
                    return "#0c69c8";
                case "Electric":
                    return "#f2d94e";
                case "Fairy":
                    return "#ee90e6";
                case "Fighting":
                    return "#d3425f";
                case "Fire":
                    return "#fba54c";
                case "Flying":
                    return "#a1bbec";
                case "Ghost":
                    return "#5f6dbc";
                case "Grass":
                    return "#5fbd58";
                case "Ground":
                    return "#da7c4d";
                case "Ice":
                    return "#75d0c1";
                case "Normal":
                    return "#a0a29f";
                case "Poison":
                    return "#b763cf";
                case "Psychic":
                    return "#fa8581";
                case "Rock":
                    return "#c9bb8a";
                case "Steel":
                    return "#5695a3";
                case "Water":
                    return "#539ddf";
                default:
                    return "";
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
