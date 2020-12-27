using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GlobalFootball.Data;
using GlobalFootball.Structure;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {
        public static int Num = 0;
        public static int Right = 0;
        public QuizPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            FiilFields();
            Blackbtn.IsEnabled = true;
            Bluebtn.IsEnabled = true;
            Greenbtn.IsEnabled = true;
            Blackbtn.IsVisible = true;
            Bluebtn.IsVisible = true;
            Greenbtn.IsVisible = true;
        }

        void FiilFields()
        {
            labelRestart.Text = Language.keyScore + " " + Right.ToString();
            labelRestart.IsVisible = true;
            Num++;
            if (Num == 6)
            {
                Blackbtn.IsEnabled = false;
                Bluebtn.IsEnabled = false;
                Greenbtn.IsEnabled = false;
                Blackbtn.IsVisible = false;
                Bluebtn.IsVisible = false;
                Greenbtn.IsVisible = false;
                Num = 1;
                Right = 0;
                return;
            }
            question.Text = DataManager.Questions[Num].MainQuestion;
            a1.Text = DataManager.Questions[Num].Answers[0];
            a2.Text = DataManager.Questions[Num].Answers[1];
            a3.Text = DataManager.Questions[Num].Answers[2];
            
            
            
            
        }

        public void Set1(object sender, EventArgs e)
        {
            if(DataManager.Questions[Num].Right == 1)
            {
                Right++;
            }
            FiilFields();
        }
        public void Set2(object sender, EventArgs e)
        {
            if (DataManager.Questions[Num].Right == 2)
            {
                Right++;
            }
            FiilFields();
        }
        public void Set3(object sender, EventArgs e)
        {
            if (DataManager.Questions[Num].Right == 3)
            {
                Right++;
            }
            FiilFields();
        }
    }
}