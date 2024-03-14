using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class IriumContext : DbContext
{
    public IriumContext(DbContextOptions<IriumContext> options) : base(options)
    {
    }

    public DbSet<School> Schools { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<SchoolsPackage> SchoolsPackages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Schools");

            entity.Property(e => e.ArvorePartnerId).HasColumnName("arvore_partner_id");
            entity.Property(e => e.ArvoreReferenceId).HasColumnName("arvore_reference_id");
            entity.Property(e => e.DefaultCalendar).HasColumnName("default_calendar");
            entity.Property(e => e.EduQuestPartnerId).HasColumnName("edu_quest_partner_id");
            entity.Property(e => e.EduQuestPath).HasColumnName("edu_quest_path");
        });
        modelBuilder.Entity<SchoolsPackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SchoolsPackages");

            entity.Property(e => e.ArvorePartnerId).HasColumnName("arvore_partner_id");
            entity.Property(e => e.ArvoreReferenceId).HasColumnName("arvore_reference_id");
           
        });

        
    }
}