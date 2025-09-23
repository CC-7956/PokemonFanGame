using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEndlessConsoleFighter
{
    internal class Trainer
    {
        public string Name { get; set; }
        public List<Pokemon> Inventory { get; set; }
        public Dictionary<int, (string, bool)> Rottom_Pokedex { get; set; }

        public Trainer(string name)
        {
            Name = name;
            Inventory = new List<Pokemon>();
            Rottom_Pokedex = new Dictionary<int, (string, bool)>();
        }

        private Trainer(string name, List<Pokemon> inventory, Dictionary<int, (string, bool)> pokedex)
        {
            Name = name;
            Inventory = inventory;
            Rottom_Pokedex = pokedex;
            foreach (var p in Inventory)
            {
                p.owner = this;
            }
        }

        public void AddPokemon(Pokemon p)
        {
            Inventory.Add(p);
            p.owner = this;
            if (!Rottom_Pokedex.ContainsKey(p.Index))
            {
                Rottom_Pokedex[p.Index] = (p.Name, p.Shiny);
            }
        }

        public string Save()
        {
            return $"{Name}\n" +
                $"{string.Join("|", Inventory.Select(p => p.Index + (p.Shiny ? "S" : "")))}\n" +
                $"{string.Join("|", Rottom_Pokedex.Select(p => p.Key + (p.Value.Item2 ? "S" : "")))}";
        }

        public static Trainer Load()
        {
            string name = "";
            List<Pokemon> inventory = new List<Pokemon>();
            Dictionary<int, (string, bool)> rottom = new Dictionary<int, (string, bool)>();
            
            try
            {
                using (StreamReader sr = new StreamReader("savefile.txt"))
                {
                    name = sr.ReadLine() ?? "Player";
                    string invLine = sr.ReadLine() ?? "";
                    string pokedexLine = sr.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(invLine))
                    {
                        string[] invParts = invLine.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in invParts)
                        {
                            bool shiny = part.EndsWith("S");
                            int index = int.Parse(part.Replace("S", ""));
                            Pokemon p = Pokedex.GetPokemon(index);
                            if (p != null)
                            {
                                p.Shiny = shiny;
                                inventory.Add(p);
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(pokedexLine))
                    {
                        string[] pokedexParts = pokedexLine.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in pokedexParts)
                        {
                            bool shiny = part.EndsWith("S");
                            int index = int.Parse(part.Replace("S", ""));
                            Pokemon p = Pokedex.GetPokemon(index);
                            if (p != null && !rottom.ContainsKey(index))
                            {
                                rottom[index] = (p.Name, shiny);
                            }
                        }
                    }
                    return new Trainer(name, inventory, rottom);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
