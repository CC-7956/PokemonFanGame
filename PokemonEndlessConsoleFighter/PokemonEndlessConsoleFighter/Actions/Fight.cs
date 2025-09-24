using PokemonEndlessConsoleFighter.Helper;
using PokemonEndlessConsoleFighter.Objcts;

namespace PokemonEndlessConsoleFighter.Actions
{
    internal class Fight
    {
        private static Pokemon playerActiv;
        internal static void StartFight(Trainer player, Pokemon wildPokemon)
        {
            bool flee = false;
            playerActiv = player.GetFirstActiv();
            
            while (playerActiv.HP > 0 && wildPokemon.HP > 0 && !flee && wildPokemon.owner == null)
            {
                PrintFightUI(playerActiv, wildPokemon);
                switch (ActionHandler.FightAction())
                {
                    case 1: playerActiv.Attack(wildPokemon); break;
                    case 2: playerActiv.Heal(); break;
                    case 3: playerActiv.Catch(wildPokemon); break;
                    case 4: flee = true; break;
                        //switch pokemon
                }
                if (playerActiv.HP <= 0 || wildPokemon.HP <= 0 || flee || wildPokemon.owner != null) break;
                wildPokemon.Attack(playerActiv);
                if (playerActiv.HP <= 0 && player.GetFirstActiv() == null)
                {
                    playerActiv = ActionHandler.ChoosePokemonFromTeam(player, true);
                }
                Console.ReadKey();
            }
            if (playerActiv.HP <= 0)
            {
                PokemonFactory.PrintWithDelay($"{playerActiv.Name} fainted!", 25);
            }
            if (wildPokemon.HP <= 0)
            {
                PokemonFactory.PrintWithDelay($"{wildPokemon.Name} fainted!", 25);
                if (playerActiv.HP > 0)
                {
                    PokemonFactory.PrintWithDelay($"{playerActiv.Name} gained {playerActiv.GainXP(wildPokemon)} Exp!", 25);
                }
            }
            if (wildPokemon.owner != null)
            {
                PokemonFactory.PrintWithDelay($"{wildPokemon.Name} was caught!", 25);
            }
            if (flee)
            {
                PokemonFactory.PrintWithDelay("You fled the battle!", 25);
            }
        }

        private static void PrintFightUI(Pokemon pActiv, Pokemon pTarget)
        {
            Console.Clear();
            Console.Write(pTarget + "\n\n\n");
            Console.Write(pActiv + "\n\n\n");
        }




    }
}
