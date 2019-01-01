using System;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class ClientVM
    {
        public Client ClientID { get; set; }
        [Display(Name = "Business")]
        public Client BusinessName { get; set; }
        public Client Email { get; set; }
        public Client Phone { get; set; }
        [Display(Name = "First Name")]
        public Client FirstName { get; set; }
        [Display(Name = "Last Name")]
        public Client LastName { get; set; }

        [Display(Name = "Business ID")]
        public Client DisplayName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get { return (FirstName + " " + LastName); }
        }

        public Note NoteID { get; set; }
        public Note Title { get; set; }
        public Note Content { get; set; }
    }
}
