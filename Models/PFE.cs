using System.ComponentModel.DataAnnotations;

namespace ProjectFInalExam.Models
{
    public class PFE
    {

        public int Id { get; set; }
        [StringLength(30, MinimumLength = 3)]
        [Required(ErrorMessage = "Le Titre est Obligatoire")]
        public string Titre { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date De Debut")]
        public DateTime DateDebut { get; set;
        }
        [Display(Name = "Date De Fin")]
        public DateTime DateFin { get; set; }

        [Display(Name = "Encadrant")]
        public int EncadrantID { get; set; }

        [Display(Name = "Societe")]
        public int SocieteID { get; set; }

        // Navigation properties
        public virtual Enseignant? Encadrant { get; set; }
        public virtual Societe? Societe { get; set; }
        public virtual ICollection<PFE_ETUDIANT>? PFE_ETUDIANTS { get; set; }
        public virtual  ICollection<Soutenance>? Soutenances { get; set; }
    }
}
