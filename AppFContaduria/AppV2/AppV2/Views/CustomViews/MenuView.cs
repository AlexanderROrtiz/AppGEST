using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppV2.Views.CustomViews
{
    public class MenuView : ContentView
    {
        public MenuView()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            Grid menuGrid = new Grid
            {
                BackgroundColor = Color.FromHex("#26B5A1"),
                VerticalOptions = LayoutOptions.End,
                HeightRequest = 50,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
            };

            ImageButton backButton = new ImageButton
            {
                Source = "back.png",
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.FromHex("#26B5A1")
            };

            ImageButton homeButton = new ImageButton
            {
                Source = "home.png",
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.FromHex("#26B5A1")
            };

            ImageButton configButton = new ImageButton
            {
                Source = "conf.png",
                Aspect = Aspect.AspectFit,
                BackgroundColor = Color.FromHex("#26B5A1")
            };

            // Agrega los eventos Clicked a los botones aquí si es necesario

            menuGrid.Children.Add(backButton, 0, 0);
            menuGrid.Children.Add(homeButton, 1, 0);
            menuGrid.Children.Add(configButton, 2, 0);

            Content = menuGrid;
        }
    }
}
