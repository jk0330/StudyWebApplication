using Microsoft.EntityFrameworkCore;
using StudyWebApplication.DbHelper;
using StudyWebApplication.Models;
using StudyWebApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyWebApplication.Data
{
    public class HomeContext : DbContext
    {
        public DbSet<Users> users { get; set; }
        public DbSet<NoteIndexView> noteIndex { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(OracleDataContext.ConnectionString);
        }
    }
}
