using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kald_IntsiHaldur.Models
{
    public class Incident
    {
        //Pöördumist kirjeldavad muutujad
        public Guid Id { get; set; }

        [Display(Name ="Kirjeldus")]
        public string? Description { get; set; }

        [Display(Name = "Lisatud")]
        public DateTime DateTimeCreated { get; set; }

        [Display(Name = "Tähtaeg")]
        public DateTime DateTimeDeadline { get; set; }
    }
}
