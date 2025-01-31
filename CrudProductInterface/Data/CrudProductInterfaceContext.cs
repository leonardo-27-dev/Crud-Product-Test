using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudProduct.Models;

namespace CrudProductInterface.Data
{
    public class CrudProductInterfaceContext : DbContext
    {
        public CrudProductInterfaceContext (DbContextOptions<CrudProductInterfaceContext> options)
            : base(options)
        {
        }

        public DbSet<CrudProduct.Models.Product> Product { get; set; } = default!;
    }
}
