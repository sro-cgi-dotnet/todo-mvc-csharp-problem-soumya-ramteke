using System.Collections.Generic;

namespace todo_mvc_csharp_problem_soumya_ramteke.Models{
    public interface INoteRepository{
        Note RetrieveNote(int Id);
        List<Note> RetrieveNote(string text, string type);
        List<Note> RetrieveAllNotes();
        bool CreateNote(Note note);
        bool EditNote(int id, Note note);
        bool DeleteNote(int id);
    }
}