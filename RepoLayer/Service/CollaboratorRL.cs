using ModelLayer;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepoLayer.Service
{
    public class CollaboratorRL : ICollaboratorRL
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;

        public CollaboratorRL(FundoonoteContext1 _fundoonoteContext1)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
        }
        public CollaboratorModel AddCollab(CollaboratorModel collaboratorModel, int _userID)
        {
            var result = _fundoonoteContext1.Notes.FirstOrDefault(e => e.UserID == _userID);
            CollaboratorEntity entity = new CollaboratorEntity();
            entity.UserID = _userID;
            entity.NoteId = result.NoteId;
            entity.CollaboratorEmail = collaboratorModel.CollaboratorEmail;

            _fundoonoteContext1.Collab.Add(entity);
            _fundoonoteContext1.SaveChanges();
            return collaboratorModel;
        }
        public List<string> ViewCollab(int _userID, int _noteID)
        {
            var notes = _fundoonoteContext1.Notes.FirstOrDefault(e => e.UserID == _userID && e.NoteId == _noteID);
            if (notes != null)
            {
                var collab = _fundoonoteContext1.Collab.Where(e => e.UserID == _userID && e.NoteId == _noteID).Select(e => e.CollaboratorEmail).ToList();
                return collab;
            }
            return null;

        }
        public bool RemoveCollab(string email, int _userID, int _noteID)
        {
            var check = _fundoonoteContext1.Notes.FirstOrDefault(e => e.UserID == _userID && e.NoteId == _noteID);
            if (check != null)
            {
                CollaboratorEntity collaboratorEntity = _fundoonoteContext1.Collab.FirstOrDefault(e => e.UserID == _userID && e.NoteId == _noteID && e.CollaboratorEmail == email);
                _fundoonoteContext1.Collab.Remove(collaboratorEntity);
                _fundoonoteContext1.SaveChanges();
            }
            return false;
        }

    }
}

