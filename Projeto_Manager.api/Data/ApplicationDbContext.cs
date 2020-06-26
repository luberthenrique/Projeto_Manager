using Microsoft.EntityFrameworkCore;
using Projeto_Manager.api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Manager.api.Data
{
    /// <summary>
    /// Classe utilizada para persistência de dados no banco SQLite
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dado> Dado { get; set; }
    }
}
