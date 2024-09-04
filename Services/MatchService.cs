using Microsoft.EntityFrameworkCore;
using R6Ranking.Data;
using R6Ranking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace R6Ranking.Services {
    public class MatchService {
        private readonly IDbContextFactory<R6EsportsDbContext> _dbFactory;

        public MatchService(IDbContextFactory<R6EsportsDbContext> dbFactory) {
            _dbFactory = dbFactory;
        }

        public async Task IncrementTeamEloAsync(Match match) {
            using var context = _dbFactory.CreateDbContext();
            var team1 = await context.Teams.FindAsync(match.Team1ID);
            var team2 = await context.Teams.FindAsync(match.Team2ID);

            if (team1 != null && team2 != null) {
                team1.CurrentElo += match.Team1Score + 5;
                team2.CurrentElo += match.Team2Score + 5;

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateTeamEloChangeEntriesAsync(Match match) {
            using var context = _dbFactory.CreateDbContext();
            var team1 = await context.Teams.FindAsync(match.Team1ID);
            var team2 = await context.Teams.FindAsync(match.Team2ID);

            if (team1 != null && team2 != null) {
                var tournamentName = await context.Tournaments
                    .Where(t => t.TournamentID == match.TournamentID)
                    .Select(t => t.TournamentName)
                    .FirstOrDefaultAsync();

                var team1EloChange = new TeamEloChange {
                    TeamID = team1.TeamID,
                    RivalTeamID = team2.TeamID,
                    MatchID = match.MatchID,
                    Date = match.MatchDate,
                    TournamentName = tournamentName,
                    CurrentElo = team1.CurrentElo,
                    EloChange = match.Team1Score + 5
                };

                var team2EloChange = new TeamEloChange {
                    TeamID = team2.TeamID,
                    RivalTeamID = team1.TeamID,
                    MatchID = match.MatchID,
                    Date = match.MatchDate,
                    TournamentName = tournamentName,
                    CurrentElo = team2.CurrentElo,
                    EloChange = match.Team2Score + 5
                };

                context.TeamEloChanges.Add(team1EloChange);
                context.TeamEloChanges.Add(team2EloChange);

                await context.SaveChangesAsync();
            }
        }
    }
}
