using MaicoHub.Models;
using MaicoHub.ViewModels;
using Xamarin.Forms;

namespace MaicoHub.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}