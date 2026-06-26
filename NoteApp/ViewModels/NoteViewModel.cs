using NoteApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoteApp.ViewModels {
    public partial class NoteViewModel : INotifyPropertyChanged{

        // Fields
        private string? _noteTitle;
        private string? _noteDescription;
        private Note? _selectedNote;

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
                    OnPropertyChanged();
                }
            }
        }

        // Properties
        public ObservableCollection<Note>? NoteCollection { get; set; }



        // Constructor
        public NoteViewModel() {
            NoteCollection = new ObservableCollection<Note>();
        }


        // PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
