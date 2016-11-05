using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XParkMinder.ViewModels;

namespace XParkMinder.Views
{
    public partial class MapView : ContentPage
    {

        public MapView(MapViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
