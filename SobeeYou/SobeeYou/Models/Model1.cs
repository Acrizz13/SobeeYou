using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SobeeYou.Models {
    public partial class Model1 : DbContext {
        public Model1()
            : base("name=ShoppingCartContext") {
        }

        public virtual DbSet<TCartItem> TCartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
