using Microsoft.Extensions.Caching.Distributed;
using ModelLayer;
using RabbitMQ.Client;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace RepoLayer.Service
{
    public class NoteRL : INoteRL
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;
        private readonly IDistributedCache _distributedCache1;
        private readonly ConnectionFactory _connectionFactory;

        public NoteRL(FundoonoteContext1 _fundoonoteContext1, IDistributedCache distributedCache1)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
            this._distributedCache1 = distributedCache1;
            
        }

        // public NoteEntity AddNote(NoteModel noteModel,int _userID)
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

            _distributedCache1.SetString(Convert.ToString(note.NoteId), JsonSerializer.Serialize(note));


            //
            return note;


        }
        public NoteEntity EditNote1(EditNote editnote,int _noteID)
        {
            var CatchNoteJson = _distributedCache1.GetString("_noteId");
            if(!string.IsNullOrEmpty(CatchNoteJson))
            {
                var CatchNote=JsonSerializer.Deserialize<NoteEntity>(CatchNoteJson);
                CatchNote.Title = editnote.title;
                _distributedCache1.SetString(Convert.ToString(_noteID), JsonSerializer.Serialize(CatchNote));
                return CatchNote;
            }
            NoteEntity note = _fundoonoteContext1.Notes.FirstOrDefault(x => x.NoteId == _noteID);
            if(note!=null)
            {
                note.Title = editnote.title;
                _fundoonoteContext1.SaveChanges(true);

                _distributedCache1.SetString(Convert.ToString(_noteID), JsonSerializer.Serialize(note));
                return note;
            }
            else
            {
                return null;
            }
        }
        public NoteEntity DeleteNote(int _noteID, int _userID)
        {
            var CatchedNote=_distributedCache1.GetString(Convert.ToString(_noteID));
            NoteEntity note = _fundoonoteContext1.Notes.FirstOrDefault(e => e.UserID == _userID && e.NoteId == _noteID);

            if (!string.IsNullOrEmpty(CatchedNote))
            {
                _distributedCache1.Remove(Convert.ToString(_userID));
            }
           

            if (note != null)
            {
                _fundoonoteContext1.Notes.Remove(note);
                _fundoonoteContext1.SaveChanges();
            }
            return note;

           
        }
        public NoteEntity ViewNote(int _noteID, int _userID)
        {
            var cachedUserNotes = _distributedCache1.GetString(Convert.ToString(_noteID));

            if (!string.IsNullOrEmpty(cachedUserNotes))
            {
                var cachedNotes = JsonSerializer.Deserialize<NoteEntity>(cachedUserNotes);
                return cachedNotes;

            }
            else
            {
                NoteEntity note = _fundoonoteContext1.Notes.FirstOrDefault(x => x.NoteId == _noteID && x.UserID == _userID);

                if (note != null)
                {
                    
                    _distributedCache1.SetString(Convert.ToString(note.NoteId), JsonSerializer.Serialize(note));
                    return note;

                }
            }
               
             return null;
        } 

        public bool Archive_UnArchive(int _userId, long _noteId)
        {
            NoteEntity noteEntity=_fundoonoteContext1.Notes.FirstOrDefault(e=>e.UserID == _userId && e.NoteId== _noteId);
            if(noteEntity != null)
            {
                if(noteEntity.IsArchived!=true)
                {
                    noteEntity.IsArchived = false;
                }
                else
                {
                    noteEntity.IsArchived = true;
                }
                _fundoonoteContext1.SaveChanges();
                return true;
            }
            
            return true;
        }       
       
    }
}
