using LogSystem.Application.Application;
using LogSystem.Domain.Entities;
using LogSystem.Domain.Entities.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogSystem.WebApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ILeadsApplication _leadsApplication;

        public LeadsController(ILeadsApplication leadsApplication)
        {
            _leadsApplication = leadsApplication ?? throw new ArgumentNullException(nameof(leadsApplication));
        }


        [HttpGet]
        [Route("GetInvited")]
        public ActionResult<IEnumerable<Leads>> GetLeadsInvited()
        {
            try
            {
                var leadsInvited = _leadsApplication.GetLeadsByStatus((int)Status.Invited);
                return Ok(leadsInvited);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os leads: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAccpted")]
        public ActionResult<IEnumerable<Leads>> GetLeadsAccpted()
        {
            try
            {
                var leadsInvited = _leadsApplication.GetLeadsByStatus((int)Status.Accept);
                return Ok(leadsInvited);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter os leads: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostLeads([FromBody] Leads leads)
        {
            try
            {
                _leadsApplication.SaveLead(leads);
                return Ok("Lead salvo com sucesso!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o comentário: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("Accepted")]
        public async Task<ActionResult<string>> Accepted([FromBody] Leads leads)
        {
            try
            {
                var retorno = _leadsApplication.Accpted(leads);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o comentário: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Declined")]
        public async Task<ActionResult<string>> Declined([FromBody] Leads leads)
        {
            try
            {
                _leadsApplication.Declined(leads);

                return Ok("Lead Declinado"+ leads.LeadId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar o comentário: {ex.Message}");
            }
        }
    }
}
