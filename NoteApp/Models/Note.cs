

using System.ComponentModel.DataAnnotations;

namespace NoteApp.Models {
    public class Note {

        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
