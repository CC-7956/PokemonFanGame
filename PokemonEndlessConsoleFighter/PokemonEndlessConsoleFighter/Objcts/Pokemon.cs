using PokemonEndlessConsoleFighter.Enum;
using PokemonEndlessConsoleFighter.Helper;

namespace PokemonEndlessConsoleFighter.Objcts
{
    internal class Pokemon
    {
        private static readonly Random rand = new Random();
        public static int shinyChance = 8192;
        //Direkt info
        public string Name { get; private set; }
        public int Index { get; private set; }
        public (PokemonType main, PokemonType? secondary) _types { get; private set; }
        public int CatchRate { get; private set; }
        public (int? index, int? lvl) NextEvo { get; set; }

        //Static info
        public bool Shiny { get; set; }
        public Trainer? owner { get; set; }
        public int XP { get; set; }
        public int LVL { get; set; }

        //Base stats
        private readonly int BaseHP;
        private readonly int BaseATK;
        private readonly int BaseDEF;
        private readonly int BaseSpeed;
        public int MaxHP;


        //Caclulated stats
        public int HP { get; private set; }
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public int Speed { get; private set; }


        public Pokemon(Pokemon p)
        {
            if (p == null)
                throw new ArgumentNullException(nameof(p), "Cannot copy a null Pokemon.");

            Name = p.Name;
            Index = p.Index;
            _types = p._types;
            CatchRate = p.CatchRate;
            NextEvo = p.NextEvo;

            Shiny = rand.Next(1, shinyChance) == 1;
            owner = p.owner;
            XP = p.XP;
            LVL = p.LVL;

            BaseHP = p.BaseHP;
            BaseATK = p.BaseATK;
            BaseDEF = p.BaseDEF;
            BaseSpeed = p.BaseSpeed;

            MaxHP = CalculateHP(BaseHP);
            ATK = CalculateStatus(BaseATK);
            DEF = CalculateStatus(BaseDEF);
            Speed = CalculateStatus(BaseSpeed);

            HP = MaxHP;
        }

        public Pokemon(string name, int index, int catchrate, int? evoLvl, int? evoIndex, int baseHP, int baseAtk, int baseDef, int baseSpeed, PokemonType t1, PokemonType? t2 = PokemonType.None)
        {
            Name = name;
            Index = index;
            XP = 0;
            _types = (t1, t2);
            CatchRate = catchrate;
            NextEvo = (evoIndex, evoLvl);

            Shiny = rand.Next(1, shinyChance) == 1;
            owner = null;
            LVL = 1;
            XP = 0;

            BaseHP = baseHP;
            BaseATK = baseAtk;
            BaseDEF = baseDef;
            BaseSpeed = baseSpeed;

            MaxHP = CalculateHP(BaseHP);
            ATK = CalculateStatus(BaseATK);
            DEF = CalculateStatus(BaseDEF);
            Speed = CalculateStatus(BaseSpeed);

            HP = MaxHP;
        }

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            if (HP < 0) HP = 0;
        }

        public void Attack(Pokemon target/*, Attack attack*/)
        {
            int power = 40; //attack.Power;
            int baseDMG = (2 * LVL / 5 + 2) * power * ATK / target.DEF / 50 + 2;
            //double dmg = (((((2 * attacker.LVL * crit) / 5 + 2) * Power * attacker.ATK / defender.DEF) / 50) +2) * STAB * effectivenessType1 * effectivenessType2  * ((double)_rand.Next(85,101) / 100d);
            target.TakeDamage(baseDMG);
            PokemonFactory.PrintWithDelay($"{Name} uses Tackle", 25);
            PokemonFactory.PrintWithDelay($"{Name} dealt {baseDMG} damage to {target.Name}.", 25);
        }

        public void Heal()
        {
            int old = HP;
            HP += 20;
            if (MaxHP < HP) HP = MaxHP;
            PokemonFactory.PrintWithDelay($"{Name} healed {HP - old}HP", 25);
        }

        public void Catch(Pokemon target)
        {
            if (CalculateCatch())
            {
                PokemonFactory.PrintWithDelay($"You cought {(target.Shiny ? "*" : "")}{target.Name}.", 25);
                owner.CatchPokemon(target);
                XP += 50;
                LevelUp();
                return;
            }
            PokemonFactory.PrintWithDelay($"{target.Name} broke free.", 25);
        }
        public void Regenerate()
        {
            HP += MaxHP / 4;
        }
        private int CalculateHP(int baseHP)
        {
            int iv = rand.Next(32);
            int ev = rand.Next(253);
            return (2 * baseHP + iv + ev / 4) * LVL / 100 + LVL + 10;
        }

        private int CalculateStatus(int baseStat)
        {
            int iv = rand.Next(32);
            int ev = rand.Next(253);
            return (2 * baseStat + iv + ev / 4) * LVL / 100 + 5;
        }

        private bool CalculateCatch()
        {
            int ballBonus = 1;
            int statusBonus = 1;
            int a = (3 * MaxHP - 2 * HP) * CatchRate * ballBonus / (3 * MaxHP) * statusBonus;
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
                        Task.Delay(50).Wait();
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
            if (XP / (LVL * 100) > 0)
            {
                LVL++;
                XP -= 100;
                MaxHP += 5;
                ATK += 2;
                HP = MaxHP;
                PokemonFactory.PrintWithDelay($"{Name} leveled up! It is now stronger.", 25);
                Evolve();
            }
        }

        private void Evolve()
        {
            if (NextEvo.index != null && NextEvo.lvl != null)
            {
                if (NextEvo.lvl == LVL)
                {
                    owner.PcBox.Remove(this);
                    Pokemon evolved = PokemonFactory.CreatePokemon(NextEvo.index.Value);
                    owner.CatchPokemon(evolved);
                    evolved.XP = XP;
                    evolved.LVL = LVL;
                    evolved.Shiny = Shiny;
                    evolved.HP = (int)Math.Round(MaxHP * 1.2, 0);
                    PokemonFactory.PrintWithDelay($"{Name} has evolved into {evolved.Name}!", 25);
                }
            }
        }

        public int GainXP(Pokemon Target)
        {
            int gained = (int)(10 * LVL / 5d * 1 * Math.Pow((2 * LVL + 10) / (LVL + Target.LVL + 10), 2.5) + 1 * 1 * 1 * 1 * 1 * 1);
            XP += gained;
            return gained;
        }

        public void GiveRandomLvl(Trainer player)
        {
            double counter = 0;
            int avgLvl = 0;
            for (int i = 0; i < player.Team.Length; i++)
            {
                if (player.Team[i] != null)
                {
                    counter++;
                    avgLvl += player.Team[i].LVL;
                }
            }
            avgLvl = (int)Math.Round((double)avgLvl / counter, 0);
            int max = avgLvl + 3;
            int min = avgLvl - 3 <= 0 ? 1 : avgLvl - 3;
            LVL = rand.Next(min, max);
        }

        public string SavePokemon()
        {
            return $"[{(Shiny ? "*" : "")}{Name}; ]";
        }

        public override string ToString()
        {
            return $"{(Shiny ? "* " : "")}" +
                $"{Name}" +
                $" (#{Index}) | " +
                $"HP: {HP} | " +
                $"(ATK:{ATK} DEF:{DEF}) | " +
                $"Type: {_types.main}" +
                $"{(_types.secondary != PokemonType.None ? $"/{_types.secondary}" : "")}";
        }


    }
}
