namespace PokemonEndlessConsoleFighter
{
    internal static class Pokedex
    {
        private static readonly Random random = new Random();

        private static readonly Dictionary<int, Pokemon> PokemonList = new Dictionary<int, Pokemon>
        {
        //Key(index)|           |  Name    |  Index |   HP  |      Attack        |  DMG  |CatchRate| Evolution |    Type1              |   Type2
            { 1,    new Pokemon("Bulbasaur",    1,      45,     "Vine Whip",        35,     45,         16,     PokemonType.Grass,      PokemonType.Poison) },
            { 2,    new Pokemon("Ivysaur",      2,      60,     "Razor Leaf",       55,     45,         32,     PokemonType.Grass,      PokemonType.Poison) },
            { 3,    new Pokemon("Venusaur",     3,      80,     "Solar Beam",       120,    45,        null,    PokemonType.Grass,      PokemonType.Poison) },

            { 4,    new Pokemon("Charmander",   4,      39,     "Flamethrower",     90,     45,         16,     PokemonType.Fire)       },
            { 5,    new Pokemon("Charmeleon",   5,      58,     "Fire Fang",        65,     45,         32,     PokemonType.Fire)       },
            { 6,    new Pokemon("Charizard",    6,      78,     "Fire Blast",       110,    45,        null,    PokemonType.Fire,       PokemonType.Flying) },

            { 7,    new Pokemon("Squirtle",     7,      44,     "Water Gun",        40,     45,         16,     PokemonType.Water)      },
            { 8,    new Pokemon("Wartortle",    8,      59,     "Bubble Beam",      65,     45,         32,     PokemonType.Water)      },
            { 9,    new Pokemon("Blastoise",    9,      79,     "Hydro Pump",       110,    45,        null,    PokemonType.Water)      },

            { 10,   new Pokemon("Caterpie",     10,     45,     "Tackle",           40,     255,         7,     PokemonType.Bug)        },
            { 11,   new Pokemon("Metapod",      11,     50,     "Harden",           0,      120,        10,     PokemonType.Bug)        },
            { 12,   new Pokemon("Butterfree",   12,     60,     "Gust",             40,     45,        null,    PokemonType.Bug,        PokemonType.Flying) },

            { 13,   new Pokemon("Weedle",       13,     40,     "Poison Sting",     15,     255,         7,     PokemonType.Bug,        PokemonType.Poison) },
            { 14,   new Pokemon("Kakuna",       14,     45,     "Harden",           0,      120,        10,     PokemonType.Bug,        PokemonType.Poison) },
            { 15,   new Pokemon("Beedrill",     15,     65,     "Twineedle",        25,     45,        null,    PokemonType.Bug,        PokemonType.Poison) },

            { 16,   new Pokemon("Pidgey",       16,     40,     "Gust",             40,     255,        18,     PokemonType.Normal,     PokemonType.Flying) },
            { 17,   new Pokemon("Pidgeotto",    17,     63,     "Wing Attack",      60,     120,        36,     PokemonType.Normal,     PokemonType.Flying) },
            { 18,   new Pokemon("Pidgeot",      18,     83,     "Air Slash",        75,     45,        null,    PokemonType.Normal,     PokemonType.Flying) },

            { 19,   new Pokemon("Rattata",      19,     30,     "Tackle",           40,     255,        20,     PokemonType.Normal)     },
            { 20,   new Pokemon("Raticate",     20,     55,     "Hyper Fang",       80,     127,       null,    PokemonType.Normal)     },

            { 21,   new Pokemon("Spearow",      21,     40,     "Peck",             35,     255,        20,     PokemonType.Normal,     PokemonType.Flying) },
            { 22,   new Pokemon("Fearow",       22,     65,     "Drill Peck",       80,     90,        null,    PokemonType.Normal,     PokemonType.Flying) },

            { 23,   new Pokemon("Ekans",        23,     35,     "Bite",             60,     255,        22,     PokemonType.Poison)     },
            { 24,   new Pokemon("Arbok",        24,     60,     "Poison Fang",      50,     90,        null,    PokemonType.Poison)     },

            { 25,   new Pokemon("Pikachu",      25,     35,     "Thunder Shock",    40,     190,       null,    PokemonType.Electric)   },                      //item evo
            { 26,   new Pokemon("Raichu",       26,     60,     "Thunder Punch",    75,     75,        null,    PokemonType.Electric)   },

            { 27,   new Pokemon("Sandshrew",    27,     50,     "Scratch",          40,     255,        22,     PokemonType.Ground)     },
            { 28,   new Pokemon("Sandslash",    28,     75,     "Slash",            70,     90,        null,    PokemonType.Ground)     },

            { 29,   new Pokemon("Nidoran F",     29,     55,     "Bite",            60,     235,        16,     PokemonType.Poison)     },
            { 30,   new Pokemon("Nidorina",     30,     70,     "Poison Jab",       80,     120,       null,    PokemonType.Poison)     },                      //Item evo
            { 31,   new Pokemon("Nidoqueen",    31,     90,     "Earth Power",      90,     45,        null,    PokemonType.Poison,     PokemonType.Ground) },

            { 32,   new Pokemon("Nidoran M",     32,     46,     "Peck",            35,     235,        16,     PokemonType.Poison)     },
            { 33,   new Pokemon("Nidorino",     33,     61,     "Poison Jab",       80,     120,       null,    PokemonType.Poison)     },                      //Item evo
            { 34,   new Pokemon("Nidoking",     34,     81,     "Earth Power",      90,     45,        null,    PokemonType.Poison,     PokemonType.Ground) },

            { 35,   new Pokemon("Clefairy",     35,     70,     "Pound",            40,     150,       null,    PokemonType.Fairy)      },                      //Item evo
            { 36,   new Pokemon("Clefable",     36,     95,     "Moonblast",        95,     45,        null,    PokemonType.Fairy)      },

            { 37,   new Pokemon("Vulpix",       37,     38,     "Ember",            40,     190,       null,    PokemonType.Fire)       },                      //Item evo
            { 38,   new Pokemon("Ninetales",    38,     73,     "Flamethrower",     90,     75,        null,    PokemonType.Fire)       },

            { 39,   new Pokemon("Jigglypuff",   39,     115,    "Double Slap",      15,     170,       null,    PokemonType.Normal,     PokemonType.Fairy) },   //Item evo
            { 40,   new Pokemon("Wigglytuff",   40,     140,    "Body Slam",        85,     45,        null,    PokemonType.Normal,     PokemonType.Fairy) },

            { 41,   new Pokemon("Zubat",        41,     40,     "Bite",             60,     255,        22,     PokemonType.Poison,     PokemonType.Flying) },
            { 42,   new Pokemon("Golbat",       42,     75,     "Air Cutter",       60,     90,        null,    PokemonType.Poison,     PokemonType.Flying) },

            { 43,   new Pokemon("Oddish",       43,     45,     "Absorb",           20,     255,        21,     PokemonType.Grass,      PokemonType.Poison) },
            { 44,   new Pokemon("Gloom",        44,     60,     "Acid",             40,     120,       null,    PokemonType.Grass,      PokemonType.Poison) },  //Item evo
            { 45,   new Pokemon("Vileplume",    45,     75,     "Petal Dance",      120,    45,        null,    PokemonType.Grass,      PokemonType.Poison) },

            { 46,   new Pokemon("Paras",        46,     35,     "Scratch",          40,     190,        24,     PokemonType.Bug,        PokemonType.Grass) },
            { 47,   new Pokemon("Parasect",     47,     60,     "X-Scissor",        80,     75,        null,    PokemonType.Bug,        PokemonType.Grass) },

            { 48,   new Pokemon("Venonat",      48,     60,     "Confusion",        50,     190,        31,     PokemonType.Bug,        PokemonType.Poison) },
            { 49,   new Pokemon("Venomoth",     49,     70,     "Psybeam",          65,     75,        null,    PokemonType.Bug,        PokemonType.Poison) },

            { 50,   new Pokemon("Diglett",      50,     10,     "Scratch",          40,     255,        26,     PokemonType.Ground)     },
            { 51,   new Pokemon("Dugtrio",      51,     35,     "Earthquake",       100,    90,        null,    PokemonType.Ground)     },

            { 52,   new Pokemon("Meowth",       52,     40,     "Scratch",          40,     255,        28,     PokemonType.Normal)     },
            { 53,   new Pokemon("Persian",      53,     65,     "Bite",             60,     90,        null,    PokemonType.Normal)     },

            { 54,   new Pokemon("Psyduck",      54,     50,     "Water Gun",        40,     190,        33,     PokemonType.Water)      },
            { 55,   new Pokemon("Golduck",      55,     80,     "Confusion",        50,     75,        null,    PokemonType.Water)      },

            { 56,   new Pokemon("Mankey",       56,     40,     "Low Kick",         60,     190,        28,     PokemonType.Fighting)   },
            { 57,   new Pokemon("Primeape",     57,     65,     "Cross Chop",       100,    75,        null,    PokemonType.Fighting)   },

            { 58,   new Pokemon("Growlithe",    58,     55,     "Bite",             60,     190,       null,    PokemonType.Fire)       },                      //item evo
            { 59,   new Pokemon("Arcanine",     59,     90,     "Flamethrower",     90,     75,        null,    PokemonType.Fire)       },

            { 60,   new Pokemon("Poliwag",      60,     40,     "Bubble",           40,     255,        25,     PokemonType.Water)      },
            { 61,   new Pokemon("Poliwhirl",    61,     65,     "Water Pulse",      60,     120,       null,    PokemonType.Water)      },                      //item evo
            { 62,   new Pokemon("Poliwrath",    62,     90,     "Hydro Pump",       110,    45,        null,    PokemonType.Water,      PokemonType.Fighting) },

            { 63,   new Pokemon("Abra",         63,     25,     "Psybeam",          65,     200,        16,     PokemonType.Psychic)    },
            { 64,   new Pokemon("Kadabra",      64,     40,     "Psychic",          90,     120,       null,    PokemonType.Psychic)    },                      //Trade evo
            { 65,   new Pokemon("Alakazam",     65,     55,     "Psychic",          90,     45,        null,    PokemonType.Psychic)    },

            { 66,   new Pokemon("Machop",       66,     70,     "Low Kick",         60,     180,        28,     PokemonType.Fighting)   },
            { 67,   new Pokemon("Machoke",      67,     80,     "Cross Chop",       100,    90,        null,    PokemonType.Fighting)   },                      //Trade evo
            { 68,   new Pokemon("Machamp",      68,     90,     "Dynamic Punch",    100,    45,        null,    PokemonType.Fighting)   },

            { 69,   new Pokemon("Bellsprout",   69,     50,     "Vine Whip",        35,     255,        21,     PokemonType.Grass,      PokemonType.Poison) },
            { 70,   new Pokemon("Weepinbell",   70,     65,     "Razor Leaf",       55,     120,       null,    PokemonType.Grass,      PokemonType.Poison) },  //Item evo
            { 71,   new Pokemon("Victreebel",   71,     80,     "Solar Beam",       120,    45,        null,    PokemonType.Grass,      PokemonType.Poison) },

            { 72,   new Pokemon("Tentacool",    72,     40,     "Acid",             40,     190,        30,     PokemonType.Water,      PokemonType.Poison) },
            { 73,   new Pokemon("Tentacruel",   73,     80,     "Sludge Bomb",      90,     75,        null,    PokemonType.Water,      PokemonType.Poison) },

            { 74,   new Pokemon("Geodude",      74,     40,     "Tackle",           40,     255,        25,     PokemonType.Rock,       PokemonType.Ground) },
            { 75,   new Pokemon("Graveler",     75,     55,     "Rock Throw",       50,     120,       null,    PokemonType.Rock,       PokemonType.Ground) },  //Trade evo
            { 76,   new Pokemon("Golem",        76,     80,     "Earthquake",       100,    45,        null,    PokemonType.Rock,       PokemonType.Ground) },

            { 77,   new Pokemon("Ponyta",       77,     50,     "Ember",            40,     190,        40,     PokemonType.Fire)       },
            { 78,   new Pokemon("Rapidash",     78,     65,     "Flamethrower",     90,     75,        null,    PokemonType.Fire)       },

            { 79,   new Pokemon("Slowpoke",     79,     90,     "Water Gun",        40,     190,        37,     PokemonType.Water,      PokemonType.Psychic) },
            { 80,   new Pokemon("Slowbro",      80,     95,     "Psychic",          90,     75,        null,    PokemonType.Water,      PokemonType.Psychic) },

            { 81,   new Pokemon("Magnemite",    81,     25,     "Thunder Shock",    40,     190,        30,     PokemonType.Electric,   PokemonType.Steel) },
            { 82,   new Pokemon("Magneton",     82,     50,     "Spark",            65,     75,        null,    PokemonType.Electric,   PokemonType.Steel) },

            { 83,   new Pokemon("Farfetch'd",   83,     52,     "Peck",             35,     190,       null,    PokemonType.Normal,     PokemonType.Flying) },

            { 84,   new Pokemon("Doduo",        84,     35,     "Peck",             35,     190,        31,     PokemonType.Normal,     PokemonType.Flying) },
            { 85,   new Pokemon("Dodrio",       85,     60,     "Drill Peck",       80,     75,        null,    PokemonType.Normal,     PokemonType.Flying) },

            { 86,   new Pokemon("Seel",         86,     65,     "Ice Beam",         90,     190,        34,     PokemonType.Water)      },
            { 87,   new Pokemon("Dewgong",      87,     90,     "Ice Beam",         90,     75,        null,    PokemonType.Water,      PokemonType.Ice) },

            { 88,   new Pokemon("Grimer",       88,     80,     "Sludge",           65,     190,        38,     PokemonType.Poison)     },
            { 89,   new Pokemon("Muk",          89,     105,    "Sludge Bomb",      90,     75,        null,    PokemonType.Poison)     },

            { 90,   new Pokemon("Shellder",     90,     30,     "Icicle Spear",     25,     190,       null,    PokemonType.Water)      },                      //item evo
            { 91,   new Pokemon("Cloyster",     91,     50,     "Ice Beam",         90,     75,        null,    PokemonType.Water,      PokemonType.Ice) },

            { 92,   new Pokemon("Gastly",       92,     30,     "Lick",             30,     190,        25,     PokemonType.Ghost,      PokemonType.Poison) },
            { 93,   new Pokemon("Haunter",      93,     45,     "Shadow Ball",      80,     120,       null,    PokemonType.Ghost,      PokemonType.Poison) },  //trade evo
            { 94,   new Pokemon("Gengar",       94,     60,     "Shadow Ball",      80,     45,        null,    PokemonType.Ghost,      PokemonType.Poison) },

            { 95,   new Pokemon("Onix",         95,     35,     "Rock Throw",       50,     90,        null,    PokemonType.Rock,       PokemonType.Ground) },

            { 96,   new Pokemon("Drowzee",      96,     60,     "Psybeam",          65,     190,        26,     PokemonType.Psychic)    },
            { 97,   new Pokemon("Hypno",        97,     85,     "Psychic",          90,     75,        null,    PokemonType.Psychic)    },

            { 98,   new Pokemon("Krabby",       98,     30,     "Bubble",           40,     225,        28,     PokemonType.Water)      },
            { 99,   new Pokemon("Kingler",      99,     55,     "Crabhammer",       100,    75,        null,    PokemonType.Water)      },

            { 100,  new Pokemon("Voltorb",      100,    40,     "Tackle",           40,     190,        30,     PokemonType.Electric)   },
            { 101,  new Pokemon("Electrode",    101,    60,     "Spark",            65,     75,        null,    PokemonType.Electric)   },

            { 102,  new Pokemon("Exeggcute",    102,    60,     "Confusion",        50,     190,       null,    PokemonType.Grass,      PokemonType.Psychic) }, //Item evo
            { 103,  new Pokemon("Exeggutor",    103,    95,     "Psychic",          90,     75,        null,    PokemonType.Grass,      PokemonType.Psychic) },

            { 104,  new Pokemon("Cubone",       104,    50,     "Bone Club",        65,     190,        28,     PokemonType.Ground)     },
            { 105,  new Pokemon("Marowak",      105,    60,     "Bonemerang",       50,     75,        null,    PokemonType.Ground)     },

            { 106,  new Pokemon("Hitmonlee",    106,    50,     "High Jump Kick",   130,    45,        null,    PokemonType.Fighting)   },                      
            { 107,  new Pokemon("Hitmonchan",   107,    50,     "Sky Uppercut",     85,     45,        null,    PokemonType.Fighting)   },

            { 108,  new Pokemon("Lickitung",    108,    90,     "Lick",             30,     90,        null,    PokemonType.Normal)     },

            { 109,  new Pokemon("Koffing",      109,    40,     "Tackle",           40,     190,        35,     PokemonType.Poison)     },
            { 110,  new Pokemon("Weezing",      110,    65,     "Sludge Bomb",      90,     75,        null,    PokemonType.Poison)     },

            { 111,  new Pokemon("Rhyhorn",      111,    80,     "Horn Attack",      65,     120,        42,     PokemonType.Ground,     PokemonType.Rock) },
            { 112,  new Pokemon("Rhydon",       112,    105,    "Earthquake",       100,    45,        null,    PokemonType.Ground,     PokemonType.Rock) },

            { 113,  new Pokemon("Chansey",      113,    250,    "Pound",            40,     30,        null,    PokemonType.Normal)     },

            { 114,  new Pokemon("Tangela",      114,    65,     "Vine Whip",        35,     190,       null,    PokemonType.Grass)      },

            { 115,  new Pokemon("Kangaskhan",   115,    105,    "Double Kick",      30,     90,        null,    PokemonType.Normal)     },

            { 116,  new Pokemon("Horsea",       116,    30,     "Bubble",           40,     225,        32,     PokemonType.Water)      },
            { 117,  new Pokemon("Seadra",       117,    55,     "Water Pulse",      60,     75,        null,    PokemonType.Water)      },

            { 118,  new Pokemon("Goldeen",      118,    45,     "Peck",             35,     225,        33,     PokemonType.Water)      },
            { 119,  new Pokemon("Seaking",      119,    80,     "Waterfall",        80,     75,        null,    PokemonType.Water)      },

            { 120,  new Pokemon("Staryu",       120,    30,     "Water Gun",        40,     225,       null,    PokemonType.Water)      },
            { 121,  new Pokemon("Starmie",      121,    60,     "Hydro Pump",       110,    75,        null,    PokemonType.Water,      PokemonType.Psychic) },

            { 122,  new Pokemon("Mr. Mime",     122,    40,     "Confusion",        50,     190,       null,    PokemonType.Psychic,    PokemonType.Fairy) },

            { 123,  new Pokemon("Scyther",      123,    70,     "Fury Cutter",      40,     75,        null,    PokemonType.Bug,        PokemonType.Flying) },

            { 124,  new Pokemon("Jynx",         124,    65,     "Psyshock",         80,     75,        null,    PokemonType.Ice,        PokemonType.Psychic) },

            { 125,  new Pokemon("Electabuzz",   125,    65,     "Thunder Punch",    75,     75,        null,    PokemonType.Electric)   },

            { 126,  new Pokemon("Magmar",       126,    65,     "Flamethrower",     90,     75,        null,    PokemonType.Fire)       },

            { 127,  new Pokemon("Pinsir",       127,    65,     "X-Scissor",        80,     75,        null,    PokemonType.Bug)        },

            { 128,  new Pokemon("Tauros",       128,    75,     "Tackle",           40,     75,        null,    PokemonType.Normal)     },

            { 129,  new Pokemon("Magikarp",     129,    20,     "Splash",           0,      255,        20,     PokemonType.Water)      },
            { 130,  new Pokemon("Gyarados",     130,    95,     "Hydro Pump",       110,    45,        null,    PokemonType.Water,      PokemonType.Flying) },

            { 131,  new Pokemon("Lapras",       131,    130,    "Ice Beam",         95,     45,        null,    PokemonType.Water,      PokemonType.Ice) },

            { 132,  new Pokemon("Ditto",        132,    48,     "Transform",        0,      75,        null,    PokemonType.Normal)     },

            { 133,  new Pokemon("Eevee",        133,    55,     "Quick Attack",     40,     190,       null,    PokemonType.Normal)     },                      //Item evo
            { 134,  new Pokemon("Vaporeon",     134,    130,    "Water Gun",        40,     45,        null,    PokemonType.Water)      },
            { 135,  new Pokemon("Jolteon",      135,    65,     "Thunder Shock",    40,     45,        null,    PokemonType.Electric)   },
            { 136,  new Pokemon("Flareon",      136,    65,     "Ember",            40,     45,        null,    PokemonType.Fire)       },

            { 137,  new Pokemon("Porygon",      137,    65,     "Psybeam",          65,     75,        null,    PokemonType.Normal)     },

            { 138,  new Pokemon("Omanyte",      138,    35,     "Water Gun",        40,     45,         40,     PokemonType.Rock,       PokemonType.Water) },
            { 139,  new Pokemon("Omastar",      139,    70,     "Hydro Pump",       110,    45,        null,    PokemonType.Rock,       PokemonType.Water) },

            { 140,  new Pokemon("Kabuto",       140,    30,     "Scratch",          40,     45,         40,     PokemonType.Rock,       PokemonType.Water) },
            { 141,  new Pokemon("Kabutops",     141,    60,     "Slash",            70,     45,        null,    PokemonType.Rock,       PokemonType.Water) },

            { 142,  new Pokemon("Aerodactyl",   142,    80,     "Rock Slide",       75,     45,        null,    PokemonType.Rock,       PokemonType.Flying) },

            { 143,  new Pokemon("Snorlax",      143,    160,    "Body Slam",        85,     25,        null,    PokemonType.Normal)      },
             
            { 144,  new Pokemon("Articuno",     144,    90,     "Ice Beam",         90,     3,         null,    PokemonType.Ice,        PokemonType.Flying) },

            { 145,  new Pokemon("Zapdos",       145,    90,     "Thunder Shock",    40,     3,         null,    PokemonType.Electric,   PokemonType.Flying) },

            { 146,  new Pokemon("Moltres",      146,    90,     "Flamethrower",     90,     3,         null,    PokemonType.Fire,       PokemonType.Flying) },

            { 147,  new Pokemon("Dratini",      147,    41,     "Wrap",             15,     45,         30,     PokemonType.Dragon)     },
            { 148,  new Pokemon("Dragonair",    148,    61,     "Dragon Rage",      40,     45,         55,     PokemonType.Dragon)     },
            { 149,  new Pokemon("Dragonite",    149,    91,     "Dragon Claw",      80,     45,        null,    PokemonType.Dragon,     PokemonType.Flying) },
             
            { 150,  new Pokemon("Mewtwo",       150,    106,    "Psychic",          90,     3,         null,    PokemonType.Psychic)    },
            { 151,  new Pokemon("Mew",          151,    100,    "Pound",            40,     45,        null,    PokemonType.Psychic)    }
        };

        public static Pokemon GetRandomPokemon()
        {
            int pokeNumber = random.Next(1, PokemonList.Count); // 1-151 inclusive
            return PokemonList[pokeNumber];
        }

        public static Pokemon GetPokemon(int index)
        {
            return PokemonList[index];
        }
    }
}
