using Domain.Modelos;
using Domain.ModelosDTO;

namespace Application.Interfaces
{
    public interface ICandidateService
    {
        public IEnumerable<Candidate> GetCandidate();

        public List<CandidateExperienceDetail> GetCandidate(int Id);

        IEnumerable<CandidateExperience> GetCandidateExperience();

        List<CandidateExperienceDetail> GetCandidateExperienceDetail();

        string PostCandidateExperience(CandidateExperiencceDetaill candidate);

        string PutCandidateExperience(CandidateExperiencceDetaill candidate);

        string DeleteCandidateExperience(string Id);


    }

}
