using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Context
{
    public class FundoonoteContext1 :DbContext
    {
        public FundoonoteContext1(DbContextOptions options): base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
