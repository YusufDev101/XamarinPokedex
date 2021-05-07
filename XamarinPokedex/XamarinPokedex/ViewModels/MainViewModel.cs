using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using XamarinPokedex.Helpers;
using XamarinPokedex.Models;
using Entry = Microcharts.ChartEntry;

namespace XamarinPokedex.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Properties

        public string ApplicationName { get; set; } = "Xam Pokedex";

        #endregion

        private PokemonObject pokemonObject;
        public LineChart ChartData;
        private List<Entry> ChartEntry;

        public MainViewModel()
        {
            // Get screen width.
            ScreenWidth = Convert.ToInt32(App.ScreenHeight);
            pokemonObject = new PokemonObject();
        }

        public async Task GetPokemon()
        {
            try
            {
                IsBusy = true;

                // Var call.
                pokemonObject = await App.HttpWebRequest.GetPokemon(SearchFilter);

                // Set Pokemon name.
                PokemonName = MethodHelpers.FirstCharToUpper(pokemonObject.name);
                PokemonImage = pokemonObject.sprites.other.dream_world.front_default;
                //PokemonImage = result.sprites.versions.generationv.blackwhite.front_default;
                PokemonColor = MethodHelpers.SetColor(MethodHelpers.FirstCharToUpper(pokemonObject.types[0].type.name));
                PokemonNumber = pokemonObject.id;
                PokemonWeight = "w: " + pokemonObject.weight;
                PokemonHeight = " h: " + pokemonObject.height;

                if (IsShiny)
                {
                    PokemonImageFrontMale = pokemonObject.sprites.front_shiny;
                    PokemonImageBackMale = pokemonObject.sprites.back_shiny;
                    PokemonImageFrontFemale = Convert.ToString(pokemonObject.sprites.front_shiny_female);
                    PokemonImageBackFemale = Convert.ToString(pokemonObject.sprites.back_shiny_female);
                }
                else
                {
                    // Images
                    PokemonImageFrontMale = pokemonObject.sprites.front_default;
                    PokemonImageBackMale = pokemonObject.sprites.back_default;
                    PokemonImageFrontFemale = Convert.ToString(pokemonObject.sprites.front_female);
                    PokemonImageBackFemale = Convert.ToString(pokemonObject.sprites.back_female);
                }

                Type1 = MethodHelpers.SetImage(MethodHelpers.FirstCharToUpper(pokemonObject.types[0].type.name));

                Type2 = pokemonObject.types.Length == 2 ?
                        MethodHelpers.SetImage(MethodHelpers.FirstCharToUpper(pokemonObject.types[1].type.name)) :
                        "";

                Ability1 = (MethodHelpers.FirstCharToUpper(pokemonObject.abilities[0].ability.name));

                Ability2 = pokemonObject.abilities.Length == 2 ?
                     MethodHelpers.FirstCharToUpper(pokemonObject.abilities[1].ability.name) :
                      "N/A";

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

        public async Task GetShinies()
        {
            try
            {
                IsBusy = true;

                if (IsShiny)
                {
                    PokemonImageFrontMale = pokemonObject.sprites.front_shiny;
                    PokemonImageBackMale = pokemonObject.sprites.back_shiny;
                    PokemonImageFrontFemale = Convert.ToString(pokemonObject.sprites.front_shiny_female);
                    PokemonImageBackFemale = Convert.ToString(pokemonObject.sprites.back_shiny_female);
                }
                else
                {
                    // Images
                    PokemonImageFrontMale = pokemonObject.sprites.front_default;
                    PokemonImageBackMale = pokemonObject.sprites.back_default;
                    PokemonImageFrontFemale = Convert.ToString(pokemonObject.sprites.front_female);
                    PokemonImageBackFemale = Convert.ToString(pokemonObject.sprites.back_female);
                }

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

        public List<Entry> BuildChat()
        {
            try
            {
                if (pokemonObject == null)
                {
                    throw new Exception("pokemonObject is empty");
                }

                // Build Chart.
                ChartEntry = new List<Entry>
                {
                    new Entry(pokemonObject.stats[0].base_stat)
                    {
                        Color=SKColor.Parse("#FFFFFF"),
                        Label ="hp",
                        ValueLabel = pokemonObject.stats[0].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#FFFFFF")
                    },
                   new Entry(pokemonObject.stats[1].base_stat)
                    {
                        Color=SKColor.Parse("#CC3E4A"),
                        Label ="attack",
                        ValueLabel = pokemonObject.stats[1].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#CC3E4A")
                    },
                    new Entry(pokemonObject.stats[2].base_stat)
                    {
                        Color=SKColor.Parse("#2D8DA8"),
                        Label ="defense",
                        ValueLabel = pokemonObject.stats[2].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#2D8DA8")
                    },
                    new Entry(pokemonObject.stats[3].base_stat)
                    {
                        Color=SKColor.Parse("#E76D3B"),
                        Label ="sp-attack",
                        ValueLabel = pokemonObject.stats[3].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#E76D3B")
                    },
                    new Entry(pokemonObject.stats[4].base_stat)
                    {
                        Color=SKColor.Parse("#7049A3"),
                        Label ="s-defence",
                        ValueLabel = pokemonObject.stats[4].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#7049A3")
                    },
                    new Entry(pokemonObject.stats[5].base_stat)
                    {
                        Color=SKColor.Parse("#FFFFFF"),
                        Label ="speed",
                        ValueLabel = pokemonObject.stats[5].base_stat.ToString(),
                        ValueLabelColor = SKColor.Parse("#FFFFFF")
                    },
                };

                return ChartEntry;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Properties


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


        #endregion

        #region Images

        private string _pokemonImageFrontMale;
        public string PokemonImageFrontMale
        {
            get
            {
                return _pokemonImageFrontMale;
            }
            set
            {
                _pokemonImageFrontMale = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonImageBackMale;
        public string PokemonImageBackMale
        {
            get
            {
                return _pokemonImageBackMale;
            }
            set
            {
                _pokemonImageBackMale = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonImageBackFemale;
        public string PokemonImageBackFemale
        {
            get
            {
                return _pokemonImageBackFemale;
            }
            set
            {
                _pokemonImageBackFemale = value;
                OnPropertyChanged();
            }
        }

        private string _pokemonImageFrontFemale;
        public string PokemonImageFrontFemale
        {
            get
            {
                return _pokemonImageFrontFemale;
            }
            set
            {
                _pokemonImageFrontFemale = value;
                OnPropertyChanged();
            }
        }


        #endregion

        private bool _isShiny;
        public bool IsShiny
        {
            get
            {
                return _isShiny;
            }
            set
            {
                _isShiny = value;
                OnPropertyChanged();
            }
        }

        #region Types

        private string _type1;
        public string Type1
        {
            get
            {
                return _type1;
            }
            set
            {
                _type1 = value;
                OnPropertyChanged();
            }
        }

        private string _type2;
        public string Type2
        {
            get
            {
                return _type2;
            }
            set
            {
                _type2 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Ability

        private string _ability1;
        public string Ability1
        {
            get
            {
                return _ability1;
            }
            set
            {
                _ability1 = value;
                OnPropertyChanged();
            }
        }

        private string _ability2;
        public string Ability2
        {
            get
            {
                return _ability2;
            }
            set
            {
                _ability2 = value;
                OnPropertyChanged();
            }
        }


        #endregion


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
