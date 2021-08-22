using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsRegApi.Models
{
    public class PetsDBContext : DbContext
    {
        public PetsDBContext(DbContextOptions<PetsDBContext> options) : base(options)
        {

        }

        public DbSet<PetInfo> PetsList { get; set; }
    }
}
