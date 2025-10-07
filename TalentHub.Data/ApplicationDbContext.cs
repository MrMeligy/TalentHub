using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Academy> Academies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AcademyTeam> AcademyTeams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerMatch> PlayerMatches { get; set; }
        public DbSet<PlayerSkill> PlayerSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Account>(e=>
            e.HasIndex(a=>a.UserName).IsUnique());
                
            
            // ===================== Academy =====================
            modelBuilder.Entity<Academy>(e =>
            {
                e.HasKey(a => a.Id);

                e.Property(a => a.Name).IsRequired().HasMaxLength(200);
                e.Property(a => a.Describtion).HasMaxLength(1000);
                e.Property(a => a.City).HasMaxLength(100);
                e.Property(a => a.Country).HasMaxLength(100);
                e.Property(a => a.Phone).HasMaxLength(50);
                e.Property(a => a.Email).HasMaxLength(256);

                // اختياريًا: ممكن تعمل Unique على الإيميل لو بيميز الأكاديمية
                // e.HasIndex(a => a.Email).IsUnique();

                e.HasMany(a => a.AcademyTeams)
                 .WithOne(t => t.Academy)
                 .HasForeignKey(t => t.AcademyId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ===================== AcademyTeam =====================
            modelBuilder.Entity<AcademyTeam>(e =>
            {
                e.HasKey(t => t.Id);

                e.Property(t => t.AgeGroup).IsRequired().HasMaxLength(50);

                // كل أكاديمية يكون لها فريق واحد لكل فئة عمرية
                e.HasIndex(t => new { t.AcademyId, t.AgeGroup }).IsUnique();

                e.HasMany(t => t.Players)
                 .WithOne(p => p.AcademyTeam)
                 .HasForeignKey(p => p.AcademyTeamId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ===================== Player =====================
            modelBuilder.Entity<Player>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Name).IsRequired().HasMaxLength(200);
                e.Property(p => p.FavouriteFoot).HasMaxLength(10);    // Right/Left/Both
                e.Property(p => p.Position).HasMaxLength(50);
                e.Property(p => p.Nationality).HasMaxLength(100);

                // تيشيرت فريد داخل نفس الفريق
                e.HasIndex(p => new { p.AcademyTeamId, p.ShirtNumber }).IsUnique();

                e.HasMany(p => p.PlayerMatches)
                 .WithOne(pm => pm.Player)
                 .HasForeignKey(pm => pm.PlayerId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ===================== Match =====================
            modelBuilder.Entity<Match>(e =>
            {
                e.HasKey(m => m.Id);

                e.Property(m => m.Venue).HasMaxLength(200);
                e.Property(m => m.Kickoff).IsRequired();

                // فريقين مختلفين لنفس المباراة
                e.HasOne(m => m.HomeTeam)
                 .WithMany()
                 .HasForeignKey(m => m.HomeId)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(m => m.AwayTeam)
                 .WithMany()
                 .HasForeignKey(m => m.AwayId)
                 .OnDelete(DeleteBehavior.Restrict);

                // Index يساعد على البحث عن مباراة معينة
                e.HasIndex(m => new { m.HomeId, m.AwayId, m.Kickoff });

                e.HasMany(m => m.PlayerMatches)
                 .WithOne(pm => pm.Match)
                 .HasForeignKey(pm => pm.MatchId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // ===================== PlayerMatch =====================
            modelBuilder.Entity<PlayerMatch>(e =>
            {
                e.HasKey(pm => pm.Id);

                // لاعب واحد لا يسجل مرتين في نفس المباراة
                e.HasIndex(pm => new { pm.MatchId, pm.PlayerId }).IsUnique();

                // إسناد الفريق وقت المباراة (مفيد لو اللاعب انتقل لاحقًا)
                e.HasOne(pm => pm.AcademyTeam)
                 .WithMany()
                 .HasForeignKey(pm => pm.AcademyTeamId)
                 .OnDelete(DeleteBehavior.Restrict);

            });

            // ===================== PlayerSkill =====================
            modelBuilder.Entity<PlayerSkill>(e =>
            {
                e.HasKey(ps => ps.Id);

                e.Property(ps => ps.Skill).IsRequired().HasMaxLength(100);

                e.HasOne(ps => ps.Player)
                 .WithMany() // مفيش Navigation في Player، فـ WithMany() بدون مجموعة
                 .HasForeignKey(ps => ps.PlayerId)
                 .OnDelete(DeleteBehavior.Cascade);

                // (اختياري) منع تكرار نفس المهارة لنفس اللاعب
                e.HasIndex(ps => new { ps.PlayerId, ps.Skill }).IsUnique();
            });
        }


    }
}
