using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NoteApp.Data;
using NoteApp.Models;
using System.Collections.ObjectModel;

namespace NoteApp.ViewModels {
    public partial class NoteViewModel : ObservableObject{

        NoteEntity dataHelper;


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

            dataHelper = new NoteEntity();

            LoadData();
        }

        [RelayCommand]
        private async Task<bool> EditNote() {
            
            if (string.IsNullOrEmpty(NoteTitle) || string.IsNullOrEmpty(NoteDescription)) {
                await Shell.Current.DisplayAlertAsync("Warning", "Messing one or two text", "OK");
                return false;
            }
            if(NoteCollection != null) {
               
                if (SelectedNote != null) {

                    // Set new Note
                    var newNote = new Note() {
                        Id = SelectedNote.Id,
                        Title = NoteTitle,
                        Description = NoteDescription
                    };
                    await dataHelper.UpdateDataAsync(newNote);
                    LoadData();

                    SelectedNote = await dataHelper.FindAsync( newNote.Id);
                }
            }
            return true;
        }

        [RelayCommand]
        private async Task<bool> DeleteNote() {

            if (SelectedNote != null) {

                await dataHelper.RemoveDataAsync(SelectedNote);
                LoadData();

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

            // for DB Test
            var note = new Note{
                Title = NoteTitle,
                Description = NoteDescription
            };
            await dataHelper.AddDataAsync(note);
            LoadData();

            // Reset Values
            NoteTitle = string.Empty;
            NoteDescription = string.Empty;

            return true;
        }

        public void SetData() {
            NoteTitle = SelectedNote?.Title;
            NoteDescription = SelectedNote?.Description;
        }

        public async void LoadData() {

            NoteCollection?.Clear();
            foreach (var note in await dataHelper.GetAllAsync()) {
                NoteCollection?.Add(note);
            }
        }
    }
}
