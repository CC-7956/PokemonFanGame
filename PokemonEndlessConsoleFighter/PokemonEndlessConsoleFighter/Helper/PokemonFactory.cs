using PokemonEndlessConsoleFighter.Dex;
using PokemonEndlessConsoleFighter.Objcts;

namespace PokemonEndlessConsoleFighter.Helper
{
    internal static class PokemonFactory
    {
        public static Pokemon CreatePokemon(int index)
        {
            var basePokemon = FetchPokemon(index);
            if (basePokemon == null)
                throw new ArgumentException($"No Pokemon found with index {index}.");
            var newPokemon = new Pokemon(basePokemon);
            return newPokemon;
        }
        public static Pokemon CreateRandomPokemon()
        {
            return CreatePokemon(new Random().Next(1, Pokedex.PokemonList.Count));
        }

        private static Pokemon FetchPokemon(int index)
        {
            return Pokedex.PokemonList[index];
        }

        public static void PrintWithDelay(string message, int delay)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
