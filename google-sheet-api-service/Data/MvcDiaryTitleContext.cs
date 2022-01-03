#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcDiaryTitleContext : DbContext
    {
        public MvcDiaryTitleContext (DbContextOptions<MvcDiaryTitleContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.DiaryTitle> DiaryTitle { get; set; }
    }
