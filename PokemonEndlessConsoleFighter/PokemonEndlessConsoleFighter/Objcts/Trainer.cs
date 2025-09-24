using PokemonEndlessConsoleFighter.Helper;

namespace PokemonEndlessConsoleFighter.Objcts
{
    internal class Trainer
    {
        public string Name { get; set; }
        public Pokemon[] Team { get; set; } = new Pokemon[6];
        public List<Pokemon> PcBox { get; set; }
        public Dictionary<int, (string, bool)> Rottom_Pokedex { get; set; }

        public Trainer(string name)
        {
            Name = name;
            PcBox = new List<Pokemon>();
            Rottom_Pokedex = new Dictionary<int, (string, bool)>();
        }

        private Trainer(string name, List<Pokemon> inventory, Dictionary<int, (string, bool)> pokedex)
        {
            Name = name;
            PcBox = inventory;
            Rottom_Pokedex = pokedex;
            foreach (var p in PcBox)
            {
                p.owner = this;
            }
        }

        public void CatchPokemon(Pokemon p)
        {
            p.owner = this;
            PokedexAddPokemon(p);
            for (int i = 0; i < Team.Length; i++)
            {
                if (Team[i] == null)
                {
                    Team[i] = p;
                    return;
                }
            }
            PcBox.Add(p);
            PcBox.Sort((p1, p2) => p1.Index.CompareTo(p2.Index));
        }

        public void PokedexAddPokemon(Pokemon p)
        {
            if (!Rottom_Pokedex.ContainsKey(p.Index))
            {
                Rottom_Pokedex[p.Index] = (p.Name, p.Shiny);
            }
        }

        public void ShowTeam()
        {
            Console.WriteLine($"{Name}'s Team:");
            for (int i = 0; i < Team.Length; i++)
            {
                if (Team[i] != null)
                {
                    var p = Team[i];
                    Console.WriteLine($"{p.Index}. {(p.Shiny ? "*" : "")}{p.Name} (LVL {p.LVL} {p.XP}/{p.LVL * 100}) - HP: {p.HP}/{p.MaxHP}");
                }
                else
                {
                    Console.WriteLine($"[Empty Slot]");
                }
            }
        }

        public void ShowPcBox()
        {
            Console.WriteLine($"{Name}'s PC-Box:");
            foreach (var p in PcBox)
            {
                Console.WriteLine($"{p.Index}. {(p.Shiny ? "*" : "")}{p.Name} (LVL {p.LVL} {p.XP}/{p.LVL * 100}) - HP: {p.HP}/{p.MaxHP}");
            }
        }

        public void ShowPokedex()
        {
            Console.WriteLine($"{Name}'s Rottom Pokedex:");
            foreach (var entry in Rottom_Pokedex)
            {
                Console.WriteLine($"{entry.Key}. {(entry.Value.Item2 ? "*" : "")}{entry.Value.Item1}");
            }
        }

        public Pokemon GetFirstActiv()
        {
            foreach (var p in Team)
            {
                if (p != null && p.HP > 0)
                    return p;
            }
            return null;
        }

        public string Save()
        {
            return $"{Name}\n" +
                $"{string.Join("|", Team.Select(p => p.Index + (p.Shiny ? "S" : "")))}\n" +
                $"{string.Join("|", PcBox.Select(p => p.Index + (p.Shiny ? "S" : "")))}\n" +
                $"{string.Join("|", Rottom_Pokedex.Select(p => p.Key + (p.Value.Item2 ? "S" : "")))}";
        }

        public static Trainer Load()
        {
            string name = "";
            Pokemon[] team = new Pokemon[6];
            List<Pokemon> inventory = new List<Pokemon>();
            Dictionary<int, (string, bool)> rottom = new Dictionary<int, (string, bool)>();

            try
            {
                using (StreamReader sr = new StreamReader("savefile.txt"))
                {
                    name = sr.ReadLine() ?? "Player";
                    string teamLine = sr.ReadLine() ?? "";
                    string invLine = sr.ReadLine() ?? "";
                    string pokedexLine = sr.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(teamLine))
                    {
                        int arrayIndex = 0;
                        string[] teamParts = teamLine.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in teamParts)
                        {
                            bool shiny = part.EndsWith("S");
                            int index = int.Parse(part.Replace("S", ""));
                            Pokemon p = PokemonFactory.CreatePokemon(index);
                            if (p != null)
                            {
                                p.Shiny = shiny;
                                team[arrayIndex] = p;
                                arrayIndex++;
                            }
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(invLine))
                    {
                        string[] invParts = invLine.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        foreach (string part in invParts)
                        {
                            bool shiny = part.EndsWith("S");
                            int index = int.Parse(part.Replace("S", ""));
                            Pokemon p = PokemonFactory.CreatePokemon(index);
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
                            Pokemon p = PokemonFactory.CreatePokemon(index);
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
