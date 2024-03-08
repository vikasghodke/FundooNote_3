using ModelLayer;
using RepoLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        //public NoteEntity AddNote(NoteModel noteModel, int _userID);
        public NoteModel AddNote(NoteModel noteModel, int _userID);

        // public NoteEntity UpdateNote(NoteModel noteModel);

        public NoteEntity EditNote1(EditNote editNote, int _userID);

        public NoteEntity DeleteNote(NoteModel noteModel, int _userID);

        public NoteEntity ViewNote(NoteModel noteModel, int _userID);
    }
}
