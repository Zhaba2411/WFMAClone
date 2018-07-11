using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class TaskViewModel : ContentPage, INotifyPropertyChanged
    {
        private static MyTaskDetails task;

        public MyTaskDetails Task {
            get { return task; }
            set {
                task = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            Console.WriteLine("==> Property changed");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TaskViewModel() {
            if (task == null) {
                Console.WriteLine("==> NEW task (ViewModel)");
                task = new MyTaskDetails();
            }
        }

        async public void getById(int id) {
            Console.WriteLine("==> GET getById (ViewModel): " + id);
            RestService restService = new RestService();
            task = await restService.getTaskByIdAsync(id);
            // OnPropertyChanged();

            // add worker initials on comments:
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
        }
    }
}
