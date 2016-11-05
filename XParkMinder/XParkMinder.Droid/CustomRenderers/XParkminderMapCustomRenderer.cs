using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using XParkMinder.Controls;
using XParkMinder.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(XParkMinderMap), typeof(XParkminderMapCustomRenderer))]
namespace XParkMinder.Droid.CustomRenderers
{
    public class XParkminderMapCustomRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    {
        GoogleMap map;

        bool isDrawn;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                map.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (XParkMinderMap)e.NewElement;

                ((MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
            map.InfoWindowClick += OnInfoWindowClick;
            map.SetInfoWindowAdapter(this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                map.Clear();

                // Setup my custom elements here!!

                isDrawn = true;
            }
        }

        void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            // Do what you need to do if they click in any clickable stuff
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            // If they ask for info on a marker, show the view you need to show
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            // Not needed as we draw our info in the default InfoWindow
            return null;
        }
    }
}