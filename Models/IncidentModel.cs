namespace Kald_IntsiHaldur.Models
{
    public class IncidentModel
    {
        //Pöördumist kirjeldavad muutujad
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DateTimeCreated { get; set; }
        public string DateTimeDeadline { get; set; }

        public IncidentModel(string description, string deadline) 
        { 
            Id = Guid.NewGuid();
            Description = description;
            DateTimeCreated = DateTime.Now.ToString("DD.MM.YYYY HH.mm.ss");
            DateTimeDeadline = deadline;            
        }

    }
}
