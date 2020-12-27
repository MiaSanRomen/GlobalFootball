using GlobalFootball.Data;
using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class LeagueChosePage : ContentPage
    {
        public static League SelectedLeague = new League();

        public LeagueChosePage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            LeaguelistView.ItemsSource = DataManager.Leagues.OrderBy(u => u.Name);
            if (LeaguePage.player != null)
            {
                LeaguePage.player.Stop();
            }
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                SelectedLeague = e.SelectedItem as League;
            }
        }
        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new LeaguePage());
        }

        async void Football_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage());
        }
    }
}