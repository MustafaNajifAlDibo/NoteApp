using NoteApp.Views;

namespace NoteApp {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();

            Contianer.Content = new NoteView();
        }

    }
}
