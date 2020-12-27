using FootballWorld;
using GlobalFootball.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public static Color ThemeColor = Color.Black;
        public SettingsPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            SetBorders();
            SelColor.Text = Language.keySelColor;
            SelLanguage.Text = Language.keySelLanguage;
            BacktoDef.Text = Language.keyBackDef;
            labelRestart.Text = Language.keyWarningLabel;
            CheckSound();
        }

        async void DefSettings(object sender, EventArgs e)
        {
            var answer = await DisplayAlert(Language.keyWarning, Language.keyQuestion, Language.keyYes, Language.keyNo);
            if (answer == true)
            {
                DataManager.Leagues.Clear();
                DataManager.SetData();
                DataManager.settings.BackColor = XmlHelper.GetHexString(Color.Black);
                DataManager.settings.Language = LanguageEnum.English;
                NeedToRestart();
            }
        }

        public void SetBlack(object sender, EventArgs e)
        {
            DataManager.settings.BackColor = XmlHelper.GetHexString(Color.Black);
            SetBorders();
            NeedToRestart();
        }
        public void SetDarkBlue(object sender, EventArgs e)
        {
            DataManager.settings.BackColor = XmlHelper.GetHexString(Color.DarkBlue);
            SetBorders();
            NeedToRestart();
        }
        public void SetDarkGreen(object sender, EventArgs e)
        {
            DataManager.settings.BackColor = XmlHelper.GetHexString(Color.DarkGreen);
            SetBorders();
            NeedToRestart();
        }

        public void SetRussian(object sender, EventArgs e)
        {
            DataManager.settings.Language=LanguageEnum.Russian;
            SetBorders();
            NeedToRestart();
        }
        public void SetEnglish(object sender, EventArgs e)
        {
            DataManager.settings.Language = LanguageEnum.English;
            SetBorders();
            NeedToRestart();
        }
        public void Sound(object sender, EventArgs e)
        {
            CheckSound();
        }

        private void CheckSound()
        {
            if (DataManager.settings.MusicOn == true)
            {
                if (LeaguePage.player != null)
                {
                    LeaguePage.player.Stop();
                }
                DataManager.settings.MusicOn = false;
                Soundoff.Text = Language.keySoundOn;
            }
            else
            {
                DataManager.settings.MusicOn = true;
                Soundoff.Text = Language.keySoundOff;
            }
        }
        private void NeedToRestart()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            DisplayAlert(Language.keyWarning, Language.keyWarningText, "OK");
            labelRestart.IsVisible = true;
        }

        private void SetBorders()
        {
            if (DataManager.settings.Language == LanguageEnum.English)
            {
                enBtn.BackgroundColor = Color.DarkGray;
                rusBtn.BackgroundColor = Color.Default;
                enBtn.IsEnabled = false;
                rusBtn.IsEnabled = true;
            }
            else
            {
                rusBtn.BackgroundColor = Color.DarkGray;
                enBtn.BackgroundColor = Color.Default;
                rusBtn.IsEnabled = false;
                enBtn.IsEnabled = true;
            }

            if (DataManager.settings.BackColor == "#000000")
            {
                Blackbtn.BorderWidth = 5;
                Greenbtn.BorderWidth = 0;
                Bluebtn.BorderWidth = 0;
                Blackbtn.IsEnabled = false;
                Greenbtn.IsEnabled = true;
                Bluebtn.IsEnabled = true;
            }
            else if (DataManager.settings.BackColor == "#006400")
            {
                Blackbtn.BorderWidth = 0;
                Greenbtn.BorderWidth = 5;
                Bluebtn.BorderWidth = 0;
                Blackbtn.IsEnabled = true;
                Greenbtn.IsEnabled = false;
                Bluebtn.IsEnabled = true;
            }
            else
            {
                Blackbtn.BorderWidth = 0;
                Greenbtn.BorderWidth = 0;
                Bluebtn.BorderWidth = 5;
                Bluebtn.IsEnabled = false;
                Blackbtn.IsEnabled = true;
                Greenbtn.IsEnabled = true;
                Bluebtn.IsEnabled = false;
            }
        }
    }
}