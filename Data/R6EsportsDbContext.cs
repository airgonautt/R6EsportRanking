using Microsoft.EntityFrameworkCore;
using R6Ranking.Models;
using System.Xml;

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
    public DbSet<TeamTournament> TeamTournaments { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Trophy> Trophies { get; set; }

    public R6EsportsDbContext(DbContextOptions<R6EsportsDbContext> options)
        : base(options) {
        Database.EnsureCreated();
    }

    public R6EsportsDbContext() {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        //MAPS
        modelBuilder.Entity<Map>().HasData(
            new Map { MapID = 100, MapName = "DefaultMap"},
            new Map { MapID = 1, MapName = "Bank" },
            new Map { MapID = 2, MapName = "Border" },
            new Map { MapID = 3, MapName = "Chalet" },
            new Map { MapID = 4, MapName = "Clubhouse" },
            new Map { MapID = 5, MapName = "Consulate" },
            new Map { MapID = 6, MapName = "Kafe Dostoyevksy" },
            new Map { MapID = 7, MapName = "Lair" },
            new Map { MapID = 8, MapName = "Nighthaven Labs" },
            new Map { MapID = 9, MapName = "Oregon" },
            new Map { MapID = 10, MapName = "Skyscraper" },
            new Map { MapID = 11, MapName = "Theme Park" },
            new Map { MapID = 12, MapName = "Villa" }
        );

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

            entity.HasOne(t => t.Tournament)
               .WithMany(m => m.Matches)
               .HasForeignKey(t => t.TournamentID);

        });
 
        //OPERATOR BANS
        modelBuilder.Entity<OperatorBan>()
            .HasKey(t => t.OperatorBanID);

        //TEAMOPERATORBANS 
        modelBuilder.Entity<TeamOperatorBan>(entity =>
        {
            entity.HasKey(e => e.TeamOperatorBanID); // Primary Key

            // Relationships
            entity.HasOne(e => e.Team)
                .WithMany(t => t.TeamOperatorBans)
                .HasForeignKey(e => e.TeamID)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a team removes related bans

            entity.HasOne(e => e.Match)
                .WithMany(m => m.TeamOperatorBans)
                .HasForeignKey(e => e.MatchId)
                .OnDelete(DeleteBehavior.Cascade); // Deleting a match removes related bans
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

        // TEAMTOURNAMENT ---------------JOINED ENTITY 
        modelBuilder.Entity<TeamTournament>()
            .HasKey(tt => new { tt.TeamID, tt.TournamentID });

        modelBuilder.Entity<TeamTournament>()
            .HasOne(tt => tt.Team)
            .WithMany(t => t.TournamentsIn)
            .HasForeignKey(tt => tt.TeamID);

        modelBuilder.Entity<TeamTournament>()
            .HasOne(tt => tt.Tournament)
            .WithMany(t => t.TournamentTeams)
            .HasForeignKey(tt => tt.TournamentID);

        //TEAM ELO CHANGE RELATIONSHIPS
        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.Team)
            .WithMany(t => t.TeamEloHistory)
            .HasForeignKey(tec => tec.TeamID)
            .OnDelete(DeleteBehavior.Restrict); // Ensure no cascade delete conflicts

        modelBuilder.Entity<TeamEloChange>()
            .HasOne(tec => tec.RivalTeam)
            .WithMany()
            .HasForeignKey(tec => tec.RivalTeamID)
            .OnDelete(DeleteBehavior.Restrict); // Avoids circular cascade delete

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
               
    }

public DbSet<R6Ranking.Models.Map> Map { get; set; } = default!;

}

