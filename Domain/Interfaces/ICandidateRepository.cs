using Domain.Modelos;
using Domain.ModelosDTO;


namespace Domain.Interfaces
{
    public interface ICandidateRepository
    {
        IEnumerable<Candidate> GetCandidate();

        List<CandidateExperienceDetail> GetCandidate(int Id);


        IEnumerable<CandidateExperience> GetCandidateExperience();

        List<CandidateExperienceDetail> GetCandidateExperienceDetail();

        string PostCandidateExperience (CandidateExperiencceDetaill candidate);

        string PutCandidateExperience(CandidateExperiencceDetaill candidate);


        string DeleteCandidateExperience(string Id);

    }
}
