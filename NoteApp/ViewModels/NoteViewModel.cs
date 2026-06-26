using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Data;
using NoteApp.Models;
using System.Collections.ObjectModel;

namespace NoteApp.ViewModels {
    public partial class NoteViewModel : ObservableObject{

        DBContext _dBContext;

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
            _dBContext = new DBContext();
            var ListOfNotes = _dBContext.Notes.ToList();
        }

        [RelayCommand]
        private async Task<bool> EditNote() {
            
                if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                    await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                    return false;
                }
                if(NoteCollection != null) {
                    foreach (Note note in NoteCollection.ToList()) {
                        if (note == SelectedNote) {

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

            return true;
        }

        [RelayCommand]
        private async Task<bool> DeleteNote() {

            if (SelectedNote != null) {

                NoteCollection?.Remove(SelectedNote);
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
            int newId = NoteCollection?.Count > 0 ? 
                NoteCollection.Max(x => x.Id) + 1: 1;

            // for DB Test
            var note1 = new Note{
                Title = NoteTitle,
                Description = NoteDescription
            };

            await _dBContext.AddAsync(note1);
            await _dBContext.SaveChangesAsync();

            // Set New Note
            var note = new Note {
                Id = newId,
                Title = NoteTitle,
                Description = NoteDescription
            };
            NoteCollection?.Add(note);
            SelectedNote = note;

            // Reset Values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;

            return true;
        }

        public void SetData() {
            NoteTitle = SelectedNote?.Title;
            NoteDescription = SelectedNote?.Description;
        }
    }
}
