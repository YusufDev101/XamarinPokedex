using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinPokedex.HttpHelpers
{
    public static class HttpHelpers
    {
        public static string BaseUrl { get; private set; } = "https://pokeapi.co/api/v2/pokemon/";
    }
}
