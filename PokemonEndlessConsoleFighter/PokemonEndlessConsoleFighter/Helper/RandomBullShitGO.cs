using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEndlessConsoleFighter.Helper
{
    internal class RandomBullShitGO
    {
        #region Effectiveness Matrix
        /*private static double NormalEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Rock: return 0.5;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Ghost: return 0;
                default: return 1;
            }
        }
        private static double FightingEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Normal: return 2;
                case MonsterType.Rock: return 2;
                case MonsterType.Ice: return 2;
                case MonsterType.Steel: return 2;
                case MonsterType.Dark: return 2;
                case MonsterType.Flying: return 0.5;
                case MonsterType.Poision: return 0.5;
                case MonsterType.Bug: return 0.5;
                case MonsterType.Psychic: return 0.5;
                case MonsterType.Fairy: return 0.5;
                case MonsterType.Ghost: return 0;
                default: return 1;
            }
        }
        private static double FlyingEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Fighting: return 2;
                case MonsterType.Bug: return 2;
                case MonsterType.Grass: return 2;
                case MonsterType.Rock: return 0.5;
                case MonsterType.Electric: return 0.5;
                case MonsterType.Steel: return 0.5;
                default: return 1;
            }
        }
        private static double PoisionEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Grass: return 2;
                case MonsterType.Fairy: return 2;
                case MonsterType.Poision: return 0.5;
                case MonsterType.Ground: return 0.5;
                case MonsterType.Rock: return 0.5;
                case MonsterType.Ghost: return 0.5;
                case MonsterType.Steel: return 0;
                default: return 1;
            }
        }
        private static double GroundEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Poision: return 2;
                case MonsterType.Rock: return 2;
                case MonsterType.Fire: return 2;
                case MonsterType.Electric: return 2;
                case MonsterType.Steel: return 2;
                case MonsterType.Bug: return 0.5;
                case MonsterType.Grass: return 0.5;
                case MonsterType.Flying: return 0;
                default: return 1;
            }
        }
        private static double RockEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Flying: return 2;
                case MonsterType.Bug: return 2;
                case MonsterType.Fire: return 2;
                case MonsterType.Ice: return 2;
                case MonsterType.Fighting: return 0.5;
                case MonsterType.Ground: return 0.5;
                case MonsterType.Steel: return 0.5;
                default: return 1;
            }
        }
        private static double BugEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Grass: return 2;
                case MonsterType.Psychic: return 2;
                case MonsterType.Dark: return 2;
                case MonsterType.Fighting: return 0.5;
                case MonsterType.Flying: return 0.5;
                case MonsterType.Poision: return 0.5;
                case MonsterType.Ghost: return 0.5;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Fire: return 0.5;
                case MonsterType.Fairy: return 0.5;
                default: return 1;
            }
        }
        private static double GhostEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Ghost: return 2;
                case MonsterType.Psychic: return 2;
                case MonsterType.Dark: return 0.5;
                case MonsterType.Normal: return 0;
                default: return 1;
            }
        }
        private static double SteelEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Rock: return 2;
                case MonsterType.Ice: return 2;
                case MonsterType.Fairy: return 2;
                case MonsterType.Steel: return 0.5;
                default: return 1;
            }
        }
        private static double FireEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Bug: return 2;
                case MonsterType.Grass: return 2;
                case MonsterType.Ice: return 2;
                case MonsterType.Steel: return 2;
                case MonsterType.Rock: return 0.5;
                case MonsterType.Fire: return 0.5;
                case MonsterType.Water: return 0.5;
                case MonsterType.Dragon: return 0.5;
                default: return 1;
            }
        }
        private static double WaterEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Ground: return 2;
                case MonsterType.Rock: return 2;
                case MonsterType.Fire: return 2;
                case MonsterType.Water: return 0.5;
                case MonsterType.Grass: return 0.5;
                case MonsterType.Dragon: return 0.5;
                default: return 1;
            }
        }
        private static double GrassEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Ground: return 2;
                case MonsterType.Rock: return 2;
                case MonsterType.Water: return 2;
                case MonsterType.Flying: return 0.5;
                case MonsterType.Poision: return 0.5;
                case MonsterType.Bug: return 0.5;
                case MonsterType.Fire: return 0.5;
                case MonsterType.Grass: return 0.5;
                case MonsterType.Dragon: return 0.5;
                case MonsterType.Steel: return 0.5;
                default: return 1;
            }
        }
        private static double ElectricEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Flying: return 2;
                case MonsterType.Water: return 2;
                case MonsterType.Grass: return 0.5;
                case MonsterType.Electric: return 0.5;
                case MonsterType.Dragon: return 0.5;
                case MonsterType.Ground: return 0;
                default: return 1;
            }
        }
        private static double PsychicEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Fighting: return 2;
                case MonsterType.Poision: return 2;
                case MonsterType.Psychic: return 0.5;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Dark: return 0;
                default: return 1;
            }
        }
        private static double IceEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Flying: return 2;
                case MonsterType.Ground: return 2;
                case MonsterType.Grass: return 2;
                case MonsterType.Dragon: return 2;
                case MonsterType.Water: return 0.5;
                case MonsterType.Ice: return 0.5;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Fire: return 0.5;
                default: return 1;
            }
        }
        private static double DragonEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Dragon: return 2;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Fairy: return 0;
                default: return 1;
            }
        }
        private static double DarkEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Ghost: return 2;
                case MonsterType.Psychic: return 2;
                case MonsterType.Fighting: return 0.5;
                case MonsterType.Dark: return 0.5;
                case MonsterType.Fairy: return 0.5;
                default: return 1;
            }
        }
        private static double FairyEffectiveness(MonsterType defender)
        {
            Logger.LogStart();
            switch (defender)
            {
                case MonsterType.Fighting: return 2;
                case MonsterType.Dragon: return 2;
                case MonsterType.Dark: return 2;
                case MonsterType.Psychic: return 0.5;
                case MonsterType.Steel: return 0.5;
                case MonsterType.Fire: return 0.5;
                default: return 1;
            }
        }*/
        #endregion
        #region LVLing
        public static double Erratic(int lvl)
        {
            if (98 <= lvl && lvl <= 100)
            {
                return Math.Floor(Math.Pow(lvl, 3) * (160 - lvl) / 100d);
            }
            else if (68 <= lvl && lvl <= 98)
            {
                return Math.Floor(Math.Pow(lvl, 3) * Math.Floor((1911 - 10 * lvl) / 3d) / 500d);
            }
            else if (50 <= lvl && lvl < 68)
            {
                return Math.Floor(Math.Pow(lvl, 3) * (150 - lvl) / 100d);
            }
            else //lvl < 50
            {
                return Math.Floor(Math.Pow(lvl, 3) * (100 - lvl) / 50d);
            }
        }
        public static double Fast(int lvl)
        {
            return Math.Floor(4 * Math.Pow(lvl, 3) / 5d);
        }
        public static double MediumFast(int lvl)
        {
            return Math.Floor(Math.Pow(lvl, 3));
        }
        public static double MediumSlow(int lvl)
        {
            return Math.Floor(6 / 5d * Math.Pow(lvl, 3) - 15 * Math.Pow(lvl, 2) + 100 * lvl - 140);
        }
        public static double Slow(int lvl)
        {
            return Math.Floor(5 * Math.Pow(lvl, 3) / 4d);
        }
        public static double Fluctuating(int lvl)
        {
            if (36 <= lvl && lvl <= 100)
            {
                return Math.Floor(Math.Pow(lvl, 3) * (Math.Floor(lvl / 2d) + 32) / 50d);
            }
            else if (15 <= lvl && lvl < 36)
            {
                return Math.Floor(Math.Pow(lvl, 3) * (lvl + 14) / 50d);
            }
            else
            {
                return Math.Floor(Math.Pow(lvl, 3) * (Math.Floor((lvl + 1) / 3d) + 24) / 50d);
            }
        }
        #endregion
    }
}
