using MaicoHub.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MaicoHub.Views
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