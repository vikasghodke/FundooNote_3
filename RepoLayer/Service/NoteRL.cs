using Microsoft.EntityFrameworkCore;
using ModelLayer;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer.Service
{
    public class NoteRL : INoteRL
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;

        public NoteRL(FundoonoteContext1 _fundoonoteContext1)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
        }

        public NoteEntity AddNote(NoteModel noteModel,int _userID)
        {

            NoteEntity note = new NoteEntity();
            note.Title = noteModel.title;
            note.Color = noteModel.color;
            note.IsArchived = noteModel.IsArchived;
            note.IsDeleted = noteModel.IsDeleted;
            note.UserID = _userID;
            

            _fundoonoteContext1.Notes.Add(note);
            _fundoonoteContext1.SaveChanges();

            return note;

        }
        public NoteEntity EditNote1(EditNote editNote, int _userID)
        {
            NoteEntity note1=_fundoonoteContext1.Notes.FirstOrDefault(x=> x.UserID==_userID);
            if (note1 != null)
            {
                note1.Title= editNote.title;

               // _fundoonoteContext1.Notes.Add(note1);
                _fundoonoteContext1.SaveChanges();

                return note1;
            }
            else
            {
                return null;
            }
            

            //_fundoonoteContext1.Notes.Add(note1);
           // _fundoonoteContext1.SaveChanges();

           // return note1;
        }
        public NoteEntity DeleteNote(NoteModel noteModel,int _userID)
        {
            NoteEntity note = _fundoonoteContext1.Notes.FirstOrDefault(x => x.UserID == _userID);
            if (note != null)
            {
                _fundoonoteContext1.Notes.Remove(note);
                _fundoonoteContext1.SaveChanges();
            }
            return note;
        }
        public NoteEntity ViewNote(NoteModel noteModel, int _userID)
        {
            NoteEntity note=_fundoonoteContext1.Notes.FirstOrDefault(x=>x.UserID == _userID);
            if (note != null)
            {
                return note;
            }
            else
            {
                return null;
            }
        }
      
            
            
            
            
            
            
            
            
            
            
            
            /* public NoteEntity UpdateNote(NoteModel noteModel, int _UserID)
        {
            //NoteEntity noteEntity=DbContext.(x=x.NoteID ==_noteID && x.UserID==_UserID)
            NoteEntity noteEntity = _fundoonoteContext1.Notes.FirstOrDefault(x => x.UserID == _UserID);
            if (noteEntity != null)
            {
                noteEntity.Title = noteModel.title;
                noteEntity.Color = noteModel.color;
                noteEntity.IsArchived = noteModel.IsArchived;
                noteEntity.IsDeleted = noteModel.IsDeleted;
                noteEntity.NoteId = noteModel.noteID;
                //noteEntity.UserID = noteModel.UserID;

                _fundoonoteContext1.Notes.Add(noteEntity);
                _fundoonoteContext1.SaveChanges(true);

                return noteEntity;
            }
            else
            {
                return null;
            }*/
            // return null;
           // return noteEntity;
        //}

       
    }
}
