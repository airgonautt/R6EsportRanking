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
    public DbSet<TeamEloHistory> TeamEloHistories { get; set; }
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
        .Property(r => r.RegionID)
        .HasMaxLength(2);  // name max length

        //MATCH RELATIONSHIPS
        modelBuilder.Entity<Match>()
        .HasKey(m => m.MatchID);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Team1)
            .WithMany(t => t.TeamMatches)
            .HasForeignKey(m => m.Team1ID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Team2)
            .WithMany(t => t.TeamMatches)
            .HasForeignKey(m => m.Team2ID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Match>()
            .HasOne(m => m.Tournament)
            .WithMany(t => t.Matches)
            .HasForeignKey(m => m.TournamentID);

        //TEAM ELO HISTORY RELATIONSHIPS
        modelBuilder.Entity<TeamEloHistory>()
            .HasOne(teh => teh.Team)
            .WithMany(t => t.TeamEloHistories)
            .HasForeignKey(teh => teh.TeamID);

        modelBuilder.Entity<TeamEloHistory>()
            .HasOne(teh => teh.Match)
            .WithMany(m => m.TeamEloHistories)
            .HasForeignKey(teh => teh.MatchID);

        modelBuilder.Entity<TeamEloHistory>()
            .HasOne(teh => teh.RivalTeam)
            .WithMany()
            .HasForeignKey(teh => teh.RivalTeamID);

    }

}
