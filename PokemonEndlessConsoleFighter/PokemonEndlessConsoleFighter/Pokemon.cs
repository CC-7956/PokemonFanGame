namespace PokemonEndlessConsoleFighter
{
    internal class Pokemon
    {
        public static int shinyChance = 8192;
        public string Name { get; private set; }
        public int Index { get; private set; }
        public string Attack { get; private set; }
        public int HP { get; private set; }
        public int MaxHP { get; private set; }
        public int DMG { get; private set; }
        public (PokemonType, PokemonType?) _types { get; private set; }
        public int CatchRate { get; private set; }
        public Trainer owner { get; set; }
        public bool Shiny { get; set; }
        public int XP { get; set; }
        public int LVL { get; set; }
        public int? NextEvo { get; set; }



        public Pokemon(string name, int index, int hp, string attack, int dmg, int catchrate, int? nextevo, PokemonType t1, PokemonType? t2 = PokemonType.None)
        {
            Name = name;
            Index = index;
            HP = hp;
            MaxHP = hp;
            Attack = attack;
            DMG = dmg;
            CatchRate = catchrate;
            owner = null;
            XP = 0;
            LVL = 1;
            NextEvo = nextevo;
            _types = (t1, t2);
            Shiny = (new Random().Next(1, shinyChance) == 1);
        }

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP < 0) HP = 0;
        }

        public void AttackTarget(Pokemon target)
        {
            Console.WriteLine($"{Name} uses {Attack}");
            target.TakeDamage(DMG);
        }

        public void Heal()
        {
            HP += 20;
            if (MaxHP < HP) HP = MaxHP;
        }

        public void Catch(Pokemon target)
        {
            if (CalculateCatch())
            {
                Console.WriteLine($"You cought {(target.Shiny ? "*" : "")}{target.Name}.");
                owner.AddPokemon(target);
                XP += 50;
                LevelUp();
            }
            Console.WriteLine($"{target.Name} broke free.");
        }
        public void Regenerate()
        {
            HP += MaxHP / 4;
        }

        private bool CalculateCatch()
        {
            int ballBonus = 1;
            int statusBonus = 1;
            int a = ((3 * MaxHP - 2 * HP) * CatchRate * ballBonus) / (3 * MaxHP) * statusBonus;
            if (a >= 255)
            {
                return true;
            }
            else
            {
                int b = 1048560 / (int)Math.Sqrt(Math.Sqrt(16711680 / a));
                Random rand = new Random();
                int shakeCount = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (rand.Next(0, 65536) < b)
                    {
                        shakeCount++;
                        Console.WriteLine("*Ball shakes*");
                    }
                    else
                    {
                        break;
                    }
                }
                if (shakeCount == 4)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void LevelUp()
        {
            if (XP / LVL * 100 > 0)
            {
                LVL++;
                XP -= 100;
                MaxHP += 5;
                DMG += 2;
                HP = MaxHP;
                Console.WriteLine($"{Name} leveled up! It is now stronger.");
                Evolve();
            }
        }

        private void Evolve()
        {
            if (NextEvo != null)
            {
                if (NextEvo == LVL)
                {
                    owner.Inventory.Remove(this);
                    Pokemon evolved = Pokedex.GetPokemon(Index + 1);
                    owner.AddPokemon(evolved);
                    evolved.XP = XP;
                    evolved.LVL = LVL;
                    evolved.Shiny = Shiny;
                    evolved.HP = (int)Math.Round(MaxHP * 1.2, 0);
                    Console.WriteLine($"{Name} has evolved!");
                }
            }
        }

        public int GainXP(Pokemon Target)
        {
            int gained = (int)(((10 * this.LVL) / 5d) * 1 * Math.Pow((2 * this.LVL + 10) / (this.LVL + Target.LVL + 10), 2.5) + 1 * 1 * 1 * 1 * 1 * 1);
            XP += gained;
            return gained;
        }

        public override string ToString()
        {
            return $"{(Shiny ? "* " : "")}" +
                $"{Name}" +
                $" (#{Index}) | " +
                $"HP: {HP} | " +
                $"{Attack} " +
                $"({DMG} DMG) | " +
                $"Type: {_types.Item1}" +
                $"{(_types.Item2 != PokemonType.None ? $"/{_types.Item2}" : "")}";
        }


    }
}
