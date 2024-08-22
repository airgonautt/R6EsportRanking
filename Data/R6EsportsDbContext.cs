using Microsoft.EntityFrameworkCore;
using R6Ranking.Models;
using System.Xml;

namespace R6Ranking.Data;

public class R6EsportsDbContext : DbContext {

    public DbSet<Region> Regions { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamLogo> TeamsLogo { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<PlayerEloHistory> PlayerEloHistories { get; set; }
    public DbSet<TeamEloChange> TeamEloChanges { get; set; }
    public DbSet<RegionEloHistory> RegionEloHistories { get; set; }

    public R6EsportsDbContext(DbContextOptions<R6EsportsDbContext> options)

        : base(options) {
        Database.EnsureCreated();
    }

    public R6EsportsDbContext() {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        // TEAM RELATIONSHIPS
        modelBuilder.Entity<Team>()
            .HasKey(t => t.TeamID);

        modelBuilder.Entity<Team>()
            .HasOne(t => t.Logo)
            .WithOne(l => l.Team)
            .HasForeignKey<TeamLogo>(l => l.TeamID);

        //REGION RELATIONSHIPS
        modelBuilder.Entity<Region>()
            .HasKey(r => r.RegionID);

        modelBuilder.Entity<Region>()
           .HasMany(r => r.Tournaments)
           .WithOne(t => t.Region)
           .HasForeignKey(t => t.TournamentID);///

        //MATCH RELATIONSHIPS
        modelBuilder.Entity<Match>()
           .HasKey(m => m.MatchID);

        modelBuilder.Entity<Match>()
           .HasOne(m => m.Team1)
           .WithMany(t => t.MatchesAsTeam1)
           .HasForeignKey(m => m.Team1ID)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
           .HasOne(m => m.Team2)
           .WithMany(t => t.MatchesAsTeam2)
           .HasForeignKey(m => m.Team2ID)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
           .HasOne(t => t.Tournament)
           .WithMany(m => m.Matches)
           .HasForeignKey(t => t.TournamentID);

        //TEAM ELO CHANGE RELATIONSHIPS
        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.Team)
            .WithMany(t => t.TeamEloChanges)
            .HasForeignKey(tec => tec.TeamID)
            .OnDelete(DeleteBehavior.Restrict); // Ensure no cascade delete conflicts

        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.RivalTeam)
            .WithMany()
            .HasForeignKey(tec => tec.RivalTeamID)
            .OnDelete(DeleteBehavior.Restrict); // Avoids circular cascade delete
        
        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.Match)
            .WithMany(m => m.TeamEloChanges)
            .HasForeignKey(tec => tec.MatchID)   
            .OnDelete(DeleteBehavior.Cascade);

        //TOURNAAMENT RELATIONSHIPS
        modelBuilder.Entity<Tournament>()
            .HasKey(t => t.TournamentID);

        modelBuilder.Entity<Tournament>()
            .HasOne(t => t.WinnerTeam)
            .WithMany()
            .HasForeignKey(t => t.WinnerTeamID);

        modelBuilder.Entity<Tournament>()
            .HasOne(t => t.Region)
            .WithMany(r => r.Tournaments)
            .HasForeignKey(t => t.RegionID);

    }

}