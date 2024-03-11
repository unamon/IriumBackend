using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class IriumContext : DbContext
{
    private IriumContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<School> Schools { get; set; }
}