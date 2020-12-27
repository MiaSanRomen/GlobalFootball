using GlobalFootball.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GlobalFootball.Data;
using System.Globalization;
using System.Threading;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Diagnostics;

namespace GlobalFootball
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerPage : ContentPage
    {
        public Player MyPlayer = new Player();
        public PlayerPage()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(EnumHelper.GetDescription(DataManager.settings.Language));
            InitializeComponent();
            MyPlayer = TeamPage.SelectedPlayer;
            PlayerImage.Source = MyPlayer.Image;
            PlayerName.Text = MyPlayer.Name + " " + MyPlayer.Surname;
            PlayerPosition.Text = MyPlayer.Position;
            PlayerAge.Text = Language.keyYears + " " + MyPlayer.Years.ToString();
            PlayerGoals.Text = Language.keyGoals + " " + MyPlayer.Goals.ToString();
            label.BackgroundColor = Color.FromHex(DataManager.settings.BackColor);
            label.Text = Language.keyPriceChanges;
            DeletePlayer.Text = Language.keyDelete;
        }

        async void ToolbarItemCommand(object sender, EventArgs e)
        {
            var itemToRemove = LeaguePage.SelectedTeam.Players.FirstOrDefault(r => r.Name == MyPlayer.Name);
            if (itemToRemove != null)
            {
                LeaguePage.SelectedTeam.Players.Remove(itemToRemove);
            }
            await Navigation.PopAsync();
        }

        private int Price(int[] prices)
        {
            int max = 0;
            foreach (int price in prices)
            {
                if (price > max)
                    max = price;
            }
            if (max == 0)
            {
                return 0;
            }
            return (int)(675 / max);
        }

        public void PriceColor(int a, int b, SKPaint paint)
        {
            if (a > b)
            {
                paint.Color = SKColors.Red;
            }
            else if (a == b)
            {
                paint.Color = SKColors.Yellow;
            }
            else
            {
                paint.Color = SKColors.Green;
            }
        }
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var canvas = surface.Canvas;
            canvas.Clear();

            var Border = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Black,
                StrokeWidth = 5
            };

            var Progress = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Blue,
                StrokeWidth = 10
            };

            var circleFill = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                Color = SKColors.Yellow
            };

            var textPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 30,
                TextAlign = SKTextAlign.Center
            };

            canvas.DrawLine(50, 50, 50, 800, Border);
            canvas.DrawLine(50, 800, 650, 800, Border);
            canvas.DrawLine(50, 50, 45, 60, Border);
            canvas.DrawLine(50, 50, 55, 60, Border);
            canvas.DrawLine(650, 800, 640, 795, Border);
            canvas.DrawLine(650, 800, 640, 805, Border);

            canvas.DrawLine(50, 800 - Price(MyPlayer.Price) * MyPlayer.Price[0], 200, 800 - Price(MyPlayer.Price) * MyPlayer.Price[1], Progress);
            canvas.DrawLine(200, 800 - Price(MyPlayer.Price) * MyPlayer.Price[1], 350, 800 - Price(MyPlayer.Price) * MyPlayer.Price[2], Progress);
            canvas.DrawLine(350, 800 - Price(MyPlayer.Price) * MyPlayer.Price[2], 500, 800 - Price(MyPlayer.Price) * MyPlayer.Price[3], Progress);
            canvas.DrawLine(500, 800 - Price(MyPlayer.Price) * MyPlayer.Price[3], 650, 800 - Price(MyPlayer.Price) * MyPlayer.Price[4], Progress);


            canvas.DrawCircle(50, 800 - Price(MyPlayer.Price) * MyPlayer.Price[0], 10, circleFill);
            PriceColor(MyPlayer.Price[0], MyPlayer.Price[1], circleFill);
            canvas.DrawCircle(200, 800 - Price(MyPlayer.Price) * MyPlayer.Price[1], 10, circleFill);
            PriceColor(MyPlayer.Price[1], MyPlayer.Price[2], circleFill);
            canvas.DrawCircle(350, 800 - Price(MyPlayer.Price) * MyPlayer.Price[2], 10, circleFill);
            PriceColor(MyPlayer.Price[2], MyPlayer.Price[3], circleFill);
            canvas.DrawCircle(500, 800 - Price(MyPlayer.Price) * MyPlayer.Price[3], 10, circleFill);
            PriceColor(MyPlayer.Price[3], MyPlayer.Price[4], circleFill);
            canvas.DrawCircle(650, 800 - Price(MyPlayer.Price) * MyPlayer.Price[4], 10, circleFill);

            canvas.DrawText(MyPlayer.Price[0].ToString() + ".0 M", 50, 780 - Price(MyPlayer.Price) * MyPlayer.Price[0], textPaint);
            canvas.DrawText(MyPlayer.Price[1].ToString() + ".0 M", 200, 780 - Price(MyPlayer.Price) * MyPlayer.Price[1], textPaint);
            canvas.DrawText(MyPlayer.Price[2].ToString() + ".0 M", 350, 780 - Price(MyPlayer.Price) * MyPlayer.Price[2], textPaint);
            canvas.DrawText(MyPlayer.Price[3].ToString() + ".0 M", 500, 780 - Price(MyPlayer.Price) * MyPlayer.Price[3], textPaint);
            canvas.DrawText(MyPlayer.Price[4].ToString() + ".0 M", 650, 780 - Price(MyPlayer.Price) * MyPlayer.Price[4], textPaint);
        }

        async void PlayerImage_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet(Language.keyGetPhoto, Language.keyCancel, null, Language.keyCamera, Language.keyMedia);
            if(action== Language.keyCamera)
            {
                if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
                {
                    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        Directory = "Sample",
                        Name = $"{MyPlayer.Surname}.png"
                    });

                    if (file == null)
                        return;
                    MyPlayer.Image = file.Path;
                }
            }
            if (action == Language.keyMedia)
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                    MyPlayer.Image = photo.Path;
                    
                }
            }
            PlayerImage.Source = MyPlayer.Image;
        }
    }
}