using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modelos
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperience> CandidateExperience { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().ToTable("Candidate");
            modelBuilder.Entity<CandidateExperience>().ToTable("CandidateExperience");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
