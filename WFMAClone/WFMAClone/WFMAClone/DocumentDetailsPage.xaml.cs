using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentDetailsPage : ContentPage
    {
        Document Document;

        public DocumentDetailsPage(Document doc)
        {
            InitializeComponent();
            this.Document = doc;
            BindingContext = Document;

            // handle top bar tap:
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                OnNavigateButtonClicked(s, e);
            };
            backButton.GestureRecognizers.Add(tapGestureRecognizer);
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e) {             await Navigation.PopModalAsync();         }
    }
}
