using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyTaskPage : TabbedPage
	{
        int id;

		public MyTaskPage (int id)
		{
			InitializeComponent ();
            this.id = id;

            // this.Title = "TabbedPage";
        }

        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            RestService restService = new RestService();
            MyTask task = await restService.getTaskByIdAsync(id);

            currentTask.BindingContext = task;

			foreach (Comment comment in task.Comments)
			{
				string name = comment.WorkerName;
				string initials = "";
				if (!String.IsNullOrWhiteSpace(name) && name.Contains(" ") && Char.IsLetter(name, name.IndexOf(" ") + 1))
				{
					initials += name[0];
					initials += name[(name.IndexOf(" ") + 1)];
				}
				else
				{
					initials += name[0];
					initials += name[0]; 
				}
				comment.Initials = initials;	
			}
			listView.ItemsSource = task.Comments;
        }
        */


            /*
        async void OnNavigateButtonClicked(object sender, EventArgs e)         {             await Navigation.PopModalAsync();         }
        */
    }
}