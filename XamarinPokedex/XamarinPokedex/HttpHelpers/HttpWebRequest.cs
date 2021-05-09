using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XamarinPokedex.Models;

namespace XamarinPokedex.HttpHelpers
{
    public class HttpWebRequest
    {
        public HttpWebRequest()
        {

        }

        internal async Task<PokemonObject> GetPokemon(string filter)
        {
            try
            {
                // Get Pokemon.
                var buildString = HttpHelpers.BaseUrl + filter.Trim();

                // Web request.
                var pokemonString = await buildString.GetStringAsync();

                // return De-serialized class object.
                return JsonConvert.DeserializeObject<PokemonObject>(pokemonString);
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // handle timeout
                throw ex;
            }
            catch (FlurlHttpException ex)
            {
                // handle error response
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<PokemonSummaryObject> GetPokemonSummary(int filter)
        {
            try
            {
                // Get Pokemon.
                var buildString = HttpHelpers.SpeciesUrl + filter.ToString().Trim();

                // Web request.
                var pokemonString = await buildString.GetStringAsync();

                // return De-serialized class object.
                return JsonConvert.DeserializeObject<PokemonSummaryObject>(pokemonString.ToString());
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // handle timeout
                throw ex;
            }
            catch (FlurlHttpException ex)
            {
                // handle error response
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<PokemonEvolutionObject> GetPokemonEvolution(string evolutionUrl)
        {
            try
            {
                // Get Pokemon.
                var buildString = evolutionUrl.Trim();

                // Web request.
                var pokemonString = await buildString.GetStringAsync();

                // return De-serialized class object.
                return JsonConvert.DeserializeObject<PokemonEvolutionObject>(pokemonString.ToString());
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // handle timeout
                throw ex;
            }
            catch (FlurlHttpException ex)
            {
                // handle error response
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal async Task<string> GetPokemonImage(string image)
        {
            try
            {
                // filter the string.
                var result = image.Substring(image.LastIndexOf(@"pokemon-species"), (image.Length - image.LastIndexOf(@"pokemon-species")));
                Regex rgx = new Regex("[^0-9]");
                result = rgx.Replace(result, "");

                // Get Pokemon.
                var buildString = HttpHelpers.ImageUrl + result.ToString() + ".png";

                return buildString;
            }
            catch (FlurlHttpTimeoutException ex)
            {
                // handle timeout
                throw ex;
            }
            catch (FlurlHttpException ex)
            {
                // handle error response
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
