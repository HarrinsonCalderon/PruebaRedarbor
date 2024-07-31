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

        [HttpGet("GetCandidateExperiencia")]
        public IEnumerable<CandidateExperienceDTO> GetCandidateExperiencia()
        {
            var lista = _candidateService.GetCandidateExperience().Select(e => (Mapear.MapearCandidateExperienceACandidateExperienceDTO(e)));
             return lista.ToList();
        }

        [HttpGet("GetCandidateExperienciaDetalle")]
        public IActionResult GetCandidateExperienciaDetalle()
        {
            var lista = _candidateService.GetCandidateExperienceDetail();
              return Ok(lista);
        }


        [HttpPost("PostCandidateExperienciaDetalle")]
        public IActionResult PostCandidateExperienciaDetalle([FromBody] CandidateExperiencceDetaillDTO candidateExperiencceDetaill)
        {
            var model = Mapear.MapearCandidateExperiencceDetaillDTO(candidateExperiencceDetaill);
            var rta = _candidateService.PostCandidateExperience(model);
             return Ok(rta);
        }


        [HttpPut("PutCandidateExperienciaDetalle")]
        public IActionResult PutCandidateExperienciaDetalle([FromBody] CandidateExperiencceDetaillDTO candidateExperiencceDetaill)
        {
            var model = Mapear.MapearCandidateExperiencceDetaillDTO(candidateExperiencceDetaill);
            var rta = _candidateService.PutCandidateExperience(model);
             return Ok(rta);
        }

        [HttpDelete("DeleteCandidateExperiencia")]
        public IActionResult DeleteCandidateExperiencia(string Id)
        {
             var rta = _candidateService.DeleteCandidateExperience(Id);
             return Ok(rta);
        }
    }
}
