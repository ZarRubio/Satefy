using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
    [Produces(MediaTypeNames.Application.Json)]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianDomain _guardianDomain;
        private readonly IMapper _mapper;
        
        public GuardianController(IGuardianDomain GuardianDomain, IMapper mapper)
        {
            _guardianDomain = GuardianDomain;
            _mapper = mapper;
        }
    
        // GET: api/Guardian
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _guardianDomain.getAll();
                return Ok(_mapper.Map<List<Guardian>, List<Guardian>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
            finally
            {
            
            }
            
        }
        // GET: api/Guardian/5
        [HttpGet("{id}", Name = "Get")]
        public  async Task<IActionResult> GetGuardianforId (int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("ManagerId");
                }

                var result = await _guardianDomain.getGuardianforId(id);
                return Ok(_mapper.Map<Guardian, GuardianResource>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        } 
        // POST: api/Guardian
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] GuardianResource guardianInput)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("error de formato");
                }
                var guardian = _mapper.Map<GuardianResource, Guardian>(guardianInput); //Aqui hago la conversion
                var result = await _guardianDomain.postGuardian(guardian); //Agrego await para que sea sincrona
                return StatusCode(StatusCodes.Status201Created, "guardian created");
            }
                                                                                                                
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar: "+ex);
            }
            finally
            {
                
            }
        }

        // PUT: api/Guardian/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]  Guardian guardianInput)
        {
            try
            {
                var result = await _guardianDomain.updateGuardian(id, guardianInput);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }

        // DELETE: api/Guardian/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _guardianDomain.deleteGuardian(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
    }
}
