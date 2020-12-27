using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace GlobalFootball.Data
{
    class DataManager
    {
        public static List<League> Leagues = new List<League>();
        public static Settings settings = new Settings();
        public static Dictionary<int, Question> Questions = new Dictionary<int, Question>();
        public static int a = 0;
        public static void SetData()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            var fiL = new League
            {
                Name = "Bundesliga",
                Country = Language.keyGermany,
                Date = 1963,
                EuroPlace = 3,
                Image = "bundesligaico",
                Teams = new List<Team>
                {
                    {
                        new Team
                        {
                            Date = 1900,
                            Name = "FC Bayern Munich",
                            EuroPlace = 3,
                            Tropheys = 29,
                            Image = "bayern",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Thomas", Surname="Muller", Goals=201, Position="Forward", Years=30, Image="muller", Price = new int[]{75, 75, 60, 60, 40} } },
                                {new Player { Name = "Robert", Surname="Lewandowski", Goals=379, Position="Forward", Years=31, Image="lewa", Price = new int[]{70, 75, 80, 90, 65} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1909,
                            Name = "Borussia Dortmund",
                            EuroPlace = 13,
                            Tropheys = 8,
                            Image = "borussia",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Marco", Surname="Reus", Goals=166, Position="Forward", Years=30, Image="reus", Price = new int[]{50, 45, 40, 50, 50} } },
                                {new Player { Name = "Mats", Surname="Hummels", Goals=38, Position="Defender", Years=30, Image="hummels", Price = new int[]{35, 38, 40, 60, 35} } }
                            }
                        }
                    },
                }
            };
            Leagues.Add(fiL);
            fiL = new League
            {
                Name = "La Liga",
                Country = Language.keySpain,
                Date = 1929,
                EuroPlace = 1,
                Image = "laligaico",
                Teams = new List<Team>
                {
                    {
                        new Team
                        {
                            Date = 1899,
                            Name = "FC Barcelona",
                            EuroPlace = 2,
                            Tropheys = 26,
                            Image = "barca",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Lionel", Surname="Messi", Goals=614, Position="Forward", Years=32, Image="messi", Price = new int[]{ 120, 120, 120, 180, 150} } },
                                {new Player { Name = "Antoine", Surname="Griezmann", Goals=187, Position="Forward", Years=28, Image="griezmann", Price = new int[]{50, 80, 80, 150, 130} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1902,
                            Name = "Real Madrid CF",
                            EuroPlace = 1,
                            Tropheys = 33,
                            Image = "real",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Eden", Surname="Hazard", Goals=160, Position="Forward", Years=28, Image="hazard", Price = new int[]{70, 70, 75, 150, 150} } },
                                {new Player { Name = "Luka", Surname="Modric", Goals=78, Position="Midfielder", Years=34, Image="modric", Price = new int[]{55, 50, 45, 40, 20} } }
                            }
                        }
                    },
                }
            };
            Leagues.Add(fiL);
            fiL = new League
            {
                Name = "Premier League",
                Country = Language.keyEngland,
                Date = 1992,
                EuroPlace = 2,
                Image = "epl",
                Teams = new List<Team>
                {
                    {
                        new Team
                        {
                            Date = 1892,
                            Name = "Liverpool",
                            EuroPlace = 8,
                            Tropheys = 18,
                            Image = "liverpool",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Virgil", Surname="van Dijk", Goals=37, Position="Defender", Years=28, Image="vandijk", Price = new int[]{ 10, 16, 30, 75, 100} } },
                                {new Player { Name = "Mohamed", Surname="Salah", Goals=152, Position="Forward", Years=27, Image="salah", Price = new int[]{20, 27, 40, 150, 150} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1880,
                            Name = "Manchester City",
                            EuroPlace = 6,
                            Tropheys = 6,
                            Image = "city",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Bernardo", Surname="Silva", Goals=61, Position="Forward", Years=25, Image="silva", Price = new int[]{ 15, 20, 40, 65, 100} } },
                                {new Player { Name = "Kevin", Surname="De Bruyne", Goals=86, Position="Midfielder", Years=28, Image="kevin", Price = new int[]{45, 60, 75, 150, 130} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1905,
                            Name = "Chelsea",
                            EuroPlace = 14,
                            Tropheys = 6,
                            Image = "chelsea",
                            Players = new List<Player>
                            {
                                {new Player { Name = "N'Golo", Surname="Kante", Goals=20, Position="Midfielder", Years=28, Image="kante", Price = new int[]{ 7, 30, 50, 100, 100} } },
                                {new Player { Name = "Christian", Surname="Pulisic", Goals=19, Position="Forward", Years=21, Image="pulisic", Price = new int[]{0, 5, 45, 50, 60} } }
                            }
                        }
                    },
                }
            };
            Leagues.Add(fiL);
            fiL = new League
            {
                Name = "Serie A",
                Country = Language.keyItaly,
                Date = 1898,
                EuroPlace = 4,
                Image = "serieaico",
                Teams = new List<Team>
                {
                    {
                        new Team
                        {
                            Date = 1897,
                            Name = "Juventus",
                            EuroPlace = 5,
                            Tropheys = 35,
                            Image = "juventus",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Gianluigi", Surname="Buffon", Goals=0, Position="Goalkeeper", Years=41, Image="buffon", Price = new int[]{ 2, 2, 2, 2, 1} } },
                                {new Player { Name = "Cristiano", Surname="Ronaldo", Goals=603, Position="Forward", Years=34, Image="ronaldo", Price = new int[]{120, 110, 100, 120, 90} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1908,
                            Name = "Inter Milan",
                            EuroPlace = 56,
                            Tropheys = 18,
                            Image = "inter",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Diego", Surname="Godin", Goals=39, Position="Defender", Years=33, Image="godin", Price = new int[]{ 55, 55, 65, 70, 35 } } },
                                {new Player { Name = "Alexis", Surname="Sanchez", Goals=178, Position="Forward", Years=30, Image="alexis", Price = new int[]{30, 40, 40, 35, 20} } }
                            }
                        }
                    },
                }
            };
            Leagues.Add(fiL);
            fiL = new League
            {
                Name = "Ligue 1",
                Country = Language.keyFrance,
                Date = 1930,
                EuroPlace = 5,
                Image = "ligue1ico",
                Teams = new List<Team>
                {
                    {
                        new Team
                        {
                            Date = 1970,
                            Name = "Paris Saint-Germain",
                            EuroPlace = 7,
                            Tropheys = 8,
                            Image = "paris",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Kylian", Surname="Mbappe", Goals=93, Position="Forward", Years=20, Image="mbappe", Price = new int[]{ 2, 4, 90, 200, 200} } },
                                {new Player { Name = "Neymar", Surname="Jr", Goals=294, Position="Forward", Years=27, Image="neymar", Price = new int[]{100, 100, 150, 180, 180} } }
                            }
                        }
                    },
                    {
                        new Team
                        {
                            Date = 1924,
                            Name = "AS Monaco",
                            EuroPlace = 31,
                            Tropheys = 8,
                            Image = "monaco",
                            Players = new List<Player>
                            {
                                {new Player { Name = "Alexander", Surname="Golovin", Goals=19, Position="Midfielder", Years=23, Image="golovin", Price = new int[]{1, 3, 10, 30, 25} } },
                                {new Player { Name = "Cesc", Surname="Fabregas", Goals=122, Position="Midfielder", Years=32, Image="cesc", Price = new int[]{50, 45, 35, 35, 20} } }
                            }
                        }
                    },
                }
            };
            Leagues.Add(fiL);




        }

        public static void SetQuestions()
        {
            var que = new Question
            {
                MainQuestion = Language.keyquestion1,
                Answers = new string[] { Language.keyA1, Language.keyA2, Language.keyA3 },
                Right = 1,
            };
            Questions.Add(1, que);
            que = new Question
            {
                MainQuestion = Language.keyquestion2,
                Answers = new string[] { "4", "5", "7" },
                Right = 2,
            };
            Questions.Add(2, que);
            que = new Question
            {
                MainQuestion = Language.keyquestion3,
                Answers = new string[] { Language.keyB1, Language.keyB2, Language.keyB3 },
                Right = 3,
            };
            Questions.Add(3, que);
            que = new Question
            {
                MainQuestion = Language.keyquestion4,
                Answers = new string[] { Language.keyC1, Language.keyC2, Language.keyC3 },
                Right = 1,
            };
            Questions.Add(4, que);
            que = new Question
            {
                MainQuestion = Language.keyquestion5,
                Answers = new string[] { "5", "10", "19" },
                Right = 3,
            };
            Questions.Add(5, que);
        }
    }
}
