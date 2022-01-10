#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using google_sheet_api_service.Models;

    public class MvcSoundSettingContext : DbContext
    {
        public MvcSoundSettingContext (DbContextOptions<MvcSoundSettingContext> options)
            : base(options)
        {
        }

        public DbSet<google_sheet_api_service.Models.SoundSetting> SoundSetting { get; set; }
    }
