using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Challenger.Application.DTOs.Requests;
using Challenger.Application.DTOs.Responses;
using Challenger.Application.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenger.Domain.Entities;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatioController : ControllerBase
    {
        private readonly ICreatePatioUseCase _createPatioUseCase;
        private readonly IUpdatePatioUseCase _updatePatioUseCase;
        private readonly IPatioRepository _patioRepository;

        public PatioController(
            ICreatePatioUseCase createPatioUseCase,
            IUpdatePatioUseCase updatePatioUseCase,
            IPatioRepository patioRepository)
        {
            _createPatioUseCase = createPatioUseCase;
            _updatePatioUseCase = updatePatioUseCase;
            _patioRepository = patioRepository;
        }

        // GET: api/Patio
        [HttpGet]
        public async Task<IEnumerable<PatioResponse>> GetPatios()
        {
            var patios = await _patioRepository.GetAllAsync();
            return patios.Select(p => new PatioResponse(p.Id, p.Name, p.Cidade, p.Capacidade));
        }

        // GET: api/Patio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatioResponse>> GetPatio(Guid id)
        {
            var patio = await _patioRepository.GetByIdAsync(id);
            if (patio == null) return NotFound();
            return new PatioResponse(patio.Id, patio.Name, patio.Cidade, patio.Capacidade);
        }

        // GET: api/Patios/cidade/{cidade}
        [HttpGet("cidade/{cidade}")]
        public async Task<ActionResult<IEnumerable<PatioResponse>>> GetPatiosPorCidade(string cidade)
        {
            var patios = await _patioRepository.GetByCidadeAsync(cidade);
            if (!patios.Any()) return NotFound($"Nenhum pátio encontrado para a cidade '{cidade}'.");
            return Ok(patios.Select(p => new PatioResponse(p.Id, p.Name, p.Cidade, p.Capacidade)));
        }

        // POST: api/Patios
        [HttpPost]
        [ProducesResponseType(typeof(PatioResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PatioResponse>> PostPatio(PatioRequest request)
        {
            try
            {
                string createdBy = User?.Identity?.Name ?? "system";
                var patioResponse = await _createPatioUseCase.Execute(request, createdBy);
                return CreatedAtAction(nameof(GetPatio), new { id = patioResponse.Id }, patioResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao criar o pátio." });
            }
        }

// PUT: api/Patios/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatio(Guid id, PatioRequest request)
        {
            try
            {
                // Pega o usuário autenticado, ou "system" se não houver
                string updatedBy = User?.Identity?.Name ?? "system";

                // Chama o UseCase com o novo parâmetro
                var updated = await _updatePatioUseCase.Execute(id, request, updatedBy);

                if (!updated)
                    return NotFound("Pátio não encontrado.");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao atualizar o pátio." });
            }
        }
        // DELETE: api/Patios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatio(Guid id)
        {
            var patio = await _patioRepository.GetByIdAsync(id);
            if (patio == null) return NotFound("Pátio não encontrado.");

            await _patioRepository.DeleteAsync(patio);
            return NoContent();
        }
    }
}
