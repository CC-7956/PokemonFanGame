using PokemonEndlessConsoleFighter.Helper;
using PokemonEndlessConsoleFighter.Objcts;

namespace PokemonEndlessConsoleFighter.Actions
{
    internal class ActionHandler
    {
        public static void FreeRoamActions(Trainer player)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                PokemonFactory.PrintWithDelay("What would you like to do next?", 25);
                Console.WriteLine("1. Explore");
                Console.WriteLine("2. View Pokedex");
                Console.WriteLine("3. View Team");
                Console.WriteLine("4. View PC-Box");
                Console.WriteLine("5. Save and Exit Game");
                string choice = GetInput();
                switch (choice)
                {
                    case "1":
                        Pokemon wildPokemon = PokemonFactory.CreateRandomPokemon();
                        wildPokemon.GiveRandomLvl(player);
                        PokemonFactory.PrintWithDelay($"You have encountert a wild {(wildPokemon.Shiny ? "*" : "")}{wildPokemon.Name}", 25);
                        Fight.StartFight(player, wildPokemon);
                        break;
                    case "2":
                        Console.Clear();
                        player.ShowPokedex();
                        break;
                    case "3":
                        Console.Clear();
                        player.ShowTeam();
                        break;
                    case "4":
                        Console.Clear();
                        player.ShowPcBox();
                        break;
                    case "5":
                        exit = true;
                        Runner.SaveGame();
                        break;
                    default:
                        Console.WriteLine("default");
                        break;
                }
                PokemonFactory.PrintWithDelay("\nPress Enter to continue...", 25);
                Console.ReadLine();
            }
        }

        public static int FightAction()
        {
            Console.WriteLine("What will you do?");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Catch");
            Console.WriteLine("4. Flee");
            string choice = GetInput();
            switch (choice)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                default:
                    return 1;
            }
        }
        public static Pokemon ChooseStarter()
        {
            PokemonFactory.PrintWithDelay("Choose your starter Pokemon:", 25);
            Console.WriteLine("1. Bulbasaur");
            Console.WriteLine("2. Charmander");
            Console.WriteLine("3. Squirtle");
            Console.Write("Choice: ");
            string choice = Console.ReadLine() ?? "1";
            switch (choice)
            {
                case "1":
                    return PokemonFactory.CreatePokemon(1);
                case "2":
                    return PokemonFactory.CreatePokemon(4);
                case "3":
                    return PokemonFactory.CreatePokemon(7);
                default:
                    return PokemonFactory.CreatePokemon(1);
            }
        }
        public static Pokemon ChoosePokemonFromTeam(Trainer player, bool mustBeAlive)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose a Pokemon from your team:");
                for (int i = 0; i < player.Team.Count(); i++)
                {
                    Pokemon p = player.Team[i];
                    Console.WriteLine($"{i + 1}. {p.Name} (HP: {p.HP}/{p.MaxHP}) {(p.HP <= 0 ? "[FAINTED]" : "")}");
                }
                Console.Write("Choice: ");
                string choice = GetInput();
                if (int.TryParse(choice, out int index) && index > 0 && index <= player.Team.Count())
                {
                    Pokemon selectedPokemon = player.Team[index - 1];
                    if (mustBeAlive && selectedPokemon.HP <= 0)
                    {
                        Console.WriteLine($"{selectedPokemon.Name} has fainted and cannot be selected. Please choose another Pokemon.");
                        continue;
                    }
                    return selectedPokemon;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
            }
            throw new Exception("Unreachable code");
        }

        private static string GetInput()
        {
            string choice = "";
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.Write("Choice: ");
                choice = Console.ReadLine() ?? "";
            }
            return choice;
        }

    }
}

