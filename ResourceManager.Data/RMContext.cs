using System;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Entity;

namespace ResourceManager.Data
{
    public class RMContext : DbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<RType> RType { get; set; }
        public DbSet<Resource> Resource { get; set; }
        public DbSet<GridViewResource> GridViewResource { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<GridViewUserRequest> GridViewUserRequest { get; set; }
        public DbSet<GridViewAdminRequest> GridViewAdminRequest { get; set; }
        public DbSet<CalculateResource> calculateResource { get; set; }
        public DbSet<ResourcebyType> ResourcebyTypes { get; set; }

        public RMContext(DbContextOptions<RMContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
