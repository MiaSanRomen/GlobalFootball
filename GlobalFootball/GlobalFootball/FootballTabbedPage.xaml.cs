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
    public partial class FootballTabbedPage : TabbedPage
    {
        public FootballTabbedPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            BarBackgroundColor = Color.FromHex(Data.DataManager.settings.BackColor);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            TabLeague.Title = Language.keyLeagues;
            TabSearch.Title = Language.keySearch;
            TabSettings.Title = Language.keySettings;
        }
    }
}