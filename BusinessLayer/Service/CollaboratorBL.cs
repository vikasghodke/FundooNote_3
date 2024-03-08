using BusinessLayer.Interface;
using ModelLayer;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class CollaboratorBL : ICollaboratorBL
    {
        public readonly ICollaboratorRL collaboratorRL;
        public CollaboratorBL(ICollaboratorRL collaboratorRL)
        {
            this.collaboratorRL = collaboratorRL;
        }
        public CollaboratorModel AddCollab(CollaboratorModel collaboratorModel, int _userID)
        {
            return collaboratorRL.AddCollab(collaboratorModel, _userID);   
        }
        public List<CollaboratorEntity> ViewCollab(int _userID,int _noteID)
        {
            return collaboratorRL.ViewCollab( _userID, _noteID);
        }
        
    }
}
