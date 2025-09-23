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
                Console.WriteLine($"Welcome back, {player.Name}!");
                Console.ReadKey();
            }
                

            NextAction();

        }

        private static void PlayIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Kanto, the world of Pokemon!");
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine() ?? "Player";
            player = new Trainer(playerName);
            Console.WriteLine($"Hello, {player.Name}! Let's start your adventure!");
            player.AddPokemon(ChooseStarter());
            Console.WriteLine($"You have chosen {player.Inventory.First().Name} as your starter Pokemon.");


            Console.ReadLine();
        }
        private static Pokemon ChooseStarter()
        {
            Console.WriteLine("Choose your starter Pokemon:");
            Console.WriteLine("1. Bulbasaur");
            Console.WriteLine("2. Charmander");
            Console.WriteLine("3. Squirtle");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "1";
            switch (choice)
            {
                case "1":
                    return Pokedex.GetPokemon(1);
                case "2":
                    return Pokedex.GetPokemon(4);
                case "3":
                    return Pokedex.GetPokemon(7);
                default:
                    return Pokedex.GetPokemon(1);
            }
        }

        public static void NextAction()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do next?");
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. View Pokedex");
                Console.WriteLine("3. Save and Exit Game");
                Console.Write("Choice: ");
                string choice = Console.ReadLine() ?? "1";
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Pokemon wildPokemon = Pokedex.GetRandomPokemon();
                        Console.WriteLine($"A wild {wildPokemon} appeared!");
                        StartFight(player.Inventory.First(), wildPokemon);
                        foreach (Pokemon p in player.Inventory)
                        {
                            p.Regenerate();
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Pokedex:");
                        foreach (var entry in player.Rottom_Pokedex)
                        {
                            Console.WriteLine($"{entry.Key}: {(entry.Value.Item2 ? "*" : "")}{entry.Value.Item1}");
                        }
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        NextAction();
                        break;
                }
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            SaveGame();
        }

        private static void StartFight(Pokemon p1, Pokemon p2)
        {
            bool flee = false;
            while (p1.HP > 0 && p2.HP > 0 && p2.owner == null && !flee)
            {
                flee = PrintUI(p1, p2);
                if (flee) break;
                if (p2.HP <= 0) break;
                p2.AttackTarget(p1);
                Console.ReadKey();
            }
            if (p1.HP <= 0)
            {
                Console.WriteLine($"{p1.Name} fainted!");
            }
            if (p2.HP <= 0)
            {
                Console.WriteLine($"{p2.Name} fainted!");
                if (p1.HP > 0)
                {
                    Console.WriteLine($"{p1.Name} gained {p1.GainXP(p2)} Exp!");
                }
            }
            if (p2.owner != null)
            {
                Console.WriteLine($"{p2.Name} was caught!");
            }
            if (flee)
            {
                Console.WriteLine("You fled the battle!");
            }
        }

        private static bool PrintUI(Pokemon p1, Pokemon p2)
        {
            Console.Clear();
            Console.Write(p2 + "\n\n\n");
            Console.Write(p1 + "\n\n\n");

            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Catch");
            Console.WriteLine("4. Flee");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "1";
            Console.WriteLine("\n\n");
            switch (choice)
            {
                case "1":
                    p1.AttackTarget(p2);
                    return false;
                case "2":
                    p1.Heal();
                    return false;
                case "3":
                    p1.Catch(p2);
                    return false;
                case "4":
                    return true;
                default:
                    p1.AttackTarget(p2);
                    return false;
            }
        }

        private static void LoadGame()
        {
            loaded = false;
            Console.Clear();
            Console.WriteLine("Do you want to load a game?\n(y/N)");
            string choice = Console.ReadLine() ?? "n";
            if (choice.ToLower() == "y" || choice.ToLower() == "yes")
            {
                Console.WriteLine("Loading game...");
                player = Trainer.Load();
                if (player == null)
                {
                    Console.WriteLine("Save file is corrupted.");
                    loaded = false;
                    return;
                }
                loaded = true;
                Console.WriteLine("Game loaded");
            }
        }

        private static void SaveGame()
        {
            Console.WriteLine(player.Save());
            Console.WriteLine("Game saved. Goodbye!");
        }
    }
}
