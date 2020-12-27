using GlobalFootball;
using GlobalFootball.Data;
using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootballWorld
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        
        async void OnStartButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FootballTabbedPage
            {
                BindingContext = new League()
            });
        }
    }
}