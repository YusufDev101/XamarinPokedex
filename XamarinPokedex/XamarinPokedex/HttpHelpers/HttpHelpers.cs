using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPokedex.HttpHelpers
{
    public static class HttpHelpers
    {
        public static string BaseUrl { get; private set; } = "https://pokeapi.co/api/v2/pokemon/";
        public static string SpeciesUrl { get; private set; } = "https://pokeapi.co/api/v2/pokemon-species/";
        public static string ImageUrl { get; private set; } = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";
    }
}
