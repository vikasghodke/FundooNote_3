using ModelLayer;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface ICollaboratorRL
    {
        public CollaboratorModel AddCollab(CollaboratorModel collaboratorModel, int _userID);

        public List<string> ViewCollab(int _userID, int _noteID);

        public bool RemoveCollab(string email, int _userID, int _noteID);
    }
}
