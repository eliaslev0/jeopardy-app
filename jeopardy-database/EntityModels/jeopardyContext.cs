using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace jeopardy.EntityModels
{
    public partial class jeopardyContext : DbContext
    {
        public jeopardyContext()
        {
        }

        public jeopardyContext(DbContextOptions<jeopardyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clue> Clues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=54320;Database=jeopardy;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clue>(entity =>
            {
                entity.ToTable("clue");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Airdate).HasColumnName("airdate");

                entity.Property(e => e.Answer)
                    .HasColumnType("character varying")
                    .HasColumnName("answer");

                entity.Property(e => e.Category)
                    .HasColumnType("character varying")
                    .HasColumnName("category");

                entity.Property(e => e.Question)
                    .HasColumnType("character varying")
                    .HasColumnName("question");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
