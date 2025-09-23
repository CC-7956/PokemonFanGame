using System.Data;

namespace PokemonEndlessConsoleFighter
{
    internal class Runner
    {
        static void Main(string[] args)
        {
            int shinys = 0;
            Dictionary<Pokedex, int> encounter = new Dictionary<Pokedex, int>();
            for (int i = 0; i < 100_000; i++)
            {
                Pokedex randomPokemon = GetRandomPokemon();
                Pokemon newPokemon = new Pokemon(randomPokemon);
                PrintPokemon(newPokemon);
                if(newPokemon._shiny)
                {
                    shinys++;
                    if (encounter.ContainsKey(randomPokemon))
                    {
                        encounter[randomPokemon]++;
                    }
                    else
                    {
                        encounter[randomPokemon] = 1;
                    }
                }
                Console.WriteLine("Press Enter to encounter another Pokémon, or type 'exit' to quit.");
                Task.Delay(50).Wait();
                Console.Clear();
            }
            Console.WriteLine($"You have encountered {shinys} shiny Pokémon!");
            foreach (var pokemon in encounter)
            {
                Console.WriteLine($"{pokemon.Key}: {pokemon.Value}");
            }
        }

        private static Pokedex GetRandomPokemon()
        {
            Random rand = new Random();
            int pokeNumber = rand.Next(1, 152); // 1-151 inclusive
            return (Pokedex)pokeNumber;
        }

        private static void PrintPokemon(Pokemon pokemon)
        {
            if (pokemon._shiny)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(pokemon.ToString());
            Console.ResetColor();
        }
    }
}
