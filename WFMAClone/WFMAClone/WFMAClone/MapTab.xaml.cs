using Esri.ArcGISRuntime.Mapping;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapTab : ContentPage
    {

        public MapTab()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Map myMap = new Map(BasemapType.LightGrayCanvasVector,45.8010897, 15.9315005,16);

            MyMapView.Map = myMap;
        }
    }

}
