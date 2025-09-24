using PokemonEndlessConsoleFighter.Actions;
using PokemonEndlessConsoleFighter.Helper;
using PokemonEndlessConsoleFighter.Objcts;

namespace PokemonEndlessConsoleFighter
{
    internal class Runner
    {
        private static Trainer player;
        private static bool loaded = false;
        static void Main(string[] args)
        {
            LoadGame();
            if (!loaded)
                PlayIntro();
            else
            {
                PokemonFactory.PrintWithDelay($"Welcome back, {player.Name}!", 25);
                Console.ReadKey();
            }

            ActionHandler.FreeRoamActions(player);
        }

        private static void PlayIntro()
        {
            Console.Clear();
            PokemonFactory.PrintWithDelay("Welcome to Kanto, the world of Pokemon!", 25);
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "Player";
            player = new Trainer(playerName);
            Console.Clear();
            PokemonFactory.PrintWithDelay($"Hello, {player.Name}! Let's start your adventure!", 25);
            player.CatchPokemon(ActionHandler.ChooseStarter());
            Console.Clear();
            PokemonFactory.PrintWithDelay($"You have chosen {player.Team[0].Name} as your starter Pokemon.", 25);


            Console.ReadLine();
        }

        private static void LoadGame()
        {
            loaded = false;
            Console.Clear();
            PokemonFactory.PrintWithDelay("Do you want to load a game?\n(y/N)", 25);
            string choice = Console.ReadLine() ?? "n";
            if (choice.ToLower() == "y" || choice.ToLower() == "yes")
            {
                PokemonFactory.PrintWithDelay("Loading game...", 25);
                player = Trainer.Load();
                if (player == null)
                {
                    PokemonFactory.PrintWithDelay("Save file is corrupted.", 25);
                    loaded = false;
                    return;
                }
                loaded = true;
                PokemonFactory.PrintWithDelay("Game loaded", 25);
            }
        }

        public static void SaveGame()
        {
            Console.WriteLine(player.Save());
            PokemonFactory.PrintWithDelay("Game saved. Goodbye!", 25);
        }



    }
}
