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

        //public NoteEntity AddNote(NoteModel noteModel,int _userID)
        public NoteModel AddNote(NoteModel noteModel, int _userID)
        {
            return noteRL.AddNote(noteModel, _userID);

        }
        /* public NoteEntity UpdateNote(NoteModel noteModel)
         {
             return noteRL.UpdateNote(noteModel);
         }*/
        public NoteEntity EditNote1(EditNote editNote, int _userID)
        {

            return noteRL.EditNote1(editNote, _userID);
        }
        public NoteEntity DeleteNote(NoteModel notemodel, int _userID)
        {
            return noteRL.DeleteNote(notemodel, _userID);
        }

        public NoteEntity ViewNote(NoteModel notemodel, int _userID)
        {
            return noteRL.ViewNote(notemodel, _userID);
        }

    }
}
