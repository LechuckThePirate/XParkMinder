using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XParkMinder.Application.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Comms.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.ViewModels;
using XParkMinder.Views;

namespace XParkMinder
{
    public class XParkMinderApp : Xamarin.Forms.Application
    {

        public XParkMinderApp(MapView view)
        {
            MainPage = new NavigationPage(view);
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
