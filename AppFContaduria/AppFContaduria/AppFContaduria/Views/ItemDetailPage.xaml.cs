using AppFContaduria.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppFContaduria.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}