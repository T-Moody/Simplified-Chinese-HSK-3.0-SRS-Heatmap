using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Simplified_Chinese_HSK_3._0_SRS_Heatmap.Models;

namespace Simplified_Chinese_HSK_3._0_SRS_Heatmap.Data
{
    public class HskContext : DbContext
    {
        public HskContext(DbContextOptions<HskContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HskModel>().HasNoKey();
        }

        public DbSet<HskModel> notes { get; set; }
    }
}
