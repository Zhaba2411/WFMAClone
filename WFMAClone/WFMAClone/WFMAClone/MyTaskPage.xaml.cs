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
		public MyTaskPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            RestService restService = new RestService();
            MyTask taskList = await restService.getTaskByIdAsync(1);
        }

    }
}