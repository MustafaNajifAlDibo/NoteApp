namespace NoteApp {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();

            Contianer.Content = new Views.NoteView();
        }

    }
}
