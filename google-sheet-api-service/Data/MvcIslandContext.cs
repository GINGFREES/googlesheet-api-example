#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcIslandContext : DbContext
    {
        public MvcIslandContext (DbContextOptions<MvcIslandContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.Island> Island { get; set; }
    }
