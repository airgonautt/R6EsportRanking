using Microsoft.EntityFrameworkCore;
using R6Ranking.Components.Splashable;
using R6Ranking.Migrations;
using R6Ranking.Models;

namespace R6Ranking.Data;

public class R6EsportsDbContext : DbContext {

    public DbSet<Map> Maps { get; set; }
    public DbSet<Match> Matches { get; set; }
    public DbSet<TeamOperatorBan> TeamOperatorBans { get; set; }
    public DbSet<OperatorBan> OperatorBans { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<RegionEloChange> RegionEloChanges { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamEloChange> TeamEloChanges { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<TournamentTeam>TournamentTeams { get; set; }
    public DbSet<Trophy> Trophies { get; set; }
    public DbSet<OriginCountry> Countries { get; set; }
    public DbSet<MapStat> MapStats { get; set; }
    public DbSet<TeamRivalry> TeamRivalries { get; set; }
    public DbSet<UpcomingMatch> UpcomingMatches { get; set; }

    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<UserAccountPolicy> UserAccountsPolicies { get; set; }

    public R6EsportsDbContext(DbContextOptions<R6EsportsDbContext> options)
        : base(options) {
        Database.EnsureCreated();
    }

    public R6EsportsDbContext() {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //UPCOMING MATCHES
        modelBuilder.Entity<UpcomingMatch>(entity => {
            entity.HasKey(m => m.FutureMatchID);

            entity.HasOne(m => m.Team1)
                .WithMany()
                .HasForeignKey(m => m.Team1ID)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Team2)
                .WithMany()
                .HasForeignKey(m => m.Team2ID)
                .OnDelete(DeleteBehavior.Restrict);
        });

        //MATCH RELATIONSHIPS
        modelBuilder.Entity<Match>(entity => {
            entity.HasKey(m => m.MatchID);

            entity.HasOne(m => m.Map)
                .WithMany(map => map.Matches)
                .HasForeignKey(m => m.MapID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.Team1)
                .WithMany(t => t.MatchesAsTeam1)
                .HasForeignKey(m => m.Team1ID)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Team2)
                .WithMany(t => t.MatchesAsTeam2)
                .HasForeignKey(m => m.Team2ID)
                .OnDelete(DeleteBehavior.Restrict);
        });

        //OPERATOR BANS
        modelBuilder.Entity<OperatorBan>()
            .HasKey(t => t.OperatorBanID);

        //TEAM OPERATOR BANS
        modelBuilder.Entity<TeamOperatorBan>(entity => {
            entity.HasKey(e => e.TeamOperatorBanID);

            entity.HasOne(e => e.OperatorBan)
                  .WithMany()
                  .HasForeignKey(e => e.OperatorBanID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //COUNTRY RELATIONSHIPS
        modelBuilder.Entity<OriginCountry>(entity => {
            entity.HasKey(c => c.CountryID);
        });

        //REGION RELATIONSHIPS
        modelBuilder.Entity<Region>(entity => {
            entity.HasKey(r => r.RegionID);

            entity.HasMany(r => r.Tournaments)
               .WithOne(t => t.Region)
               .HasForeignKey(t => t.TournamentID);
        });

        //REGION ELO HISTORY
        modelBuilder.Entity<RegionEloChange>()
            .HasKey(reh => reh.RegionEloHistoryID);

        modelBuilder.Entity<RegionEloChange>()
            .HasOne(reh => reh.Region)
            .WithMany(r => r.RegionEloHistory)
            .HasForeignKey(reh => reh.RegionID);

        // TEAM RELATIONSHIPS
        modelBuilder.Entity<Team>()
            .HasKey(t => t.TeamID);

        modelBuilder.Entity<Team>()
        .HasMany(t => t.Tournaments)
        .WithMany(t => t.Teams)
        .UsingEntity<Dictionary<string, object>>(
            "TeamTournament",
            join => join
                .HasOne<Tournament>()
                .WithMany()
                .HasForeignKey("TournamentID")
                .OnDelete(DeleteBehavior.Cascade),
            join => join
                .HasOne<Team>()
                .WithMany()
                .HasForeignKey("TeamID")
                .OnDelete(DeleteBehavior.Cascade)
        );

        //TEAM ELO CHANGE RELATIONSHIPS
        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.Team)
            .WithMany(t => t.TeamEloHistory)
            .HasForeignKey(tec => tec.TeamID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.RivalTeam)
            .WithMany()
            .HasForeignKey(tec => tec.RivalTeamID)
            .OnDelete(DeleteBehavior.Restrict);

        ////TOURNAMENT TEAM
        modelBuilder.Entity<TournamentTeam>(entity => {
            entity.HasKey(e => e.TournamentTeamID);

            entity.HasOne(e => e.Tournament)
                  .WithMany()
                  .HasForeignKey(e => e.TournamentID)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        //TOURNAMENT RELATIONSHIPS
        modelBuilder.Entity<Tournament>()
            .HasKey(t => t.TournamentID);

        modelBuilder.Entity<Tournament>()
            .HasOne(t => t.Trophy)
            .WithOne(tr => tr.Tournament)
            .HasForeignKey<Trophy>(tr => tr.TournamentID);

        modelBuilder.Entity<Tournament>()
            .HasOne(t => t.WinnerTeam)
            .WithMany()
            .HasForeignKey(t => t.WinnerTeamID);

        modelBuilder.Entity<Tournament>()
            .HasOne(t => t.Region)
            .WithMany(r => r.Tournaments)
            .HasForeignKey(t => t.RegionID);

        //MAP STATS
        modelBuilder.Entity<MapStat>(entity =>
        {
            entity.HasKey(ms => ms.MapStatsID);

            entity.HasOne(ms => ms.Team)
                .WithMany()
                .HasForeignKey(ms => ms.TeamID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(ms => ms.Map)
                .WithMany()
                .HasForeignKey(ms => ms.MapID)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

}

