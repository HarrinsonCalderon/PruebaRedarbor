using Application.Interfaces;
using Application.ModelosDTO;
using Application.Utilidades;
using Data.Repositorio;
using Domain.Interfaces;
using Domain.Modelos;
using Domain.ModelosDTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

       

        [HttpGet("GetCandidate")]
        public IEnumerable<CandidateDTO> GetCandidate()
        {
            var lista = _candidateService.GetCandidate().Select(e => (Mapear.MapearCandidateACandidateDTO(e)));
             return lista.ToList();
        }


        [HttpGet("GetCandidateId")]
        public IEnumerable<CandidateExperienceDetail> GetCandidate(int Id)
        {
            var lista = _candidateService.GetCandidate(Id);
            return lista.ToList();
        }

        [HttpGet("GetCandidateExperience")]
        public IEnumerable<CandidateExperienceDTO> GetCandidateExperience()
        {
            var lista = _candidateService.GetCandidateExperience().Select(e => (Mapear.MapearCandidateExperienceACandidateExperienceDTO(e)));
             return lista.ToList();
        }

        [HttpGet("GetCandidateExperienceDetail")]
        public IActionResult GetCandidateExperienciaDetail()
        {
            var lista = _candidateService.GetCandidateExperienceDetail();
              return Ok(lista);
        }


        [HttpPost("PostCandidateExperienciaDetail")]
        public IActionResult PostCandidateExperienceDetail([FromBody] CandidateExperiencceDetaillDTO candidateExperiencceDetaill)
        {
            var model = Mapear.MapearCandidateExperiencceDetaillDTO(candidateExperiencceDetaill);
            var rta = _candidateService.PostCandidateExperience(model);
             return Ok(rta);
        }


        [HttpPut("PutCandidateExperienciaDetail")]
        public IActionResult PutCandidateExperienceDetail([FromBody] CandidateExperiencceDetaillDTO candidateExperiencceDetaill)
        {
            var model = Mapear.MapearCandidateExperiencceDetaillDTO(candidateExperiencceDetaill);
            var rta = _candidateService.PutCandidateExperience(model);
             return Ok(rta);
        }

        [HttpDelete("DeleteCandidateExperience")]
        public IActionResult DeleteCandidateExperience(string Id)
        {
             var rta = _candidateService.DeleteCandidateExperience(Id);
             return Ok(rta);
        }
    }
}
