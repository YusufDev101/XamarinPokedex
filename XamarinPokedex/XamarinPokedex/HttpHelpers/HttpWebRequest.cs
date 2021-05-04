using Flurl.Http;
using Newtonsoft.Json;
using System;
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
                // Get pokemon.
                var buildString = HttpHelpers.BaseUrl + filter.Trim();

                // Web request.
                var pokemonString = await buildString.GetStringAsync();

                // return Deserialized class object.
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

    }
}
