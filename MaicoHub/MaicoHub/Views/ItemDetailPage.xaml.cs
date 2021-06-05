using MaicoHub.ViewModels;
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