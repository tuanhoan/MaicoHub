using MaicoHub.ViewModels;
using MaicoHub.Views;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MaicoHub
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        private const string APP_NAME = "MaicoHub";
        public AppShell()
        {
            InitializeComponent();

            LoadCallLog();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        [Obsolete]
        public async void LoadCallLog()
        {
            try
            {
                var statusMic = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Microphone);
                var statusStorage = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
                var statusPhone = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Phone);
                var statusContact = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Contacts); 
                if (statusMic != PermissionStatus.Granted || statusStorage != PermissionStatus.Granted || statusStorage != PermissionStatus.Granted || statusContact != PermissionStatus.Granted) 
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Contacts))
                    {
                        await DisplayAlert(APP_NAME, "Se requiere permisos para acceder a los contactos", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Contacts, Permission.Phone, Permission.Storage,Permission.Microphone);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Contacts))
                        statusContact = results[Permission.Contacts];
                    if (results.ContainsKey(Permission.Phone))
                        statusPhone = results[Permission.Phone];
                    if (results.ContainsKey(Permission.Microphone))
                        statusPhone = results[Permission.Microphone];
                    if (results.ContainsKey(Permission.Storage))
                        statusPhone = results[Permission.Storage];
                }
            }
            catch (Exception es)
            { 
                await DisplayAlert("Call Log", "Ha ocurrido un problema, comuniquese con el soporte al cliente. Reporte Técnico: " + es.Message, "OK");
            }
            finally
            {
            }
        }

    }
}
