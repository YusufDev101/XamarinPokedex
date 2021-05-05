using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinPokedex.Helpers
{
    public static class MethodHelpers
    {
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        public static string SetColor(string name)
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
    }
}
