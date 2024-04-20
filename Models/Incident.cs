using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kald_IntsiHaldur.Models
{
    public class Incident
    {
        //private Guid guid;
        //private DateTime now;
        //private DateTime deadLine;

        //public Incident(Guid guid, DateTime now, string description, DateTime deadLine)
        //{
        //    this.guid = guid;
        //    this.now = now;
        //    Description = description;
        //    this.deadLine = deadLine;
        //}

        //Pöördumist kirjeldavad muutujad
        public Guid Id { get; set; }

        [Display(Name ="Kirjeldus")]
        public string? Description { get; set; }

        [Display(Name = "Lisatud")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeCreated { get; set; }

        [Display(Name = "Tähtaeg")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeDeadline { get; set; }

        //public Incident(string description, string deadline) 
        //{ 
        //    Id = Guid.NewGuid();
        //    Description = description;
        //    DateTimeCreated = DateTime.Now.ToString("DD.MM.YYYY HH.mm.ss");
        //    DateTimeDeadline = deadline;            
        //}

    }
}
