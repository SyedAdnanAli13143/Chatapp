using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SignalR.EFModels;

public partial class SignalrContext : DbContext
{
    public SignalrContext()
    {
    }

    public SignalrContext(DbContextOptions<SignalrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Connections> Connections { get; set; }

    public virtual DbSet<Person> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LP-029\\SQLEXPRESS;Database=Signalr;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Connections>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Connecti__3214EC076B1581AB");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SignalrId).HasMaxLength(255);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");

            entity.HasOne(d => d.Person).WithMany(p => p.Connections)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Connectio__Perso__3D5E1FD2");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3214EC072C15C01C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
