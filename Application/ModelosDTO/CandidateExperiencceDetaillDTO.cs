using Domain.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelosDTO
{
    public class CandidateExperiencceDetaillDTO
    {
        public CandidateDTO Candidate { get; set; }
        public ICollection<CandidateExperienceDTO> CandidateExperience { get; set; }
    }
}
