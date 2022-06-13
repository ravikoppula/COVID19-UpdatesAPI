using COVID19UpdatesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19UpdatesAPI.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<ViewCases> ViewCases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = GlobalService.GetJsonConfiguration();
                string DBConnection = configuration.GetSection("ConnectionStrings").GetSection("context").Value;
                optionsBuilder.UseSqlServer(DBConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
