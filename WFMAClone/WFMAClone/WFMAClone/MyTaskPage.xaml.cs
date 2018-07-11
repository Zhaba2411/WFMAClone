using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyTaskPage : TabbedPage
	{
        TaskViewModel Task;

        public MyTaskPage (int id)
		{
			InitializeComponent ();
            Task = new TaskViewModel();
            Task.getById(id);
            BindingContext = this;
        }

        protected override async void OnAppearing() {
            base.OnAppearing();
        }

        /*
        async void OnNavigateButtonClicked(object sender, EventArgs e)         {             await Navigation.PopModalAsync();         }
        */
    }
}