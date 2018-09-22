using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.SQLite
{
    public class MailContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<InboxMail> InboxMail { get; set; }
        public DbSet<OutboxMail> OutboxMail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mail.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasMany(typeof(InboxMail), "Inbox").WithOne();
            modelBuilder.Entity<Person>().HasMany(typeof(OutboxMail), "Outbox").WithOne();
        }
    }

    public enum InboxStatus{
        Receied,
        Decripted
    }

    public enum OutboxStatus{
        Receied,
        Decripted
    }

    public class Mail
    {
        public string Id { get; set; }
        public string PersonId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
    }

    public class OutboxMail:Mail
    {
        public OutboxStatus Status { get;set;}
    }

    public class InboxMail:Mail
    {
        public InboxStatus Status { get;set;}
    }

    public class Person
    {
        public string PersonId { get; set; }
        public string Email { get; set; }

        public List<InboxMail> Inbox { get; set; }
        public List<OutboxMail> Outbox { get; set; }
        public string Sent { get; set; }
    }
}