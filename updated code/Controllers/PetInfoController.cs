using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PetsRegApi.Models;
using PetsRegApi.Services.PetService;

namespace PetsRegApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PetInfoController : ControllerBase
    {
        private readonly PetsDBContext _context;
        private readonly IPetService _petService;

        //public PetInfoController(PetsDBContext context)
        //{
        //    _context = context;
        //}

        // for Service implementation
        public PetInfoController(IPetService petService)
        {
            _context = context;
            _petService = petService;
        }

        // GET: api/PetInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetInfo>>> GetPetsList()
        {
            //return await _context.PetsList.ToListAsync();
            return await _petService.GetAllPets();
        }

        // GET: api/PetInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetInfo>> GetPetInfo(int id)
        {
            //var petInfo = await _context.PetsList.FindAsync(id);

            //if (petInfo == null)
            //{
            //    return NotFound();
            //}

            //return petInfo;
            return await _petService.GetPetInfoById(id);
        }

        // PUT: api/PetInfo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetInfo(int id, PetInfo petInfo)
        {
            /*if (id != petInfo.petId)
            {
                return BadRequest();
            }*/

            petInfo.petId = id;

            _context.Entry(petInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PetInfo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PetInfo>> PostPetInfo(PetInfo petInfo)
        {
            //_context.PetsList.Add(petInfo);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPetInfo", new { id = petInfo.petId }, petInfo);
            return await _petService.AddNewPet(petInfo);
        }

        // DELETE: api/PetInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PetInfo>> DeletePetInfo(int id)
        {
            var petInfo = await _context.PetsList.FindAsync(id);
            if (petInfo == null)
            {
                return NotFound();
            }

            _context.PetsList.Remove(petInfo);
            await _context.SaveChangesAsync();

            return petInfo;
        }

        private bool PetInfoExists(int id)
        {
            return _context.PetsList.Any(e => e.petId == id);
        }
    }
}
