using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class IriumContext : DbContext
{
    public IriumContext(DbContextOptions<IriumContext> options) : base(options)
    {
    }

    public DbSet<School> Schools { get; set; }
}