using Application.Interfaces;
using Data.Repositorio;
using Domain.Interfaces;
using Domain.Modelos;
using Domain.ModelosDTO;

namespace Application.Services
{
    public class CandidateService : ICandidateService
    {
         private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        //public CandidateService()
        //{
        //    _candidateRepository = new CandidateRepository();
        //}

        public IEnumerable<Candidate> GetCandidate()
        {
            return _candidateRepository.GetCandidate();
        }

        public List<CandidateExperienceDetail> GetCandidate(int Id)
        {
            return _candidateRepository.GetCandidate(Id);
        }

        public IEnumerable<CandidateExperience> GetCandidateExperience()
        {
            return _candidateRepository.GetCandidateExperience();
        }

        

        public List<CandidateExperienceDetail> GetCandidateExperienceDetail()
        {
            return _candidateRepository.GetCandidateExperienceDetail();
        }

        public string PostCandidateExperience(CandidateExperiencceDetaill candidate)
        {
           return _candidateRepository.PostCandidateExperience(candidate);
        }

        public string PutCandidateExperience(CandidateExperiencceDetaill candidate)
        {
            return _candidateRepository.PutCandidateExperience(candidate);

        }

        public string DeleteCandidateExperience(string Id)
        {
            return _candidateRepository.DeleteCandidateExperience(Id);
        }

    }
}
