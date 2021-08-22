using Microsoft.AspNetCore.Mvc;
using PetsRegApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsRegApi.Services
{
    interface IService
    {
        Task<ActionResult<IEnumerable<PetInfo>>> GetAllPets();

        Task<ActionResult<PetInfo>> GetPetInfoById(int id);

        Task<ActionResult<PetInfo>> AddNewPet(PetInfo newPet);
    }
}
