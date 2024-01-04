using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TempTrackApp.Models
{
    public partial class CRUDContext : DbContext
    {
        public CRUDContext()
        {
        }

        public CRUDContext(DbContextOptions<CRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Forecast> Forecasts { get; set; } = null!;
        public virtual DbSet<KategoriteEmotit> KategoriteEmotits { get; set; } = null!;
        public virtual DbSet<Klienti> Klientis { get; set; } = null!;
        public virtual DbSet<Map> Maps { get; set; } = null!;
        public virtual DbSet<NiveletEere> NiveletEeres { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<WeatherAppConfiguration> WeatherAppConfigurations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JN9FIUJ;Database=CRUD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Forecast>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.ForecastDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<KategoriteEmotit>(entity =>
            {
                entity.ToTable("KategoriteEMotit");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Emri).HasMaxLength(50);

                entity.Property(e => e.Pershkrimi).HasMaxLength(255);
            });

            modelBuilder.Entity<Klienti>(entity =>
            {
                entity.ToTable("Klienti");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Map>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<NiveletEere>(entity =>
            {
                entity.ToTable("NiveletEEres");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Emri).HasMaxLength(50);

                entity.Property(e => e.Pershkrimi).HasMaxLength(255);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(255);

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<WeatherAppConfiguration>(entity =>
            {
                entity.HasKey(e => e.ConfigId)
                    .HasName("PK__WeatherA__C3BC333C5F05F2C3");

                entity.Property(e => e.ConfigId)
                    .ValueGeneratedNever()
                    .HasColumnName("ConfigID");

                entity.Property(e => e.ConfigName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
