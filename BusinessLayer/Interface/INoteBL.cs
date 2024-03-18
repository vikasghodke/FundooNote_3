using ModelLayer;
using RepoLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        //public NoteEntity AddNote(NoteModel noteModel, int _userID);
        public NoteEntity AddNote(NoteModel noteModel,int _userID);

        // public NoteEntity UpdateNote(NoteModel noteModel);

        public NoteEntity EditNote1(EditNote editNote, int _noteID);

        public NoteEntity DeleteNote(int _noteID, int _userID);

        public NoteEntity ViewNote(int _userID, int _noteID);

        public bool Archive_UnArchive(int _userId, long _noteId);

    }
}
