using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data {
    public class NoteEntity : IDataHelper<Note> {

        private DBContext dBContext;

        public NoteEntity() {
            dBContext = new DBContext();
        }



        public async Task AddDataAsync(Note table) {
            await dBContext.Notes.AddAsync(table);
            await dBContext.SaveChangesAsync();
        }

        public async Task<Note> FindAsync(int Id) {
            return await dBContext.Notes.FindAsync(Id);
        }

        public async Task<List<Note>> GetAllAsync() {
            return await dBContext.Notes.ToListAsync();
        }

        public async Task RemoveDataAsync(Note table) {
            dBContext.Notes.Remove(table);
            await dBContext.SaveChangesAsync();
        }

        public async Task UpdateDataAsync(Note table) {
            dBContext = new DBContext();
            dBContext.Notes.Update(table);
            await dBContext.SaveChangesAsync();
        }
    }
}
