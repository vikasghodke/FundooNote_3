using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRL
    {
        //public NoteEntity AddNote(NoteModel noteModel, int _userID);
        // public NoteEntity UpdateNote(NoteModel notemodel);
        public NoteEntity AddNote(NoteModel noteModel, int _uerID);

        public NoteEntity EditNote1(EditNote editNote, int _noteID);

        public NoteEntity DeleteNote(int _noteID, int _userID);

        public NoteEntity ViewNote(int _noteID, int _userID);
        public bool Archive_UnArchive(int _userId, long _noteId);

    }
}
