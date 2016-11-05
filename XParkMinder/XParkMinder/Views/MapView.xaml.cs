using Xamarin.Forms;
using XParkMinder.ViewModels;

namespace XParkMinder.Views
{
    public partial class MapView : ContentPage
    {

        public MapView(MapViewModel viewModel)
        {
            this.Title = "XParkMinder";
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
