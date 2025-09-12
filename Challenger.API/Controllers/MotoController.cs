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
    public class MotoController : ControllerBase
    {
        private readonly ICreateMotoUseCase _createMotoUseCase;
        private readonly IUpdateMotoUseCase _updateMotoUseCase;
        private readonly IMotoRepository _motoRepository;

        public MotoController(
            ICreateMotoUseCase createMotoUseCase, 
            IUpdateMotoUseCase updateMotoUseCase,
            IMotoRepository motoRepository)
        {
            _createMotoUseCase = createMotoUseCase;
            _updateMotoUseCase = updateMotoUseCase;
            _motoRepository = motoRepository;
        }

        // GET: api/Moto
        [HttpGet]
        public async Task<IEnumerable<MotoResponse>> GetMotos()
        {
            var motos = await _motoRepository.GetAllAsync();
            return motos.Select(m => new MotoResponse(
                m.Id, 
                m.Placa.Valor, 
                m.Modelo, 
                m.Status, 
                m.PatioId
            ));
        }

        // GET: api/Moto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MotoResponse>> GetMoto(Guid id)
        {
            var moto = await _motoRepository.GetByIdAsync(id);
            if (moto == null) return NotFound();
            return new MotoResponse(
                moto.Id, 
                moto.Placa.Valor, 
                moto.Modelo, 
                moto.Status, 
                moto.PatioId
            );
        }

        // POST: api/Moto
        [HttpPost]
        [ProducesResponseType(typeof(MotoResponse), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<MotoResponse>> PostMoto(MotoRequest request)
        {
            try
            {
                string createdBy = User?.Identity?.Name ?? "system";
                var motoResponse = await _createMotoUseCase.Execute(request, createdBy);
                return CreatedAtAction(nameof(GetMoto), new { id = motoResponse.Id }, motoResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao criar a moto." });
            }
        }

        // PUT: api/Moto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoto(Guid id, MotoRequest request)
        {
            try
            {
                string updatedBy = User?.Identity?.Name ?? "system";
                var updated = await _updateMotoUseCase.Execute(id, request, updatedBy);

                if (!updated)
                    return NotFound("Moto não encontrada.");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Erro ao atualizar a moto." });
            }
        }

        // DELETE: api/Moto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoto(Guid id)
        {
            var moto = await _motoRepository.GetByIdAsync(id);
            if (moto == null) return NotFound("Moto não encontrada.");

            await _motoRepository.DeleteAsync(moto);
            return NoContent();
        }

        
    }
}
