using NoteApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NoteApp.ViewModels {
    public partial class NoteViewModel : INotifyPropertyChanged{

        // Fields
        private string _noteTitle;
        private string _noteDescription;
        private Note _selectedNote;

        // get set
        public string NoteTitle {
            get => _noteTitle;
            set {
                if(_noteTitle != value) { 
                    _noteTitle = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NoteDescription {
            get => _noteDescription;
            set {
                if (_noteDescription != value) {
                    _noteDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public Note SelectedNote {
            get => _selectedNote;
            set {
                if (_selectedNote != value) {
                    _selectedNote = value;
                    // Set from Collection to UI
                    NoteTitle = _selectedNote.Title;
                    NoteDescription = _selectedNote.Description;
                    OnPropertyChanged();
                }
            }
        }

        // Properties
        public ObservableCollection<Note> NoteCollection { get; set; }

        // Commands
        public ICommand AddNoteCommand { get;}
        public ICommand EditNoteCommand { get; }
        public ICommand RemoveNoteCommand { get; }

        // Constructor
        public NoteViewModel() {
            NoteCollection = new ObservableCollection<Note>();

            AddNoteCommand = new Command(AddNote);
            RemoveNoteCommand = new Command(DeleteNote);
            EditNoteCommand = new Command(EditNote);
        }

        private async void EditNote(object obj) {
            if (SelectedNote != null) {
                if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                    await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                    return;
                }
                foreach (Note note in NoteCollection.ToList()) {
                    if(note == SelectedNote) {

                        // Set new Note
                        var newNote = new Note() {
                            Id = note.Id,
                            Title = NoteTitle,
                            Description = NoteDescription
                        };

                        // Remove Note
                        NoteCollection.Remove(note);
                        NoteCollection.Add(newNote);
                        SelectedNote = newNote;
                    }
                }
            }
        }

        private void DeleteNote(object obj) {

            if (SelectedNote != null) {
                
                NoteCollection.Remove(SelectedNote);
                // Reset Values
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
            }
        }

        private async void AddNote(object obj) {

            if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                return;
            }
                
            // Generatte a Unique ID for the new Note
            int newId = NoteCollection.Count > 0 ? 
                NoteCollection.Max(x => x.Id) + 1: 1;
            // Set New Note
            var note = new Note {
                Title = NoteTitle,
                Description = NoteDescription
            };
            NoteCollection.Add(note);
            SelectedNote = note;

            // Reset Values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;
        }


        // PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
