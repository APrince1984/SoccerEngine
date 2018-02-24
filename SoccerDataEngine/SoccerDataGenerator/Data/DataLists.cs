using System;
using System.Collections.Generic;
using SoccerDataGenerator.Utils;
namespace SoccerDataGenerator.Data
{
    public static class DataLists
    {
        public static readonly List<string> FirstName = new List<string>
        {
            "Aaron",
            "Andy",
            "Alfred",
            "Anthony",
            "Andre",
            "Alex",
            "Alexander",
            "Andreas",
            "Alix",
            "Albert",
            "Ali",
            "Bart",
            "Bert",
            "Bob",
            "Benny",
            "Ben",
            "Bram",
            "Bruno",
            "Billy",
            "Bill",
            "Brian",
            "Bryan",
            "Brecht",
            "Chris",
            "Christophe",
            "Christiaan",
            "Carl",
            "Cedric",
            "Clode",
            "Dirk",
            "Danny",
            "Dries",
            "Dimitry",
            "Dimitri",
            "Dylan",
            "Davy",
            "David",
            "Dave",
            "Eric",
            "Erik",
            "Ely",
            "Eling",
            "Emmanuel",
            "Ernest",
            "Ed",
            "Eddy",
            "Frederik",
            "Fernando",
            "Freddy",
            "Fred",
            "Firmin",
            "Fons",
            "Frans",
            "François",
            "Filip",
            "Guido",
            "Gregory",
            "Greg",
            "George",
            "Guy",
            "Gilles",
            "Han",
            "Hans",
            "Herman",
            "Iben",
            "Ivo",
            "Jan",
            "Jean",
            "Jordan",
            "Jean-Pierre",
            "Jelle",
            "John",
            "Johny",
            "Jules",
            "Kris",
            "Kristof",
            "Karel",
            "Karl",
            "Kim",
            "Kurt",
            "Kieron",
            "Luc",
            "Lucien",
            "Ludwig",
            "Liam",
            "Leon",
            "Lander",
            "Ludo",
            "Leo",
            "Leander",
            "Lucas",
            "Marc",
            "Mark",
            "Marnix",
            "Manuel",
            "Mike",
            "Michael",
            "Michaël",
            "Michel",
            "Mick",
            "Many",
            "Nico",
            "Nick",
            "Niek",
            "Nils",
            "Niels",
            "Nicolas",
            "Omer",
            "Orlando",
            "Peter",
            "Pieter",
            "Pieterjan",
            "Philippe",
            "Pedro",
            "Patje",
            "Patrick",
            "Quinten",
            "Ronny",
            "Romelu",
            "Romeo",
            "Roderick",
            "Randy",
            "Rudy",
            "Ruud",
            "Ringo",
            "Steve",
            "Steven",
            "Stephane",
            "Stefaan",
            "Sibren",
            "Sandy",
            "Sven",
            "Thomas",
            "Tom",
            "Tristan",
            "Tuur",
            "Tim",
            "Timothy",
            "Udo",
            "Vital",
            "Vince",
            "Vincent",
            "Wim",
            "Willy",
            "Walter",
            "Walt",
            "Xiebe",
            "Yentl",
            "Yenti",
            "Zarko"
        };

        public static readonly List<string> Lastname = new List<string>
        {
            "Andreas",
            "Anderson",
            "Boterberg",
            "Clovyn",
            "de Prince",
            "Deprince",
            "Deprins",
            "De Laere",
            "Casier",
            "Morel",
            "Massez",
            "Petitpierre",
            "De Laert",
            "Simmons",
            "Borkelmans",
            "Wilmots",
            "Devriese",
            "Deceunick",
            "Coninckx",
            "De Ridder",
            "Cronenberghs",
            "De Bel",
            "Vlaeminck",
            "Vleeminckx",
            "Van Lierde",
            "Vormer",
            "Cools",
            "Vander Elst",
            "Verheyen",
            "Deflandre",
            "Verlinden",
            "Cornelis",
            "De Bock",
            "Osaer",
            "Bedert",
            "Helas",
            "Feyen",
            "Lusyne",
            "De Soete",
            "De Sutter",
            "Vossen",
            "Bonavonture",
            "De Bakker",
            "Backaert",
            "Bakkers",
            "Beckers",
            "Jonckheere",
            "Vandenbrande",
            "Janssoone",
            "Smits",
            "Smidts",
            "De Smet",
            "Desmedt",
            "Desender",
            "Dikkenbos",
            "Delaere",
            "Vranckx",
            "Vanhorenweder",
            "Vanbavikhove",
            "Vanderlinde",
            "Smeets",
            "Van Overtveld",
            "Van Oostende",
            "Bruininckx",
            "Davidson",
            "Verkempinck",
            "Legein",
            "Vanheste",
            "Van Hoorn",
            "Bailleul",
            "De Vriendt",
            "Devriendt",
            "Medved",
            "Albert",
            "Filips",
            "Kerckhove",
            "Vandenkerkhove",
            "Cremer",
            "Clasie",
            "Dierckx",
            "Merckx",
            "Van Marcke",
            "Van Buyten",
            "Kompany",
            "Aderweireld",
            "Mignolet",
            "Vertonghen",
            "Engels",
            "Van Hoecke",
            "Mechele",
            "Ciman",
            "Carasco",
            "Hazard",
            "De Bruyne",
            "Defour",
            "Dufer",
            "Dembele",
            "Witsel",
            "Vanhaezebrouck",
            "Preudhomme",
            "Vanleerberghe",
            "Vanlerberghe",
            "Mertens",
            "Lukaku",
            "Penneteau",
            "Benteke",
            "Depoitre",
            "Cavanda",
            "Pocognoli"
        };

