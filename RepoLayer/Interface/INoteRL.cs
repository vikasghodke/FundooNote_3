using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRL
    {
        public NoteEntity AddNote(NoteModel noteModel, int _userID);
        // public NoteEntity UpdateNote(NoteModel notemodel);

        public NoteEntity EditNote1(EditNote editNote, int _UserID);

        public NoteEntity DeleteNote(NoteModel noteModel, int _userID);

        public NoteEntity ViewNote(NoteModel noteModel, int _userID);
    }
}
