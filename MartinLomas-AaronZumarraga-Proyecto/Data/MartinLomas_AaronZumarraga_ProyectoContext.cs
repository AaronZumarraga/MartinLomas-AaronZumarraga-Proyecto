using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MartinLomas_AaronZumarraga_Proyecto.Models;

namespace MartinLomas_AaronZumarraga_Proyecto.Data
{
    public class MartinLomas_AaronZumarraga_ProyectoContext : DbContext
    {
        public MartinLomas_AaronZumarraga_ProyectoContext (DbContextOptions<MartinLomas_AaronZumarraga_ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<MartinLomas_AaronZumarraga_Proyecto.Models.Tecnologia> Tecnologia { get; set; } = default!;

        public DbSet<MartinLomas_AaronZumarraga_Proyecto.Models.Deporte> Deporte { get; set; }

        public DbSet<MartinLomas_AaronZumarraga_Proyecto.Models.Cultura> Cultura { get; set; }

        public DbSet<MartinLomas_AaronZumarraga_Proyecto.Models.Arte> Arte { get; set; }
    }
}
