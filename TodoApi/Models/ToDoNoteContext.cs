using System;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models{
    public class ToDoNoteContext : DbContext{
        public DbSet<Note> Notes {get; set;}
        public DbSet<CheckListItem> CheckLists {get; set;}
        public DbSet<Label> Labels { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ToDoNotes_3;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Note>().HasMany(n => n.CheckList).WithOne().HasForeignKey(c => c.NoteId);
            modelBuilder.Entity<Note>().HasMany(n => n.Labels).WithOne().HasForeignKey(c => c.NoteId);
        }    
    }
}