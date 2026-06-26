using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Models;
using System.Collections.ObjectModel;

namespace NoteApp.ViewModels {
    public partial class NoteViewModel : ObservableObject{

        // Fields
        [ObservableProperty]
        public partial string? NoteTitle { get; set; }

        [ObservableProperty]
        public partial string? NoteDescription { get; set; }

        [ObservableProperty]
        public partial Note? SelectedNote { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Note>? NoteCollection { get; set; }

        // Constructor
        public NoteViewModel() {
            NoteCollection = new ObservableCollection<Note>();
        }

        [RelayCommand]
        private async Task<bool> EditNote() {
            if (SelectedNote != null) {
                if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                    await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                    return false;
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
                    }else return false;
                }
            }
            return true;
        }

        [RelayCommand]
        private async Task<bool> DeleteNote() {

            if (SelectedNote != null) {

                NoteCollection.Remove(SelectedNote);
                // Reset Values
                NoteTitle = string.Empty;
                NoteDescription = string.Empty;
                return true;
            } else return false;
        }

        [RelayCommand]
        private async Task<bool> AddNote() {

            if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                return false;
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

            return true;
        }

    }
}
