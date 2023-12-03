using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFInalExam.Models
{
    public class Enseignant
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom De Le Enseignant")]
        public string Nom { get; set; }

        [Required]
        [Display(Name = "Prenom De Le Enseignant")]
        public string Prenom { get; set; }

        public virtual ICollection<PFE>? EncadrantPFES { get; set; }

        [InverseProperty("President")]
        public virtual ICollection<Soutenance>? SoutenancesAsPresident { get; set; }

        [InverseProperty("Rapporteur")]
        public virtual ICollection<Soutenance>? SoutenancesAsRapporteur { get; set; }

    }
}
