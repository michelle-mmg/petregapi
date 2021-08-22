using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsRegApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsRegApi.Services.PetService
{
    public class PetService : IPetService
    {
        private readonly PetsDBContext _context;

        public PetService(PetsDBContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<PetInfo>> AddNewPet(PetInfo newPet)
        {
            _context.PetsList.Add(newPet);
            await _context.SaveChangesAsync();
            CreatedAtActionResult

            return CreatedAtAction("GetPetInfo", new { id = newPet.petId }, newPet);
            //CreatedAtActionResult();
            //petInfo.Add(newPet);
            //return petInfo;
        }

        public async Task<ActionResult<IEnumerable<PetInfo>>> GetAllPets()
        {
            return await _context.PetsList.ToListAsync();
        }

        public async Task<ActionResult<PetInfo>> GetPetInfoById(int id)
        {
            var petInfo = await _context.PetsList.FindAsync(id);

            if (petInfo == null)
            {
                return NotFound();
            }

            return petInfo;
            //return petInfo.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IActionResult> UpdatePetInfo(int id, PetInfo updatedPetInfo)
        {
            //await _context.PetsList.FirstOrDefaultAsync(p => p.Id == updatedPetInfo.petId);
            await _context.SaveChangesAsync();
            //petInfo.petId = id;

            //_context.Entry(petInfo).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PetInfoExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        public async Task<IActionResult<PetInfo>> DeletePet(int id)
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
    }
}
