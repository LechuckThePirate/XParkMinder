using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Autofac;

namespace XParkMinder.Droid
{
    [Activity(Label = "XParkMinder", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle); 

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Xamarin.FormsMaps.Init(this,bundle);

            var iocContainer = IocContainer.RegisterTypes();
            using (var scope = iocContainer.BeginLifetimeScope())
            {
                var app = iocContainer.Resolve<XParkMinderApp>();
                LoadApplication(app);
            }
        }
    }
}

