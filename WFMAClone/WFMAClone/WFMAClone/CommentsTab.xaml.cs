using System;
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

            // TODO - example of getting the ID:
            Console.WriteLine(((TaskViewModel) BindingContext).Task.Id);
        }

        void OnSaveButtonClicked(object sender, EventArgs e){
        }

        void OnFinalizeButtonClicked(object sender, EventArgs e){
            RestService restService = new RestService();
            int id = ((TaskViewModel)BindingContext).Task.Id;
            restService.FinalizeTask(id);
        }


        void OnAcceptButtonClicked(object sender, EventArgs e)
        {
            RestService restService = new RestService();
            int id = ((TaskViewModel)BindingContext).Task.Id;
            restService.AcceptTask(id);
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
        }


    }
}
