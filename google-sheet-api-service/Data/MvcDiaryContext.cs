#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcDiaryContext : DbContext
    {
        public MvcDiaryContext (DbContextOptions<MvcDiaryContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.Diary> Diary { get; set; }
    }
