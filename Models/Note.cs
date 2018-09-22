using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace todo_mvc_csharp_problem_soumya_ramteke.Models {
    public class Note{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? NoteId {get; set;}
        [Required]
        public string Title {get; set;}
        public string PlainText {get; set;}
        public bool IsPinned { get; set; }
        public List<CheckListItem> CheckList {get; set;}
        public List<Label> Labels { get; set; }
        
    }


   public class CheckListItem {
        public int Id {get; set;}
        public bool IsChecked {get; set;}
        public string Text {get; set;}
        public int NoteId{get; set;}

    }

        public class Label{
        public int Id {get; set;}
        [Required]
        public string Name { get; set; }
        public int NoteId { get; set; } 
    }
}

