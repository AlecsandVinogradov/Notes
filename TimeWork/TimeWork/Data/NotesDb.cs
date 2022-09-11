using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeWork.Models;

namespace TimeWork.Data
{
    public class NotesDb
    {
        readonly SQLiteAsyncConnection db;
        public NotesDb(string connect)
        {
            db = new SQLiteAsyncConnection(connect);
            db.CreateTableAsync<Note>().Wait();
        }
        public Task<List<Note>> GetNotesAsync()
        {
            return db.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNotesAsync(int id)
        {
            return db.Table<Note>()
                .Where(i => i.Id == id)
                .FirstAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            return note.Id != 0 ? db.UpdateAsync(note) : db.InsertAsync(note);
        }
        public Task<int> DeleteNote(Note note)
        {
            return db.DeleteAsync(note);
        }
    }
}
