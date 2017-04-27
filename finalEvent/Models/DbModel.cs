namespace finalEvent.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbSet <User> Users { get; set; }
        public DbModel()
            : base("name=DbModel")
        {
        }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
