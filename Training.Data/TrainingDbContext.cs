using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Training.Data;

public class TrainingDbContext : DbContext
{
    public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }

    public DbSet<Athlete> Athletes => Set<Athlete>();
    public DbSet<WorkoutTemplate> WorkoutTemplates => Set<WorkoutTemplate>();
    public DbSet<PlannedSession> PlannedSessions => Set<PlannedSession>();
    public DbSet<CompletedSet> CompletedSets => Set<CompletedSet>();
    public DbSet<User> Users => Set<User>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Athlete>(entity =>
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.FullName).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Email).IsRequired().HasMaxLength(200);
            entity.HasIndex(a => a.Email).IsUnique();
            entity.Property(a => a.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<WorkoutTemplate>(entity =>
        {
            entity.HasKey(w => w.Id);
            entity.Property(w => w.Name).IsRequired().HasMaxLength(150);
        });

        modelBuilder.Entity<PlannedSession>(entity =>
        {
            entity.HasKey(ps => ps.Id);
            entity.HasOne(ps => ps.Athlete)
                  .WithMany(a => a.PlannedSessions)
                  .HasForeignKey(ps => ps.AthleteId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ps => ps.WorkoutTemplate)
                  .WithMany()
                  .HasForeignKey(ps => ps.WorkoutTemplateId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.Property(ps => ps.ScheduledAt).IsRequired();
        });

        modelBuilder.Entity<CompletedSet>(entity =>
        {
            entity.HasKey(cs => cs.Id);
            entity.HasOne(cs => cs.PlannedSession)
                  .WithMany(ps => ps.CompletedSets)
                  .HasForeignKey(cs => cs.PlannedSessionId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(s => new { s.Id, s.SequenceNumber }).IsUnique();
            entity.Property(cs => cs.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
        
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.HasOne(u => u.Athlete).WithMany().HasForeignKey(u => u.AthleteId);
            entity.Property(u => u.Username)
                  .IsRequired()
                  .HasMaxLength(100);
            entity.HasIndex(u => u.Username).IsUnique();
        });
    }
}