using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentsTab : ContentPage
    {

        public CommentsTab()
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
