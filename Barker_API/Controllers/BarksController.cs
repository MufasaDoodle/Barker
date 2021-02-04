using Barker_API.Data;
using Barker_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BarksController : ControllerBase
    {
        IBarkService barkService;

        public BarksController(IBarkService barkService)
        {
            this.barkService = barkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Bark>> CreateBark([FromBody] Bark bark)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Bark added = await barkService.CreateBarkAsync(bark);
                return Created($"/{added.BarkID}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> GetBark([FromQuery] int id)
        {
            try
            {
                Bark bark = await barkService.GetBarkAsync(id);
                return Ok(bark);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<User>>> GetBarksByUser([FromQuery] int id)
        {
            try
            {
                List<Bark> bark = await barkService.GetBarksByUserAsync(id);
                return Ok(bark);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> UpdateBark([FromBody] Bark bark)
        {
            try
            {
                Bark updatedBark = await barkService.UpdateBarkAsync(bark);
                return Ok(updatedBark);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteBark([FromRoute] int id)
        {
            try
            {
                await barkService.DeleteBarkAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
