using GlobalFootball.Data;
using GlobalFootball.Structure;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class LeaguePage : ContentPage
    {
        public League MyLeague = new League();
        public static Team SelectedTeam = new Team();
        public static Plugin.SimpleAudioPlayer.ISimpleAudioPlayer player;
        public LeaguePage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            MyLeague = LeagueChosePage.SelectedLeague;
            leagueImage.Source = MyLeague.Image;
            leagueName.Text = MyLeague.Name;
            leagueCountry.Text = MyLeague.Country;
            leagueYear.Text = MyLeague.Date.ToString();
            label.BackgroundColor = Color.FromHex(DataManager.settings.BackColor);
            label.Text = Language.keyClubs;
            TeamlistView.ItemsSource = MyLeague.Teams.OrderBy(u => u.Name);
            player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(MyLeague.Name.ToLower() + ".mp3");
            if (DataManager.settings.MusicOn == true)
            {
                player.Play();
            }
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                SelectedTeam = e.SelectedItem as Team;
            }
        }
        async void OnListViewItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TeamPage());
        }
    }
}