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

        void OnAcceptButtonClicked(object sender, EventArgs e){
        }

        void OnSaveButtonClicked(object sender, EventArgs e){
        }

        void OnFinalizeButtonClicked(object sender, EventArgs e){
        }

    }
}
