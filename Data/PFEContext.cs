using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectFInalExam.Models;

namespace ProjectFInalExam.Data
{
    public class PFEContext : DbContext
    {
        public PFEContext (DbContextOptions<PFEContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectFInalExam.Models.Enseignant> Enseignant { get; set; } = default!;
        public DbSet<ProjectFInalExam.Models.Etudiant> Etudiants { get; set; } = default!;
        public DbSet<ProjectFInalExam.Models.PFE> PFE { get; set; } = default!;
        public DbSet<ProjectFInalExam.Models.PFE_ETUDIANT> PFE_ETUDIANT { get; set; } = default!;
        public DbSet<ProjectFInalExam.Models.Societe> Societe { get; set; } = default!;
        public DbSet<ProjectFInalExam.Models.Soutenance> Soutenance { get; set; } = default!;


    }
}
