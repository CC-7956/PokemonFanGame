using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEndlessConsoleFighter
{
    internal class Pokemon
    {
        public string _name { get; set; }
        public int _index { get; set; }
        public bool _shiny { get; set; }

        public Pokemon(Pokedex pokemon)
        {
            _name = pokemon.ToString();
            _index = (int)pokemon;
            _shiny = (new Random().Next(1, 8193) == 1); // 1 in 8192 chance
        }

        public override string ToString()
        {
            if (_shiny)
            {
                return $"A wild shiny {_name} (#{_index}) appeared!";
            }
            else
            {
                return $"A wild {_name} (#{_index}) appeared!";
            }
        }
    }
}
