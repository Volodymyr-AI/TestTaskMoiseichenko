using ChatDAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChatDAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChat> UserChats { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ChatOnModelCreating(builder);
            UserOnModelCreating(builder);
            MessageOnModelCreating(builder);
            UserChatOnModelCreating(builder);

            base.OnModelCreating(builder);
        }

        //Fluent API
        private void ChatOnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Chat>()
                   .HasKey(x => x.Id);

            builder.Entity<Chat>()
                   .Property(x => x.Name)
                   .IsRequired();
        }

        private void UserOnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                   .HasKey(x => x.Id);

            builder.Entity<User>()
                   .Property(x => x.UserName)
                   .IsRequired();

            builder.Entity<User>()
                   .Property(x => x.Email)
                   .IsRequired();
        }

        private void MessageOnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>()
                   .HasKey(x => x.Id);

            builder.Entity<Message>()
                   .Property(x => x.Text)
                   .IsRequired();

            builder.Entity<Message>()
                   .Property(x => x.SenderId)
                   .IsRequired();

            builder.Entity<Message>()
                   .HasOne(c => c.Sender)
                   .WithMany()
                   .HasForeignKey(x => x.SenderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                   .Property(x => x.OwnerId)
                   .IsRequired();

            builder.Entity<Message>()
                   .HasOne(c => c.Owner)
                   .WithMany()
                   .HasForeignKey(x => x.OwnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Message>()
                    
                   .Property(x => x.OwnerId)
                   .IsRequired();

            builder.Entity<Message>()
                   .HasOne(c => c.Receiver)
                   .WithMany()
                   .HasForeignKey(x => x.ReceiverId)
                   .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Message>()
                   .Property(x => x.SendTime)
                   .IsRequired();

            builder.Entity<Message>()
                   .Property(x => x.IsEdited)
                   .HasDefaultValue(false);

            builder.Entity<Message>()
                   .Property(x => x.IsDeletedForMe)
                   .HasDefaultValue(false);


        }

        private void UserChatOnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserChat>()
                   .HasKey(x => x.Id);

            builder.Entity<UserChat>()
                   .Property(x => x.UserId)
                   .IsRequired();

            builder.Entity<UserChat>()
                   .Property(x => x.ChatId)
                   .IsRequired();
        }
    }
}
