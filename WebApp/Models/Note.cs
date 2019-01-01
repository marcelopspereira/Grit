using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Note
    {
        [Key]
        public int NoteID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [ForeignKey("Client")]
        public int CID { get; set; }
        public virtual Client Client { get; set; }
    }
}
