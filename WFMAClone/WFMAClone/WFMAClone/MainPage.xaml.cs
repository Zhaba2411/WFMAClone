using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFMAClone.Models;
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

			List<ColoredTask> coloredTasks = new List<ColoredTask>();
			TaskList taskList = await restService.RefreshDataAsync();
			foreach(MyTaskList task in taskList.Tasks)
			{
				coloredTasks.Add(new ColoredTask(task));
			}
			listView.ItemsSource = coloredTasks;
		}

		async void OnItemAdded(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new MyTaskPage
			{
				BindingContext = new MyTaskList()
			});
		}

		async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			//((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;
			//Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
			if (e.SelectedItem != null)
			{

                Console.WriteLine("write LINK **");
                Console.ReadLine();

                await Navigation.PushModalAsync(new MyTaskPage
				{
					BindingContext = e.SelectedItem as MyTask
				});
			}
		}
	}
}
