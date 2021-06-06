using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;
using MaicoHub.Droid.Service;
using MaicoHub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Accessibility))]
namespace MaicoHub.Droid.Service
{
    class Accessibility : IAccessibility
    {
        [Obsolete]
        public void Active()
        {
            Forms.Context.StartActivity(new Android.Content.Intent(Android.Provider.Settings.ActionAccessibilitySettings));
        }

    }
}