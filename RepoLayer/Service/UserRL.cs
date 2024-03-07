using Microsoft.AspNetCore.Identity;
using ModelLayer;
using Newtonsoft.Json.Linq;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace RepoLayer.Service
{
    public class UserRL : IUserRL
    {

        private readonly FundoonoteContext1 _fundoonoteContext1;

        public UserRL(FundoonoteContext1 _fundoonoteContext1)
        {
            this._fundoonoteContext1 = _fundoonoteContext1;
        }

        public UserEntity AddUserDetail(UserModel userModel)
        {
            UserEntity entity = new UserEntity();
            entity.FirstName = userModel.FirstName;
            entity.LastName = userModel.LastName;
            entity.Email = userModel.Email;
            entity.Password = userModel.Password;

            _fundoonoteContext1.Users.Add(entity);
            _fundoonoteContext1.SaveChanges();

            return entity;
        }
        public UserEntity ViewDetail(string Email, string Password)
        {
            return _fundoonoteContext1.Users.FirstOrDefault(e => e.Email == Email && e.Password == Password);
        }

        }

    }


