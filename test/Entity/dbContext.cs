namespace test.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
            Database.SetInitializer<dbContext>(new CreateDatabaseIfNotExists<dbContext>());
        }

        public virtual DbSet<Kantar> Kantar { get; set; }
        public virtual DbSet<Plaka> Plaka { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
