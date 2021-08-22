using Microsoft.AspNetCore.Mvc;
using PetsRegApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsRegApi.Services
{
    public class Service : IService
    {
        public Task<ActionResult<PetInfo>> AddNewPet(PetInfo newPet)
        {
            //_context.PetsList.Add(newPet);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetPetInfo", new { id = newPet.petId }, newPet);
            petInfo.Add(newPet);
            return petInfo;
        }

        public Task<ActionResult<IEnumerable<PetInfo>>> GetAllPets()
        {
            //return await _context.PetsList.ToListAsync();
            return petInfo;
        }

        public Task<ActionResult<PetInfo>> GetPetInfoById(int id)
        {
            //var petInfo = await _context.PetsList.FindAsync(id);

            //if (petInfo == null)
            //{
            //    return NotFound();
            //}

            //return petInfo;
            return petInfo.FirstOrDefault(p => p.Id == id);
        }
    }
}
