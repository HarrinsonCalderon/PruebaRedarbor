using Application.ModelosDTO;
using Domain.Modelos;
using Domain.ModelosDTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Utilidades
{
    public static class Mapear
    {
        public static CandidateDTO MapearCandidateACandidateDTO(this Candidate P)
        {
            return new CandidateDTO
            {
                IdCandidate = P.IdCandidate,
                Name = P.Name,
                Surname = P.Surname,
                Birthdate = P.Birthdate,
                Email=P.Email,
                InsertDate=P.InsertDate,
                ModifyDate = P.ModifyDate

            };
        }

        public static CandidateExperienceDTO MapearCandidateExperienceACandidateExperienceDTO(this CandidateExperience P)
        {
            return new CandidateExperienceDTO
            {
                IdCandidateExperience = P.IdCandidateExperience,
                Company = P.Company,
                Job = P.Job,
                Description = P.Description,
                Salary = P.Salary,
                BeginDate = P.BeginDate,
                EndDate = P.EndDate,
                InsertDate = P.InsertDate,
                ModifyDate = P.ModifyDate,
                FkIdCandidate = P.FkIdCandidate

            };
        }
        public static CandidateExperiencceDetaill MapearCandidateExperiencceDetaillDTO(this CandidateExperiencceDetaillDTO P)
        {
            CandidateExperiencceDetaill _candidateExperiencceDetaill = new CandidateExperiencceDetaill();

            _candidateExperiencceDetaill.Candidate = new Candidate();
            _candidateExperiencceDetaill.CandidateExperience=new Collection<CandidateExperience>();

            _candidateExperiencceDetaill.Candidate.IdCandidate = P.Candidate.IdCandidate;
            _candidateExperiencceDetaill.Candidate.Name = P.Candidate.Name;
            _candidateExperiencceDetaill.Candidate.Surname = P.Candidate.Surname;
            _candidateExperiencceDetaill.Candidate.Birthdate = P.Candidate.Birthdate;
            _candidateExperiencceDetaill.Candidate.Email = P.Candidate.Email;
            _candidateExperiencceDetaill.Candidate.InsertDate = P.Candidate.InsertDate;
            _candidateExperiencceDetaill.Candidate.ModifyDate = P.Candidate.ModifyDate;

            var _candidateExperience = new CandidateExperience();
            
                foreach (var it in P.CandidateExperience)
                {

                    _candidateExperience.IdCandidateExperience = it.IdCandidateExperience;
                    _candidateExperience.Company = it.Company;
                    _candidateExperience.Job = it.Job;
                    _candidateExperience.Description = it.Description;
                    _candidateExperience.Salary = it.Salary;
                    _candidateExperience.BeginDate = it.BeginDate;
                    _candidateExperience.EndDate = it.EndDate;
                    _candidateExperience.InsertDate = it.InsertDate;
                    _candidateExperience.ModifyDate = it.ModifyDate;
                    _candidateExperience.FkIdCandidate = it.FkIdCandidate;

                    _candidateExperiencceDetaill.CandidateExperience.Add(_candidateExperience);

                }
           

            return _candidateExperiencceDetaill;
        }

    }
}
