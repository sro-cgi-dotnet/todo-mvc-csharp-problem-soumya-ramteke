using System.Collections.Generic;

namespace TodoApi.Models{
    public interface INoteRepository{
        Note RetrieveNote(int Id);
        List<Note> RetrieveNote(string text, string type);
        List<Note> RetrieveAllNotes();
        bool CreateNote(Note note);
        bool EditNote(int id, Note note);
        bool DeleteNote(int id);
    }
}