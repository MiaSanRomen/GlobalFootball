using GlobalFootball.Data;
using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public ObservableCollection<Player> Players = new ObservableCollection<Player>();
        public SearchPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            labelPlayers.BackgroundColor = Color.FromHex(DataManager.settings.BackColor);
            PutIn.Text = Language.keyPutIn;
            labelPlayers.Text = Language.keyPlayers;
        }

        void EditorTextChanged(object sender, TextChangedEventArgs e)
        {
            Players.Clear();

            var editorText = e.NewTextValue;

            if (editorText.Length > 0)
            {
                var players = DataManager.Leagues.SelectMany(x => x.Teams).SelectMany(x => x.Players).Where(x => x.Name.ToLower().StartsWith(editorText.ToLower()) || x.Surname.ToLower().StartsWith(editorText.ToLower()));
                foreach (var player in players)
                {
                    Players.Add(player);
                }

            }
            PlayersList.ItemsSource = Players.OrderBy(u => u.Name);
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                TeamPage.SelectedPlayer = e.SelectedItem as Player;
            }
        }
        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PlayerPage());
        }
    }
}