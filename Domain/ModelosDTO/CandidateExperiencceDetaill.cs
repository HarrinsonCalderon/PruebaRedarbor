using Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelosDTO
{
    public class CandidateExperiencceDetaill
    {
        public Candidate Candidate { get; set; }
        public ICollection<CandidateExperience> CandidateExperience { get; set; }
    }
}
