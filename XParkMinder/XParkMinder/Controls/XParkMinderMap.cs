using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace XParkMinder.Controls
{
    public class XParkMinderMap : Map
    {
        public CustomPin ParkedPin { get; set; }
        public CustomPin UserPin { get; set; }

    }
}
