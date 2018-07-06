using Android.Widget;
using Intents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			/*List<MyTask> lista = new List<MyTask>();
			MyTask t = new MyTask();
			t.Name = "BOK";
			lista.Add(t);
			listView.ItemsSource = lista;*/
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MyTaskPage
			{
				BindingContext = new MyTask()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
			//Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
			if (e.SelectedItem != null)
			{
				await Navigation.PushAsync(new MyTaskPage
				{
					BindingContext = e.SelectedItem as MyTask
				});
			}
		}
	}
}
