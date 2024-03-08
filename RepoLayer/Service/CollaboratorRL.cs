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
        public List<CollaboratorEntity> ViewCollab( int _userID, int _noteID)
        {
           // var result = _fundoonoteContext1.Notes.FirstOrDefault(e => e.UserID == _userID);
            //var result1 = _fundoonoteContext1.Collab.FirstOrDefault(e => e.CollaboratorEmail);
            var res=_fundoonoteContext1.Collab.Where(e => e.NoteId == _noteID && e.UserID == _userID).ToList();
            if(res.Count > 0)
            {
                return res;
            }

            return null;
            
        }
         
        // return null;
    }
}

