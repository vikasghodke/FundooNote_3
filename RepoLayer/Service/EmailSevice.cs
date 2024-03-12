using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Service
{
    public class EmailSevice: IEmailService
    {
        private readonly FundoonoteContext1 _fundoonoteContext1;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailSevice(string smtpServer, int smtpPort,FundoonoteContext1 fundoonoteContext1)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _fundoonoteContext1 = fundoonoteContext1;
        }
        public string ForgetPass(string recepetEmail, string resetLink)
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Email = recepetEmail;
            resetLink = "TokenrecetLinkUse";

            return userEntity.Email;
        }
    }
}
