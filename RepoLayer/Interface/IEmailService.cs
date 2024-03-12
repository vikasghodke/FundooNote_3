using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface IEmailService
    {
        public void SendResetPasswordEmail(string recepetEmail, string resetLink);
    }
}
