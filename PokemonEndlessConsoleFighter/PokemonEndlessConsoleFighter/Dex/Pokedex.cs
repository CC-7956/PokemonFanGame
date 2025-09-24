using PokemonEndlessConsoleFighter.Enum;
using PokemonEndlessConsoleFighter.Objcts;

namespace PokemonEndlessConsoleFighter.Dex
{
    internal static class Pokedex
    {
        private static readonly Random random = new Random();

        public static readonly Dictionary<int, Pokemon> PokemonList = new Dictionary<int, Pokemon>
        {
            // Gen1 Pokémon database (1..151)
            // Format: { index, new Pokemon("Name", index, catchrate, evoLvl(null if not set), evoIndex(null if none), baseHP, baseAtk, baseDef, baseSpeed, PokemonType.T1, PokemonType.T2) }, // comment: evolution info

            { 1, new Pokemon("Bulbasaur", 1, 45, null, 2, 45, 49, 49, 45, PokemonType.Grass, PokemonType.Poison) }, // evolves -> Ivysaur (level 16)
            { 2, new Pokemon("Ivysaur", 2, 45, null, 3, 60, 62, 63, 60, PokemonType.Grass, PokemonType.Poison) }, // evolves -> Venusaur (level 32)
            { 3, new Pokemon("Venusaur", 3, 45, null, null, 80, 82, 83, 80, PokemonType.Grass, PokemonType.Poison) }, // no evo
            
            { 4, new Pokemon("Charmander", 4, 45, null, 5, 39, 52, 43, 65, PokemonType.Fire, PokemonType.None) }, // evolves -> Charmeleon (level 16)
            { 5, new Pokemon("Charmeleon", 5, 45, null, 6, 58, 64, 58, 80, PokemonType.Fire, PokemonType.None) }, // evolves -> Charizard (level 36)
            { 6, new Pokemon("Charizard", 6, 45, null, null, 78, 84, 78, 100, PokemonType.Fire, PokemonType.Flying) }, // no evo
            
            { 7, new Pokemon("Squirtle", 7, 45, null, 8, 44, 48, 65, 43, PokemonType.Water, PokemonType.None) }, // -> Wartortle (level 16)
            { 8, new Pokemon("Wartortle", 8, 45, null, 9, 59, 63, 80, 58, PokemonType.Water, PokemonType.None) }, // -> Blastoise (level 36)
            { 9, new Pokemon("Blastoise", 9, 45, null, null, 79, 83, 100, 78, PokemonType.Water, PokemonType.None) }, // no evo
            
            { 10, new Pokemon("Caterpie", 10, 255, null, 11, 45, 30, 35, 45, PokemonType.Bug, PokemonType.None) }, // -> Metapod (level 7)
            { 11, new Pokemon("Metapod", 11, 120, null, 12, 50, 20, 55, 30, PokemonType.Bug, PokemonType.None) }, // -> Butterfree (level 10)
            { 12, new Pokemon("Butterfree", 12, 45, null, null, 60, 45, 50, 70, PokemonType.Bug, PokemonType.Flying) }, // no evo
            
            { 13, new Pokemon("Weedle", 13, 255, null, 14, 40, 35, 30, 50, PokemonType.Bug, PokemonType.Poison) }, // -> Kakuna (level 7)
            { 14, new Pokemon("Kakuna", 14, 120, null, 15, 45, 25, 50, 35, PokemonType.Bug, PokemonType.Poison) }, // -> Beedrill (level 10)
            { 15, new Pokemon("Beedrill", 15, 45, null, null, 65, 80, 40, 75, PokemonType.Bug, PokemonType.Poison) }, // no evo
            
            { 16, new Pokemon("Pidgey", 16, 255, null, 17, 40, 45, 40, 56, PokemonType.Normal, PokemonType.Flying) }, // -> Pidgeotto (level 18)
            { 17, new Pokemon("Pidgeotto", 17, 120, null, 18, 63, 60, 55, 71, PokemonType.Normal, PokemonType.Flying) }, // -> Pidgeot (level 36)
            { 18, new Pokemon("Pidgeot", 18, 45, null, null, 83, 80, 75, 91, PokemonType.Normal, PokemonType.Flying) }, // no evo
            
            { 19, new Pokemon("Rattata", 19, 255, null, 20, 30, 56, 35, 72, PokemonType.Normal, PokemonType.None) }, // -> Raticate (level 20)
            { 20, new Pokemon("Raticate", 20, 127, null, null, 55, 81, 60, 97, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 21, new Pokemon("Spearow", 21, 255, null, 22, 40, 60, 30, 70, PokemonType.Normal, PokemonType.Flying) }, // -> Fearow (level 20)
            { 22, new Pokemon("Fearow", 22, 90, null, null, 65, 90, 65, 100, PokemonType.Normal, PokemonType.Flying) }, // no evo
            
            { 23, new Pokemon("Ekans", 23, 255, null, 24, 35, 60, 44, 55, PokemonType.Poison, PokemonType.None) }, // -> Arbok (level 22)
            { 24, new Pokemon("Arbok", 24, 90, null, null, 60, 85, 69, 80, PokemonType.Poison, PokemonType.None) }, // no evo
            
            { 25, new Pokemon("Pikachu", 25, 190, null, 26, 35, 55, 30, 90, PokemonType.Electric, PokemonType.None) }, // -> Raichu (via Thunder Stone)
            { 26, new Pokemon("Raichu", 26, 75, null, null, 60, 90, 55, 100, PokemonType.Electric, PokemonType.None) }, // no evo
            
            { 27, new Pokemon("Sandshrew", 27, 255, null, 28, 50, 75, 85, 40, PokemonType.Ground, PokemonType.None) }, // -> Sandslash (level 22)
            { 28, new Pokemon("Sandslash", 28, 90, null, null, 75, 100, 110, 65, PokemonType.Ground, PokemonType.None) }, // no evo
            
            { 29, new Pokemon("Nidoran♀", 29, 235, null, 30, 55, 47, 52, 41, PokemonType.Poison, PokemonType.None) }, // -> Nidorina (level 16)
            { 30, new Pokemon("Nidorina", 30, 120, null, 31, 70, 62, 67, 56, PokemonType.Poison, PokemonType.None) }, // -> Nidoqueen (via Moon Stone)
            { 31, new Pokemon("Nidoqueen", 31, 45, null, null, 90, 82, 87, 76, PokemonType.Poison, PokemonType.Ground) }, // no evo
            
            { 32, new Pokemon("Nidoran♂", 32, 235, null, 33, 46, 57, 40, 50, PokemonType.Poison, PokemonType.None) }, // -> Nidorino (level 16)
            { 33, new Pokemon("Nidorino", 33, 120, null, 34, 61, 72, 57, 65, PokemonType.Poison, PokemonType.None) }, // -> Nidoking (via Moon Stone)
            { 34, new Pokemon("Nidoking", 34, 45, null, null, 81, 92, 77, 85, PokemonType.Poison, PokemonType.Ground) }, // no evo
            
            { 35, new Pokemon("Clefairy", 35, 150, null, 36, 70, 45, 48, 35, PokemonType.Fairy, PokemonType.None) }, // -> Clefable (via Moon Stone)
            { 36, new Pokemon("Clefable", 36, 25, null, null, 95, 70, 73, 60, PokemonType.Fairy, PokemonType.None) }, // no evo
            
            { 37, new Pokemon("Vulpix", 37, 190, null, 38, 38, 41, 40, 65, PokemonType.Fire, PokemonType.None) }, // -> Ninetales (via Fire Stone)
            { 38, new Pokemon("Ninetales", 38, 75, null, null, 73, 76, 75, 100, PokemonType.Fire, PokemonType.None) }, // no evo
            
            { 39, new Pokemon("Jigglypuff", 39, 170, null, 40, 115, 45, 20, 20, PokemonType.Normal, PokemonType.Fairy) }, // -> Wigglytuff (via Moon Stone)
            { 40, new Pokemon("Wigglytuff", 40, 50, null, null, 140, 70, 45, 45, PokemonType.Normal, PokemonType.Fairy) }, // no evo
            
            { 41, new Pokemon("Zubat", 41, 255, null, 42, 40, 45, 35, 55, PokemonType.Poison, PokemonType.Flying) }, // -> Golbat (level 22)
            { 42, new Pokemon("Golbat", 42, 90, null, null, 75, 80, 70, 90, PokemonType.Poison, PokemonType.Flying) }, // no evo
            
            { 43, new Pokemon("Oddish", 43, 255, null, 44, 45, 50, 55, 30, PokemonType.Grass, PokemonType.Poison) }, // -> Gloom (level 21)
            { 44, new Pokemon("Gloom", 44, 120, null, 45, 60, 65, 70, 40, PokemonType.Grass, PokemonType.Poison) }, // -> Vileplume (via Leaf Stone) OR Bellossom (Gen2+, ignore)
            { 45, new Pokemon("Vileplume", 45, 45, null, null, 75, 80, 85, 50, PokemonType.Grass, PokemonType.Poison) }, // no evo
            
            { 46, new Pokemon("Paras", 46, 190, null, 47, 35, 70, 55, 25, PokemonType.Bug, PokemonType.Grass) }, // -> Parasect (level 24)
            { 47, new Pokemon("Parasect", 47, 75, null, null, 60, 95, 80, 30, PokemonType.Bug, PokemonType.Grass) }, // no evo
            
            { 48, new Pokemon("Venonat", 48, 190, null, 49, 60, 55, 50, 45, PokemonType.Bug, PokemonType.Poison) }, // -> Venomoth (level 31)
            { 49, new Pokemon("Venomoth", 49, 75, null, null, 70, 65, 60, 90, PokemonType.Bug, PokemonType.Poison) }, // no evo
            
            { 50, new Pokemon("Diglett", 50, 255, null, 51, 10, 55, 25, 95, PokemonType.Ground, PokemonType.None) }, // -> Dugtrio (level 26)
            { 51, new Pokemon("Dugtrio", 51, 50, null, null, 35, 80, 50, 120, PokemonType.Ground, PokemonType.None) }, // no evo
            
            { 52, new Pokemon("Meowth", 52, 255, null, 53, 40, 45, 35, 90, PokemonType.Normal, PokemonType.None) }, // -> Persian (level 28)
            { 53, new Pokemon("Persian", 53, 90, null, null, 65, 70, 60, 115, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 54, new Pokemon("Psyduck", 54, 190, null, 55, 50, 52, 48, 55, PokemonType.Water, PokemonType.None) }, // -> Golduck (level 33)
            { 55, new Pokemon("Golduck", 55, 75, null, null, 80, 82, 78, 85, PokemonType.Water, PokemonType.None) }, // no evo
            
            { 56, new Pokemon("Mankey", 56, 190, null, 57, 40, 80, 35, 70, PokemonType.Fighting, PokemonType.None) }, // -> Primeape (level 28)
            { 57, new Pokemon("Primeape", 57, 75, null, null, 65, 105, 60, 95, PokemonType.Fighting, PokemonType.None) }, // no evo
            
            { 58, new Pokemon("Growlithe", 58, 190, null, 59, 55, 70, 45, 60, PokemonType.Fire, PokemonType.None) }, // -> Arcanine (via Fire Stone in Gen1? actually Arcanine obtained via item in some gens; mark as item)
            { 59, new Pokemon("Arcanine", 59, 75, null, null, 90, 110, 80, 95, PokemonType.Fire, PokemonType.None) }, // no evo
            
            { 60, new Pokemon("Poliwag", 60, 255, null, 61, 40, 50, 40, 90, PokemonType.Water, PokemonType.None) }, // -> Poliwhirl (level 25)
            { 61, new Pokemon("Poliwhirl", 61, 130, null, 62, 65, 65, 65, 90, PokemonType.Water, PokemonType.None) }, // -> Poliwrath (via Water Stone) OR Politoed (Gen2+)
            { 62, new Pokemon("Poliwrath", 62, 60, null, null, 90, 85, 95, 70, PokemonType.Water, PokemonType.Fighting) }, // no evo
            
            { 63, new Pokemon("Abra", 63, 200, null, 64, 25, 20, 15, 90, PokemonType.Psychic, PokemonType.None) }, // -> Kadabra (level 16)
            { 64, new Pokemon("Kadabra", 64, 100, null, 65, 40, 35, 30, 105, PokemonType.Psychic, PokemonType.None) }, // -> Alakazam (via Trade)
            { 65, new Pokemon("Alakazam", 65, 50, null, null, 55, 50, 45, 120, PokemonType.Psychic, PokemonType.None) }, // no evo
            
            { 66, new Pokemon("Machop", 66, 180, null, 67, 70, 80, 50, 35, PokemonType.Fighting, PokemonType.None) }, // -> Machoke (level 28)
            { 67, new Pokemon("Machoke", 67, 90, null, 68, 80, 100, 70, 45, PokemonType.Fighting, PokemonType.None) }, // -> Machamp (via Trade)
            { 68, new Pokemon("Machamp", 68, 45, null, null, 90, 130, 80, 55, PokemonType.Fighting, PokemonType.None) }, // no evo
            
            { 69, new Pokemon("Bellsprout", 69, 255, null, 70, 50, 75, 35, 40, PokemonType.Grass, PokemonType.Poison) }, // -> Weepinbell (level 21)
            { 70, new Pokemon("Weepinbell", 70, 120, null, 71, 65, 90, 50, 55, PokemonType.Grass, PokemonType.Poison) }, // -> Victreebel (via Leaf Stone)
            { 71, new Pokemon("Victreebel", 71, 45, null, null, 80, 105, 65, 70, PokemonType.Grass, PokemonType.Poison) }, // no evo
            
            { 72, new Pokemon("Tentacool", 72, 190, null, 73, 40, 40, 35, 70, PokemonType.Water, PokemonType.Poison) }, // -> Tentacruel (level 30)
            { 73, new Pokemon("Tentacruel", 73, 60, null, null, 80, 70, 65, 100, PokemonType.Water, PokemonType.Poison) }, // no evo
            
            { 74, new Pokemon("Geodude", 74, 255, null, 75, 40, 80, 100, 20, PokemonType.Rock, PokemonType.Ground) }, // -> Graveler (level 25)
            { 75, new Pokemon("Graveler", 75, 120, null, 76, 55, 95, 115, 35, PokemonType.Rock, PokemonType.Ground) }, // -> Golem (via Trade)
            { 76, new Pokemon("Golem", 76, 45, null, null, 80, 110, 130, 45, PokemonType.Rock, PokemonType.Ground) }, // no evo
            
            { 77, new Pokemon("Ponyta", 77, 190, null, 78, 50, 85, 55, 90, PokemonType.Fire, PokemonType.None) }, // -> Rapidash (level 40)
            { 78, new Pokemon("Rapidash", 78, 60, null, null, 65, 100, 70, 105, PokemonType.Fire, PokemonType.None) }, // no evo
            
            { 79, new Pokemon("Slowpoke", 79, 190, null, 80, 90, 65, 65, 15, PokemonType.Water, PokemonType.Psychic) }, // -> Slowbro (level 37) OR Slowking (Gen2+ via trade+item)
            { 80, new Pokemon("Slowbro", 80, 75, null, null, 95, 75, 110, 30, PokemonType.Water, PokemonType.Psychic) }, // no evo
            
            { 81, new Pokemon("Magnemite", 81, 190, null, 82, 25, 35, 70, 45, PokemonType.Electric, PokemonType.Steel) }, // -> Magneton (level 30)
            { 82, new Pokemon("Magneton", 82, 60, null, null, 50, 60, 95, 70, PokemonType.Electric, PokemonType.Steel) }, // no evo (Gen4+ has Magnezone)
            
            { 83, new Pokemon("Farfetch'd", 83, 45, null, null, 52, 65, 55, 60, PokemonType.Normal, PokemonType.Flying) }, // no evo (Galar form evolves Gen8)
            
            { 84, new Pokemon("Doduo", 84, 190, null, 85, 35, 85, 45, 75, PokemonType.Normal, PokemonType.Flying) }, // -> Dodrio (level 31)
            { 85, new Pokemon("Dodrio", 85, 45, null, null, 60, 110, 70, 100, PokemonType.Normal, PokemonType.Flying) }, // no evo
            
            { 86, new Pokemon("Seel", 86, 190, null, 87, 65, 45, 55, 45, PokemonType.Water, PokemonType.None) }, // -> Dewgong (level 34)
            { 87, new Pokemon("Dewgong", 87, 75, null, null, 90, 70, 80, 70, PokemonType.Water, PokemonType.Ice) }, // no evo
            
            { 88, new Pokemon("Grimer", 88, 190, null, 89, 80, 80, 50, 25, PokemonType.Poison, PokemonType.None) }, // -> Muk (level 38)
            { 89, new Pokemon("Muk", 89, 75, null, null, 105, 105, 75, 50, PokemonType.Poison, PokemonType.None) }, // no evo
            
            { 90, new Pokemon("Shellder", 90, 190, null, 91, 30, 65, 100, 40, PokemonType.Water, PokemonType.None) }, // -> Cloyster (via Water Stone)
            { 91, new Pokemon("Cloyster", 91, 60, null, null, 50, 95, 180, 70, PokemonType.Water, PokemonType.Ice) }, // no evo
            
            { 92, new Pokemon("Gastly", 92, 190, null, 93, 30, 35, 30, 80, PokemonType.Ghost, PokemonType.Poison) }, // -> Haunter (level 25)
            { 93, new Pokemon("Haunter", 93, 90, null, 94, 45, 50, 45, 95, PokemonType.Ghost, PokemonType.Poison) }, // -> Gengar (via Trade)
            { 94, new Pokemon("Gengar", 94, 45, null, null, 60, 65, 60, 110, PokemonType.Ghost, PokemonType.Poison) }, // no evo
            
            { 95, new Pokemon("Onix", 95, 45, null, null, 35, 45, 160, 70, PokemonType.Rock, PokemonType.Ground) }, // no evo (Steelix Gen2+)
            
            { 96, new Pokemon("Drowzee", 96, 190, null, 97, 60, 48, 45, 42, PokemonType.Psychic, PokemonType.None) }, // -> Hypno (level 26)
            { 97, new Pokemon("Hypno", 97, 75, null, null, 85, 73, 70, 67, PokemonType.Psychic, PokemonType.None) }, // no evo
            
            { 98, new Pokemon("Krabby", 98, 225, null, 99, 30, 105, 90, 50, PokemonType.Water, PokemonType.None) }, // -> Kingler (level 28)
            { 99, new Pokemon("Kingler", 99, 60, null, null, 55, 130, 115, 75, PokemonType.Water, PokemonType.None) }, // no evo
            
            { 100, new Pokemon("Voltorb", 100, 255, null, 101, 40, 30, 50, 100, PokemonType.Electric, PokemonType.None) }, // -> Electrode (level 30)
            { 101, new Pokemon("Electrode", 101, 60, null, null, 60, 50, 70, 140, PokemonType.Electric, PokemonType.None) }, // no evo
            
            { 102, new Pokemon("Exeggcute", 102, 90, null, 103, 60, 40, 80, 40, PokemonType.Grass, PokemonType.Psychic) }, // -> Exeggutor (via Leaf Stone)
            { 103, new Pokemon("Exeggutor", 103, 45, null, null, 95, 95, 85, 55, PokemonType.Grass, PokemonType.Psychic) }, // no evo
            
            { 104, new Pokemon("Cubone", 104, 190, null, 105, 50, 50, 95, 35, PokemonType.Ground, PokemonType.None) }, // -> Marowak (level 28)
            { 105, new Pokemon("Marowak", 105, 75, null, null, 60, 80, 110, 45, PokemonType.Ground, PokemonType.None) }, // no evo
            
            { 106, new Pokemon("Hitmonlee", 106, 45, null, null, 50, 120, 53, 87, PokemonType.Fighting, PokemonType.None) }, // no evo (fighting starters / breeding)
            { 107, new Pokemon("Hitmonchan", 107, 45, null, null, 50, 105, 79, 76, PokemonType.Fighting, PokemonType.None) }, // no evo
            
            { 108, new Pokemon("Lickitung", 108, 45, null, null, 90, 55, 75, 30, PokemonType.Normal, PokemonType.None) }, // no evo (Lickilicky Gen4+)
            
            { 109, new Pokemon("Koffing", 109, 190, null, 110, 40, 65, 95, 35, PokemonType.Poison, PokemonType.None) }, // -> Weezing (level 35)
            { 110, new Pokemon("Weezing", 110, 60, null, null, 65, 90, 120, 60, PokemonType.Poison, PokemonType.None) }, // no evo
            
            { 111, new Pokemon("Rhyhorn", 111, 120, null, 112, 80, 85, 95, 25, PokemonType.Ground, PokemonType.Rock) }, // -> Rhydon (level 42)
            { 112, new Pokemon("Rhydon", 112, 60, null, null, 105, 130, 120, 40, PokemonType.Ground, PokemonType.Rock) }, // no evo (Rhyperior Gen4+ via trade+item)
            
            { 113, new Pokemon("Chansey", 113, 30, null, null, 250, 5, 5, 50, PokemonType.Normal, PokemonType.None) }, // no evo (Blissey Gen2+)
            
            { 114, new Pokemon("Tangela", 114, 45, null, null, 65, 55, 115, 60, PokemonType.Grass, PokemonType.None) }, // no evo (Tangrowth Gen4+)
            
            { 115, new Pokemon("Kangaskhan", 115, 45, null, null, 105, 95, 80, 90, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 116, new Pokemon("Horsea", 116, 225, null, 117, 30, 40, 70, 60, PokemonType.Water, PokemonType.None) }, // -> Seadra (level 32)
            { 117, new Pokemon("Seadra", 117, 75, null, null, 55, 65, 95, 85, PokemonType.Water, PokemonType.None) }, // no evo (Kingdra Gen2+)
            
            { 118, new Pokemon("Goldeen", 118, 225, null, 119, 45, 67, 60, 63, PokemonType.Water, PokemonType.None) }, // -> Seaking (level 33)
            { 119, new Pokemon("Seaking", 119, 60, null, null, 80, 92, 65, 68, PokemonType.Water, PokemonType.None) }, // no evo
            
            { 120, new Pokemon("Staryu", 120, 225, null, 121, 30, 45, 55, 85, PokemonType.Water, PokemonType.None) }, // -> Starmie (via Water Stone)
            { 121, new Pokemon("Starmie", 121, 60, null, null, 60, 75, 85, 115, PokemonType.Water, PokemonType.Psychic) }, // no evo
            
            { 122, new Pokemon("Mr. Mime", 122, 45, null, null, 40, 45, 65, 90, PokemonType.Psychic, PokemonType.Fairy) }, // no evo
            
            { 123, new Pokemon("Scyther", 123, 45, null, null, 70, 110, 80, 105, PokemonType.Bug, PokemonType.Flying) }, // no evo (Scizor Gen2+ via Trade+Metal Coat)
            
            { 124, new Pokemon("Jynx", 124, 45, null, null, 65, 50, 35, 95, PokemonType.Ice, PokemonType.Psychic) }, // no evo
            
            { 125, new Pokemon("Electabuzz", 125, 45, null, null, 65, 83, 57, 105, PokemonType.Electric, PokemonType.None) }, // no evo (Electivire Gen4+)
            
            { 126, new Pokemon("Magmar", 126, 45, null, null, 65, 95, 57, 93, PokemonType.Fire, PokemonType.None) }, // no evo (Magmortar Gen4+)
            
            { 127, new Pokemon("Pinsir", 127, 45, null, null, 65, 125, 100, 85, PokemonType.Bug, PokemonType.None) }, // no evo
            
            { 128, new Pokemon("Tauros", 128, 45, null, null, 75, 100, 95, 110, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 129, new Pokemon("Magikarp", 129, 255, null, 130, 20, 10, 55, 80, PokemonType.Water, PokemonType.None) }, // -> Gyarados (level 20)
            { 130, new Pokemon("Gyarados", 130, 45, null, null, 95, 125, 79, 81, PokemonType.Water, PokemonType.Flying) }, // no evo
            
            { 131, new Pokemon("Lapras", 131, 45, null, null, 130, 85, 80, 60, PokemonType.Water, PokemonType.Ice) }, // no evo
            
            { 132, new Pokemon("Ditto", 132, 35, null, null, 48, 48, 48, 48, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 133, new Pokemon("Eevee", 133, 45, null, 134, 55, 55, 50, 55, PokemonType.Normal, PokemonType.None) }, // -> Vaporeon/Jolteon/Flareon (via Water/Thunder/Fire Stone)
            { 134, new Pokemon("Vaporeon", 134, 45, null, null, 130, 65, 60, 65, PokemonType.Water, PokemonType.None) }, // no evo
            { 135, new Pokemon("Jolteon", 135, 45, null, null, 65, 65, 60, 130, PokemonType.Electric, PokemonType.None) }, // no evo
            { 136, new Pokemon("Flareon", 136, 45, null, null, 65, 130, 60, 65, PokemonType.Fire, PokemonType.None) }, // no evo
            
            { 137, new Pokemon("Porygon", 137, 45, null, null, 65, 60, 70, 40, PokemonType.Normal, PokemonType.None) }, // no evo (Porygon2 Gen2+)
            
            { 138, new Pokemon("Omanyte", 138, 45, null, 139, 35, 40, 100, 35, PokemonType.Rock, PokemonType.Water) }, // -> Omastar (level 40)
            { 139, new Pokemon("Omastar", 139, 45, null, null, 70, 60, 125, 55, PokemonType.Rock, PokemonType.Water) }, // no evo
            
            { 140, new Pokemon("Kabuto", 140, 45, null, 141, 30, 80, 90, 55, PokemonType.Rock, PokemonType.Water) }, // -> Kabutops (level 40)
            { 141, new Pokemon("Kabutops", 141, 45, null, null, 60, 115, 105, 80, PokemonType.Rock, PokemonType.Water) }, // no evo
            
            { 142, new Pokemon("Aerodactyl", 142, 45, null, null, 80, 105, 65, 130, PokemonType.Rock, PokemonType.Flying) }, // no evo
            
            { 143, new Pokemon("Snorlax", 143, 25, null, null, 160, 110, 65, 30, PokemonType.Normal, PokemonType.None) }, // no evo
            
            { 144, new Pokemon("Articuno", 144, 3, null, null, 90, 85, 100, 85, PokemonType.Ice, PokemonType.Flying) }, // legendary, no evo
            { 145, new Pokemon("Zapdos", 145, 3, null, null, 90, 90, 85, 100, PokemonType.Electric, PokemonType.Flying) }, // legendary, no evo
            { 146, new Pokemon("Moltres", 146, 3, null, null, 90, 100, 90, 90, PokemonType.Fire, PokemonType.Flying) }, // legendary, no evo
            
            { 147, new Pokemon("Dratini", 147, 45, null, 148, 41, 64, 45, 50, PokemonType.Dragon, PokemonType.None) }, // -> Dragonair (level 30)
            { 148, new Pokemon("Dragonair", 148, 45, null, 149, 61, 84, 65, 70, PokemonType.Dragon, PokemonType.None) }, // -> Dragonite (level 55)
            { 149, new Pokemon("Dragonite", 149, 45, null, null, 91, 134, 95, 80, PokemonType.Dragon, PokemonType.Flying) }, // no evo
            
            { 150, new Pokemon("Mewtwo", 150, 3, null, null, 106, 110, 90, 130, PokemonType.Psychic, PokemonType.None) }, // legendary, no evo
            { 151, new Pokemon("Mew", 151, 45, null, null, 100, 100, 100, 100, PokemonType.Psychic, PokemonType.None) }, // mythical, no evo
        };
    }
}