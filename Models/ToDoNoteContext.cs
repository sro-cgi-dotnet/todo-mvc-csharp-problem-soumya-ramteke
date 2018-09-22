using System;
using Microsoft.EntityFrameworkCore;

namespace todo_mvc_csharp_problem_soumya_ramteke.Models{
    public class ToDoNoteContext : DbContext{
        public DbSet<Note> Notes {get; set;}
        public DbSet<CheckListItem> CheckLists {get; set;}
        public DbSet<Label> Labels { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ToDoNotes_2;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Note>().HasMany(n => n.CheckList).WithOne().HasForeignKey(c => c.NoteId);
            modelBuilder.Entity<Note>().HasMany(n => n.Labels).WithOne().HasForeignKey(c => c.NoteId);
        }    
    }
}