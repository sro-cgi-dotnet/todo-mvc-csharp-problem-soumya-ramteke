﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using todo_mvc_csharp_problem_soumya_ramteke.Models;

namespace todomvccsharpproblemsoumyaramteke.Migrations
{
    [DbContext(typeof(ToDoNoteContext))]
    [Migration("20180922073825_databse1")]
    partial class databse1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("todo_mvc_csharp_problem_soumya_ramteke.Models.CheckListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsChecked");

                    b.Property<int>("NoteId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("CheckLists");
                });

            modelBuilder.Entity("todo_mvc_csharp_problem_soumya_ramteke.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("NoteId");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("todo_mvc_csharp_problem_soumya_ramteke.Models.Note", b =>
                {
                    b.Property<int?>("NoteId");

                    b.Property<bool>("IsPinned");

                    b.Property<string>("PlainText");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("todo_mvc_csharp_problem_soumya_ramteke.Models.CheckListItem", b =>
                {
                    b.HasOne("todo_mvc_csharp_problem_soumya_ramteke.Models.Note")
                        .WithMany("CheckList")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("todo_mvc_csharp_problem_soumya_ramteke.Models.Label", b =>
                {
                    b.HasOne("todo_mvc_csharp_problem_soumya_ramteke.Models.Note")
                        .WithMany("Labels")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
