#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcStoryDialogueContext : DbContext
    {
        public MvcStoryDialogueContext (DbContextOptions<MvcStoryDialogueContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.StoryDialogue> StoryDialogue { get; set; }
    }
