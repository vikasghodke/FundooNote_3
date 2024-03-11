using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Entity
{
    public class ResetPasswordEntity
    {
        public string Email { get; set; }

        public string Passwrod { get; set; }
        public string confirm_Password {  get; set; }

    }
}
