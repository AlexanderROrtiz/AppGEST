using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppV2.Views.CalificarClaseEstudiante
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalificarClaseE : ContentPage
    {
        public CalificarClaseE()
        {
            InitializeComponent();
        }
        private void BtnCerrarS(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PageLogin();
        }
    }
}