        public static readonly List<Country> Countries = new List<Country>
        {
            {new Country {Name = "Belgium", ShortName = "BEL", Rating = Rating.Good, IdCountry = 1} },
            {new Country {Name = "Netherland", ShortName = "NED", Rating = Rating.Mediocre, IdCountry = 2} },
            {new Country {Name = "France", ShortName = "FRA", Rating = Rating.Good, IdCountry = 3} },
            {new Country {Name = "Germany", ShortName = "GER", Rating = Rating.VeryGood, IdCountry = 4} },
            {new Country {Name = "Brasil", ShortName = "BRA", Rating = Rating.VeryGood, IdCountry = 5} }
        };

        public static string GetFirstName()
        {
            return FirstName[RandomUtil.GetRandomInt(0, FirstName.Count - 1)];
        }

        public static string GetLastName()
        {
            return Lastname[RandomUtil.GetRandomInt(0, Lastname.Count - 1)];
        }

        public static Country GetCountry()
        {
            return Countries[RandomUtil.GetRandomInt(0, Countries.Count - 1)];
        }

        public static readonly List<Competition> Competitions = new List<Competition>
        {
            {
                new Competition
                {
                    IdCompetition = 1,
                    IdCountry = 1,
                    Rating = Rating.VeryGood,
                    Name = "Jupiler League",
                    NumberOfWinterStopDays = 14,
                    StartDate = new DateTime(2018, 6, 25),
                    StartWinterStop = new DateTime(2018, 1, 3),
                    NumberOfPromoters = 0,
                    NumberOfDegradaters = 2,
                    MatchDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Friday,
                        DayOfWeek.Saturday,
                        DayOfWeek.Sunday
                    }
                }
            }, {
                new Competition
                {
                    IdCompetition = 2,
                    IdCountry = 1,
                    Rating = Rating.Good,
                    Name = "Proximus League",
                    NumberOfWinterStopDays = 21,
                    StartDate = new DateTime(2018, 7, 5),
                    StartWinterStop = new DateTime(2018, 12, 25),
                    NumberOfPromoters = 0,
                    NumberOfDegradaters = 2,
                    MatchDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Saturday,
                        DayOfWeek.Sunday
                    }
                }
            },
            {
                new Competition
                {
                    IdCompetition = 3,
                    IdCountry = 1,
                    Rating = Rating.Mediocre,
                    Name = "1ste Amateurs",
                    NumberOfWinterStopDays = 21,
                    StartDate = new DateTime(2018, 7, 20),
                    StartWinterStop = new DateTime(2018, 12, 25),
                    NumberOfPromoters = 0,
                    NumberOfDegradaters = 2,
                    MatchDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Saturday,
                        DayOfWeek.Sunday
                    }
                }
            }
        };

        public static readonly List<Team> Teams = new List<Team>
        {
            {
                new Team
                {
                    IdTeam = 1,
                    Name = "Club Brugge",
                    Rating = Rating.VeryGood,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 2,
                    Name = "Charleroi",
                    Rating = Rating.VeryGood,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 3,
                    Name = "Anderlecht",
                    Rating = Rating.VeryGood,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 4,
                    Name = "Racing Genk",
                    Rating = Rating.Good,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 5,
                    Name = "AA Gent",
                    Rating = Rating.Good,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 6,
                    Name = "Standard Liege",
                    Rating = Rating.Good,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 7,
                    Name = "KV Mechelen",
                    Rating = Rating.Mediocre,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 8,
                    Name = "Waasland Beveren",
                    Rating = Rating.Mediocre,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 9,
                    Name = "KV Kortrijk",
                    Rating = Rating.Mediocre,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 10,
                    Name = "KV Oostende",
                    Rating = Rating.Mediocre,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 11,
                    Name = "Zulte Waregem",
                    Rating = Rating.Mediocre,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 12,
                    Name = "K.A.S. Eupen",
                    Rating = Rating.Bad,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 13,
                    Name = "Royal Excelsior Moeskroen",
                    Rating = Rating.Bad,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 14,
                    Name = "STVV Sint-Truiden",
                    Rating = Rating.Bad,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 15,
                    Name = "Lokeren",
                    Rating = Rating.Bad,
                    IdCompetition = 1
                }
            },
            {
                new Team
                {
                    IdTeam = 16,
                    Name = "Royal Antwerp FC",
                    Rating = Rating.Bad,
                    IdCompetition = 1
                }
            }
        };
    }
}
