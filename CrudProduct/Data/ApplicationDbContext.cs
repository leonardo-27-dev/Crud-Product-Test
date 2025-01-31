using CrudProduct.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudProduct.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Product> Produtos { get; set; }
}
