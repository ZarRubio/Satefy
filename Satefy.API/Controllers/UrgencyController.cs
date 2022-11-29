using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safety.Domain;
using Safety.Infraestructure.Models;
using Satefy.API.Resource;

namespace Satefy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrgencyController : ControllerBase
    {
        private readonly IUrgencyDomain _urgencyDomain;
        private readonly IMapper _mapper;
        
        public UrgencyController(IUrgencyDomain UrgencyDomain,IMapper mapper)
        {
            _urgencyDomain = UrgencyDomain;
            _mapper = mapper;
        }
        // GET: api/Urgency
        [HttpGet]
        public async Task<IActionResult> GetUrgencyforGuardianId (int GuardianId)
        {
            try
            {
                var result = await _urgencyDomain.getUrgencyforGuardianId(GuardianId);
                return Ok(_mapper.Map<List<Urgency>, List<Guardian>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
            
        }

        // GET: api/Urgency/5
        [HttpGet("{id}", Name = "Get1")]
        public  async Task<IActionResult> GetUrgencyforId (int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("id");
                }

                var result = await _urgencyDomain.getUrgencyforId(id);
                return Ok(_mapper.Map<Urgency, UrgencyResource>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 

        // POST: api/Urgency
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Urgency/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]  Urgency urgencyInput)
        {
            try
            {
                var result = await _urgencyDomain.updateUrgency(id, urgencyInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }

        // DELETE: api/Urgency/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _urgencyDomain.deleteUrgency(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
    }
}
