using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentsTab : ContentPage
    {
        public DocumentsTab()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new TaskViewModel();
        }

        // select document (open details page)
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Document doc = e.SelectedItem as Document;
                await Navigation.PushModalAsync(new DocumentDetailsPage(doc));

                // de-select the row:
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
