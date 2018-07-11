using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsTab : ContentPage
    {
        public DocumentsTab()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new TaskViewModel();
        }
    }

}
