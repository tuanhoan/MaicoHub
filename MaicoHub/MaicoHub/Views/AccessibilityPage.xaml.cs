using MaicoHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaicoHub.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccessibilityPage : ContentPage
    {
        public AccessibilityPage()
        {
            InitializeComponent();
            this.BindingContext = new AccessibilityModel();
        }
    }
}