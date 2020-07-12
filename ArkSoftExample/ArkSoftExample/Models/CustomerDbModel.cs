namespace ArkSoftExample.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CustomerDbModel : DbContext
    {
        public CustomerDbModel()
            : base("name=CustomerDbModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.VATNumber)
                .IsFixedLength();
        }
    }
}
