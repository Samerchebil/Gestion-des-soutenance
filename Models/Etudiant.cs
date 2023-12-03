using System.ComponentModel.DataAnnotations;

namespace ProjectFInalExam.Models
{
    public class Etudiant
    {
            public int Id { get; set; }
            [Required(ErrorMessage = "Le Nom Obligatoire")]
            [StringLength(30, MinimumLength = 3)]
            public string Nom { get; set; }
            [Required(ErrorMessage = "Le Prénom Obligatoire")]
            [StringLength(30, MinimumLength = 3)]
            public string Prenom { get; set; }
            [Display(Name = "Date De Naissance")]
            public DateTime DateN { get; set; }
            public virtual ICollection<PFE_ETUDIANT>? PFE_ETUDIANTS { get; set; }



    }

}
