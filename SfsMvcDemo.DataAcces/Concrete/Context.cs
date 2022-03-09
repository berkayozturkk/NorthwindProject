using SfsMvcDemo.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfsMvcDemo.DataAcces.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Products> Products { get; set; }
    }
}
