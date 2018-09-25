
using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using TodoApi.Models;
using TodoApi.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TodoTests
{
    public class TodoTests
    {
        [Fact]
         private List<Note> GetMockDatabase(){
            return new List<Note>{
                new Note{
                    NoteId = 1,
                    Title = "Things to do",
                    CheckList = new List<CheckListItem>{
                        new CheckListItem{
                            Id = 1,
                            Text = "buy utensils",
                            NoteId = 1
                        }
                    },
                    Labels = new List<Label>{
                        new Label{
                            Id = 1,
                            Name = "essentials"
                        }
                    }
                },
                new Note{
                    NoteId = 2,
                    Title = "visit",
                    CheckList = new List<CheckListItem>{
                        new CheckListItem{
                            Id = 2,
                            Text = "coorg",
                            NoteId = 2
                        }
                    },
                    Labels = new List<Label>{
                        new Label{
                            Id = 2,
                            Name = "must visit"
                        }
                    }
                }
            };
        }
        [Fact]
        public void GetAll_Negative_DatabaseError()
        {
            var datarepo = new Mock<INoteRepository>();
            List<Note> notes = null;
            datarepo.Setup(d => d.RetrieveAllNotes()).Returns(notes);
            TodoController todoController = new TodoController(datarepo.Object);
            var result = todoController.Get();
            Assert.IsType<NotFoundObjectResult>(result);
        }

        public void RetrieveNote_Id1_Positive()
        {
            var noterepo = new Mock<INoteRepository>();
            List<Note> notes = GetMockDatabase();
            int id = 1;
            noterepo.Setup(d => d.RetrieveNote(id)).Returns(notes.Find(n => n.NoteId == id));
            TodoController todoController = new TodoController(noterepo.Object);
            var result = todoController.Get(id);
            Assert.NotNull(result);
            Assert.Equal(id, result.Value.NoteId);
        }

        
    }
}
