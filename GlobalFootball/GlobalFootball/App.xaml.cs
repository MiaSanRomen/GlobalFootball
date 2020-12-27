using FootballWorld;
using GlobalFootball.Data;
using System;
using System.Globalization;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    public partial class App : Application
    {
        public App()
        {


            InitializeComponent();
            DataManager.SetQuestions();
            var settings = XmlHelper.Load();
            if (settings != null)
            {
                DataManager.settings = settings;
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));

            var leagues = BinHelper.Load();
            if (leagues == null || leagues.Count == 0)
            {
                DataManager.SetData();
            }
            else
            {
                DataManager.Leagues = leagues;
                foreach (var league in DataManager.Leagues)
                {
                    switch (league.Name)
                    {
                        case "Bundesliga":
                            league.Country = Language.keyGermany;
                            break;
                        case "La Liga":
                            league.Country = Language.keySpain;
                            break;
                        case "Ligue 1":
                            league.Country = Language.keyFrance;
                            break;
                        case "Premier League":
                            league.Country = Language.keyEngland;
                            break;
                        case "Serie A":
                            league.Country = Language.keyItaly;
                            break;
                    }
                }
            }
            MainPage = new NavigationPage(new StartPage())
            {
                BarBackgroundColor = Color.FromHex(DataManager.settings.BackColor),
                BarTextColor = Color.White
            };

        }




        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            BinHelper.Save(DataManager.Leagues);
            XmlHelper.Save(DataManager.settings);
            if (LeaguePage.player != null)
            {
                LeaguePage.player.Pause();
            }
        }

        protected override void OnResume()
        {
            if (LeaguePage.player != null)
            {
                LeaguePage.player.Play();
            }
        }

    }
}
