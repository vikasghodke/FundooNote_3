using BusinessLayer.Interface;
using ModelLayer;
using RepoLayer.Entity;
using RepoLayer.Interface;

namespace BusinessLayer.Service
{
    public class NoteBL : INoteBL
    {
        public readonly INoteRL noteRL;

        public NoteBL(INoteRL noteRL)
        {
            this.noteRL = noteRL;
        }

        public NoteEntity AddNote(NoteModel noteModel,int _userID)
        {
            return noteRL.AddNote(noteModel,_userID);

        }
        
        public NoteEntity EditNote1(EditNote editNote, int _noteID)
        {

            return noteRL.EditNote1(editNote, _noteID);
        }
        public NoteEntity DeleteNote(int _noteID, int _userID)
        {
            return noteRL.DeleteNote(_noteID, _userID);
        }

        public NoteEntity ViewNote(int _userID, int _noteID)
        {
            return noteRL.ViewNote(_userID, _noteID);
        }
        public bool Archive_UnArchive(int _userId, long _noteId)
        {
            return noteRL.Archive_UnArchive(_userId, _noteId);
        }

    }
}
