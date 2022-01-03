#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcBuildingContext : DbContext
    {
        public MvcBuildingContext (DbContextOptions<MvcBuildingContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.Building> Building { get; set; }
    }
