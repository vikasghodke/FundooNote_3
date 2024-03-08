using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;

namespace RepoLayer.Context
{
    public class FundoonoteContext1 : DbContext
    {
        public FundoonoteContext1(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<CollaboratorEntity> Collab { get; set; }
    }
}
