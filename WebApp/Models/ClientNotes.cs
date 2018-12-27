using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ClientNotes
    {
        [Key]
        public int ClientNoteID { get; set; }
        [Display(Name = "Notes:")]
        public string NoteDescription { get; set; }
    }
}
