using NoteApp.ViewModels;

namespace NoteApp.Views;

public partial class NoteView : ContentView
{

	private readonly NoteViewModel _noteViewModel;
	public NoteView(NoteViewModel noteViewModel)
	{
		InitializeComponent();

		BindingContext = noteViewModel;

		_noteViewModel = noteViewModel;
	}

    private void CollectionViewNote_SelectionChanged(object sender, SelectionChangedEventArgs e) {
		_noteViewModel.SetData();
    }
}