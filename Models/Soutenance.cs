using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectFInalExam.Models
{
    public class Soutenance
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Heure { get; set; }
        [Display(Name = "Titre Du PFE")]
        public int? PFEID { get; set; }
        [Display(Name = "President")]
        public int? PresidentId { get; set; }
        [Display(Name = "Rapporteur")]
        public int? RapporteurID { get; set; }

        public virtual PFE? PFE { get; set; }

        [ForeignKey("PresidentId")]
        [InverseProperty("SoutenancesAsPresident")]
        public virtual Enseignant? President { get; set; }

        [ForeignKey("RapporteurID")]
        [InverseProperty("SoutenancesAsRapporteur")]
        public virtual Enseignant? Rapporteur { get; set; }
    }
}
