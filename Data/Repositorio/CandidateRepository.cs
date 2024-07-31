using Domain.Interfaces;
using Domain.Modelos;
using Domain.ModelosDTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Repositorio
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationContext _applicationContext;

        public CandidateRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IEnumerable<Candidate> GetCandidate()
        {
            return  _applicationContext.Candidates.ToList();

        }

        //public IEnumerable<CandidateExperiencceDetaill> GetCandidate(int Id)
        //{
        //     return _applicationContext.Candidates
        //        .Include(c => c.CandidateExperiences) // Incluye las experiencias
        //        .Select(c => new CandidateExperienceDetail
        //        {
        //            Candidate = c,
        //            CandidateExperience = c.CandidateExperiences
        //        })
        //        .ToList(); // Ejecuta la consulta y convierte el resultado en una lista
        //}


        public List<CandidateExperienceDetail> GetCandidate(int Id)
        {
            var candidateDetails = _applicationContext.Candidates
                .Include(c => c.CandidateExperiences) // Incluye las experiencias
                .Where(c => c.IdCandidate == Id) // Filtra por el ID del candidato

                .Select(c => new CandidateExperienceDetail
                {
                    Candidate = c,
                    CandidateExperience = c.CandidateExperiences
                }) 
                .ToList(); // Ejecuta la consulta y convierte el resultado en una lista

            return candidateDetails; // Devuelve la lista
        }


        public IEnumerable<CandidateExperience> GetCandidateExperience()
        {
            return _applicationContext.CandidateExperience.ToList();

        }
       

       

        public List<CandidateExperienceDetail> GetCandidateExperienceDetail()
        {
            var candidateDetails = _applicationContext.Candidates
                .Include(c => c.CandidateExperiences) // Incluye las experiencias
                .Select(c => new CandidateExperienceDetail
                {
                    Candidate = c,
                    CandidateExperience = c.CandidateExperiences
                })
                .ToList(); // Ejecuta la consulta y convierte el resultado en una lista

            return candidateDetails; // Devuelve la lista
        }

        public string  PostCandidateExperience(CandidateExperiencceDetaill candidate)
         {
            string rta = "";
            try
            {
                _applicationContext.Candidates.Add(candidate.Candidate);
                _applicationContext.SaveChanges();
                var Id = _applicationContext.Candidates
                     .Max(c => c.IdCandidate);
                _applicationContext.SaveChanges();

                AgregarExperiencia(candidate.CandidateExperience,Id);

                rta = "1";
            }
            catch (Exception ea)
            {

                rta = "0";
            }
            return rta;
        }

       public void AgregarExperiencia(ICollection<CandidateExperience> lista, int Id)
        {

            var candidateExperiences = new List<CandidateExperience>();

            foreach (var item in lista)
            {
                var aux = new CandidateExperience();
                aux.Company = item.Company;
                aux.Job = item.Job;
                aux.Description = item.Description;
                aux.Salary = item.Salary;
                aux.BeginDate = item.BeginDate;
                aux.EndDate = item.EndDate;
                aux.InsertDate = item.InsertDate;
                aux.ModifyDate = item.ModifyDate;
                aux.FkIdCandidate = Id;

                candidateExperiences.Add(aux);
            }

                

            foreach (var it in candidateExperiences)
            {

                //it.FkIdCandidate = Id;
                _applicationContext.CandidateExperience.Add(it);

            }

            _applicationContext.SaveChanges();
        }

        public string PutCandidateExperience(CandidateExperiencceDetaill candidate)
        {

            try { 
            
            
           
            var _candidate = new Candidate();
            _candidate = _applicationContext.Candidates.Find(candidate.Candidate.IdCandidate);
            _candidate.Name = candidate.Candidate.Name;
            _candidate.Surname = candidate.Candidate.Surname;
            _candidate.Birthdate = candidate.Candidate.Birthdate;
            _candidate.Email = candidate.Candidate.Email;
            _candidate.InsertDate = candidate.Candidate.InsertDate;
            _candidate.ModifyDate = candidate.Candidate.ModifyDate;

            _applicationContext.Candidates.Update(_candidate);
            _applicationContext.SaveChanges();

            var Id = candidate.Candidate.IdCandidate;
            PutExperiencia(candidate.CandidateExperience, Id);

            return "1";

            }
            catch (Exception ea)
            {
                return "0";
            }
        }

        public void PutExperiencia(ICollection<CandidateExperience> lista, int Id)
        {

            var candidateExperiences = new List<CandidateExperience>();

            foreach (var item in lista)
            {
                var aux=_applicationContext.CandidateExperience.Find(item.IdCandidateExperience);
      
                aux.Company = item.Company;
                aux.Job = item.Job;
                aux.Description = item.Description;
                aux.Salary = item.Salary;
                aux.BeginDate = item.BeginDate;
                aux.EndDate = item.EndDate;
                aux.InsertDate = item.InsertDate;
                aux.ModifyDate = item.ModifyDate;
             

                candidateExperiences.Add(aux);
            }



            foreach (var it in candidateExperiences)
            {

                 _applicationContext.CandidateExperience.Update(it);

            }

            _applicationContext.SaveChanges();
        }



        public string DeleteCandidateExperience(string _Id)
        {
            try
            {

                var _candidate = new Candidate();
                _candidate = _applicationContext.Candidates.Find((int.Parse(_Id)));





                var Id = _candidate.IdCandidate;
                DeleteExperiencia(Id);

                _applicationContext.Candidates.Remove(_candidate);
                _applicationContext.SaveChanges();

                return "1";

            }
            catch (Exception ea)
            {
                return "0";
            }
        }

        public void DeleteExperiencia( int Id)
        {

            var candidateExperiences = new List<CandidateExperience>();

            var Experience=_applicationContext.CandidateExperience.Where(c=>c.FkIdCandidate==Id).ToList();   

            foreach (var item in Experience)
            {
                var aux = _applicationContext.CandidateExperience.Find(item.IdCandidateExperience);

                candidateExperiences.Add(aux);
            }



            foreach (var it in candidateExperiences)
            {

            
                _applicationContext.CandidateExperience.Remove(it);

            }

            _applicationContext.SaveChanges();
        }


    }
}
