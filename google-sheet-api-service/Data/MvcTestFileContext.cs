using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcTestFileContext : DbContext
    {
        public MvcTestFileContext (DbContextOptions<MvcTestFileContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.TestFile> TestFile { get; set; }
    }
