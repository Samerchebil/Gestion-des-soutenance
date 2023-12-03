using System.ComponentModel.DataAnnotations;

namespace ProjectFInalExam.Models
{
    public class Societe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le Lib est Obligatoire")]
        public string Lib { get; set; }
        public string Adresse { get; set; }
        public string Tel { get; set; }
        public virtual ICollection<PFE>? PFES { get; set; }

    }
}
