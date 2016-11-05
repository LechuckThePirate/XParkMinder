using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XParkMinder.Geo.Contracts.ServiceLibrary.DTO;

namespace XParkMinder.Controls
{
    public class XParkMinderMapBehavior : BindableBehavior<XParkMinderMap>
    {
       public static readonly BindableProperty MapSpanProperty = 
            BindableProperty.Create<XParkMinderMapBehavior, MapSpan>(p => p.MapSpan, null, BindingMode.Default, null, PositionChanged);

        public MapSpan MapSpan
        {
            get { return (MapSpan) GetValue(MapSpanProperty); }
            set { SetValue(MapSpanProperty, value); }
        }

        private static void PositionChanged(BindableObject bindable, MapSpan oldValue, MapSpan newValue)
        {
            var behavior = bindable as XParkMinderMapBehavior;
            behavior?.MoveToLocation(newValue);
        }

        private void MoveToLocation(MapSpan mapSpan)
        {
            AssociatedObject.MoveToRegion(mapSpan);
        }

    }
}
