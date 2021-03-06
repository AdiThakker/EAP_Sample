﻿
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using EAP.Xamarin.Service;

namespace EAP.Xamarin.Core.Droid
{
    [Activity(Label = "EAP Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            UserDialogs.Init(this);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new EAPService(new AppConfiguration().GetConnectionUri())));
        }
    }
}