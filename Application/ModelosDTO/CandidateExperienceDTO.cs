using Domain.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ModelosDTO
{
    public  class CandidateExperienceDTO
    {
        
        public int IdCandidateExperience { get; set; }  

        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime ModifyDate { get; set; }

         
        public int FkIdCandidate { get; set; }  
     

    }
}
