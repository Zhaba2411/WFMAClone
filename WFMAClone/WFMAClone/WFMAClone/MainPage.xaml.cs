using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WFMAClone
{
    public partial class MainPage : ContentPage
    {
        private static List<MyTask> notFilteredTaskList = new List<MyTask>();


        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            WFMAClone.RestService restService = new WFMAClone.RestService();

            MyTaskList taskList = await restService.getTaskListAsync();

            if (taskList.Tasks != null){
                notFilteredTaskList = taskList.Tasks;
                listView.ItemsSource = taskList.Tasks;
            }
            else{
                Console.WriteLine("taskList.Tasks is empty! Can't set listView.ItemsSource");
                Console.ReadLine();
            }
        }


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //((App)App.Current).ResumeAtTodoId = (e.SelectedItem as TodoItem).ID;x
            //Debug.WriteLine("setting ResumeAtTodoId = " + (e.SelectedItem as TodoItem).ID);
            if (e.SelectedItem != null)
            {
                var task = e.SelectedItem as MyTask;
                await Navigation.PushModalAsync(new MyTaskPage(task.Id));


                //await Navigation.PushModalAsync(new MyTaskPage{
                //    BindingContext = e.SelectedItem as MyTask
                //});

            }
        }

        void OnDateFilterButtonClicked(object sender, EventArgs e)
        {
            picker.Focus();
        }

        void DatePicker_OnDateSelected(object sender, DateChangedEventArgs e)
        {
            List<MyTask> filteredList = new List<MyTask>();
            foreach (var Task in notFilteredTaskList)
            {
                if (Task.DueDate.Date.Equals(e.NewDate)){
                    Console.WriteLine("Task date is same!");
                    Console.ReadLine();
                    filteredList.Add(Task);
                }
            }
            listView.ItemsSource = filteredList;
        }

		async void OnQuickFilterButtonClicked(object sender, EventArgs e)
		{
			var action = await DisplayActionSheet("Quick Filters", "Cancel", "", "New", "Accepted", "Downloaded", "Not Downloaded");
			action = action.ToLower();
			Console.WriteLine(action);
			if (String.IsNullOrWhiteSpace(action) || action.Equals("Cancel"))
			{
			}
			else
			{
				List<MyTask> filteredList = new List<MyTask>();
				foreach (var task in notFilteredTaskList)
				{
					if (task.Status.Equals(action))
					{
						filteredList.Add(task);
					}
				}
				listView.ItemsSource = filteredList;
			}
		}

		void OnRemoveFilterButtonClicked(object sender, EventArgs e)
        {
            listView.ItemsSource = notFilteredTaskList;
        }

    }
}