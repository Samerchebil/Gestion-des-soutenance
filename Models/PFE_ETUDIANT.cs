namespace ProjectFInalExam.Models
{
    public class PFE_ETUDIANT
    {
        public int Id { get; set; }
        public int PFEID { get; set; }
        public int EtudiantId { get; set; }

        public virtual PFE? PFE { get; set; }
        public virtual Etudiant? Etudiant { get; set; }
    }
}
