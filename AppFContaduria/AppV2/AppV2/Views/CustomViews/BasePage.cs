using AppV2.Views.CustomViews;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppV2.Views.CustomViews
{
    public class BasePage : ContentPage
    {
        public BasePage()
        {
            // Agregar el código del menú aquí
            MenuView menu = new MenuView();

            Grid mainGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }, // Primera fila para el contenido principal
                    new RowDefinition { Height = GridLength.Auto }, // Segunda fila para el menú
                }
            };

            //mainGrid.Children.Add(listaMaterias, 0, 0); // Agregar el ListView al contenido principal
            mainGrid.Children.Add(menu, 0, 1); // Agregar el MenuView debajo del contenido principal

            Content = mainGrid;
        }
    }
}
