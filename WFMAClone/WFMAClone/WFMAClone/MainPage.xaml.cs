using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WFMAClone
{
	public partial class MainPage : ContentPage
	{
        public MainPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			RestService restService = new RestService();

			TaskList taskList = await restService.RefreshDataAsync();
			listView.ItemsSource = taskList.Tasks;
		}


		async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;x
			//Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
			if (e.SelectedItem != null)
			{
                var task = e.SelectedItem as MyTaskList;
                await Navigation.PushModalAsync(new MyTaskPage(task.Id));

                /*
                await Navigation.PushModalAsync(new MyTaskPage
                {
                    BindingContext = e.SelectedItem as MyTask
                });
                */
            }
		}
        void OnDateFilterButtonClicked(object sender, EventArgs e)
        {
        }
        void OnQuickFilterButtonClicked(object sender, EventArgs e)
        {
        }
        void OnRemoveFilterButtonClicked(object sender, EventArgs e)
        {
        }

	}
}
