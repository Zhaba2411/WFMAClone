using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyTaskPage : ContentPage
	{
        int id;

		public MyTaskPage (int id)
		{
			InitializeComponent ();
            this.id = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            RestService restService = new RestService();
            MyTask task = await restService.getTaskByIdAsync(id);

            currentTask.BindingContext = task;
        }

    }
}