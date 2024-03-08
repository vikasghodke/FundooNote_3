using ModelLayer;
using RepoLayer.Entity;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBL
    {
        public CollaboratorModel AddCollab(CollaboratorModel collaboratorModel,int _userID);
        public List<CollaboratorEntity> ViewCollab(int _userID, int _noteID);
    }
}
