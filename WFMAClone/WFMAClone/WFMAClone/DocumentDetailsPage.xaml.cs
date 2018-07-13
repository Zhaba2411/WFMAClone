using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WFMAClone
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DocumentDetailsPage : ContentPage
    {
        Document Document;

        public DocumentDetailsPage(Document doc) {
            InitializeComponent();

            this.Document = doc;
            BindingContext = Document;

            // handle top bar tap:
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                OnBackButtonClicked(s, e);
            };
            backButton.GestureRecognizers.Add(tapGestureRecognizer);
        }

        void OnDownloadButtonClicked(object sender, EventArgs e) {
            Console.WriteLine("Download file with id: " + Document.Id);         }

        void OnDeleteButtonClicked(object sender, EventArgs e) {
            Console.WriteLine("Delete file with id: " + Document.Id);
        }

        async void OnBackButtonClicked(object sender, EventArgs e) {             await Navigation.PopModalAsync();         }

    }
}
