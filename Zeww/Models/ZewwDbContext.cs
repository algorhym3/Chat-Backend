using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Zeww.Models
{
    public class ZewwDbContext : DbContext {

        public ZewwDbContext(DbContextOptions<ZewwDbContext> options)
            : base(options) { }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<UserWorkspace> UserWorkspaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserWorkspace>()
                .HasKey(uw => new { uw.WorkspaceId, uw.UserId });

            //modelBuilder.Entity<UserWorkspace>()
            //    .HasOne(uw => uw.Workspace)
            //    .WithMany(u => u.UserWorkspaces)
            //    .HasForeignKey(uw => uw.WorkspaceId);

            //modelBuilder.Entity<UserWorkspace>()
            //    .HasOne(uw => uw.User)
            //    .WithMany(w => w.UserWorkspaces)
            //    .HasForeignKey(uw => uw.UserId);

            modelBuilder.Entity<UserChats>()
                .HasKey(uw => new { uw.ChatId, uw.UserId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/Zeww")
            .AddJsonFile("appsettings.json")
            .Build();
            string connection = Configuration.GetConnectionString("ZewwDatabase");
            optionsBuilder.UseSqlServer(connection);
        }

    }
}