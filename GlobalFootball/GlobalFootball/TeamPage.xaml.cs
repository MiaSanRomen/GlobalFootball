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
    public partial class TeamPage : ContentPage
    {
        public Team MyTeam = new Team();
        public static Player SelectedPlayer = new Player();
        public TeamPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            label.BackgroundColor = Color.FromHex(DataManager.settings.BackColor);
            label.Text = Language.keyPlayers;
            AddPlayer.Text = Language.keyAdd;
        }

        protected override void OnAppearing()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            base.OnAppearing();
            MyTeam = LeaguePage.SelectedTeam;
            TeamImage.Source = MyTeam.Image;
            TeamName.Text = MyTeam.Name;
            teamTropheys.Text = Language.keyCups + " " + MyTeam.Tropheys.ToString();
            teamPlace.Text = Language.keyRating + " " + MyTeam.EuroPlace.ToString();

            PLayerlistView.ItemsSource = MyTeam.Players.OrderBy(u => u.Name);
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                SelectedPlayer = e.SelectedItem as Player;
            }
        }
        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PlayerPage());
        }

        async void ToolbarItemCommand(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPlayerPage());
        }
    }
}