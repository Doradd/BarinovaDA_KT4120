using dariabarinovakt4120.Database.Configurations;
using dariabarinovakt4120.Models;
using Microsoft.EntityFrameworkCore;

namespace dariabarinovakt4120.Database
{
    public class SubjectDbContext : DbContext
    {
        //таблицы
        DbSet<Direction> Directions { get; set; }
        DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //конфигурации таблиц
            modelBuilder.ApplyConfiguration(new DirectionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }

        public SubjectDbContext(DbContextOptions<SubjectDbContext> options) : base(options)
        {

        }
    }
}
