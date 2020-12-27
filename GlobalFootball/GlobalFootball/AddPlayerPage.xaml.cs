using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPlayerPage : ContentPage
    {
        public AddPlayerPage()
        {
            InitializeComponent();
            Name.Text = Language.keyName;
            Surname.Text = Language.keySurname;
            Position.Text = Language.keyPosition;
            Years.Text = Language.keyYears;
            Goals.Text = Language.keyGoals;
            PriceChanges.Text = Language.keyPrices;
            PlayerCreated.Text = Language.keyCreate;
        }

        int checkInteger(Editor editor, int num)
        {
            if (!Int32.TryParse(editor.Text, out num))
            {
                editor.Text = "Wrong!";
            }
            return num;
        }
        async void ToolbarItemCommand(object sender, EventArgs e)
        {

            if (NameEditor.Text != null && SurnameEditor.Text != null && PositionEditor.Text != null &&
                YearsEditor.Text != null && GoalsEditor.Text != null)
            {
                var player = new Player();
                player.Name = NameEditor.Text;
                player.Surname = SurnameEditor.Text;
                player.Position = PositionEditor.Text;
                player.Years = checkInteger(YearsEditor, player.Years);
                player.Goals = checkInteger(GoalsEditor, player.Goals);
                player.Price[0] = checkInteger(Editor15, player.Price[0]);
                player.Price[1] = checkInteger(Editor16, player.Price[1]);
                player.Price[2] = checkInteger(Editor17, player.Price[2]);
                player.Price[3] = checkInteger(Editor18, player.Price[3]);
                player.Price[4] = checkInteger(Editor19, player.Price[4]);
                player.Image = "unknown";
                LeaguePage.SelectedTeam.Players.Add(player);
                await Navigation.PopAsync();
            }
        }
        
    }
}