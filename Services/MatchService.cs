using R6Ranking.Data;
using R6Ranking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace R6Ranking.Services {
    public class MatchService {
        private readonly R6EsportsDbContext _context;

        public MatchService(R6EsportsDbContext context) {
            _context = context;
        }

        public async Task CalculateEloAsync(Match match) {
            // Save the new match to the database
            _context.Matches.Add(match);
            await _context.SaveChangesAsync();

            // Fetch participating teams from the database
            var team1 = await _context.Teams.FindAsync(match.Team1ID);
            var team2 = await _context.Teams.FindAsync(match.Team2ID);

            if (team1 != null && team2 != null) {
                // Calculate Elo ratings
                CalculateElo(team1, team2, match.Team1Score, match.Team2Score);

                // Save updated Elo ratings
                _context.Teams.Update(team1);
                _context.Teams.Update(team2);
                await _context.SaveChangesAsync();
            }
        }

        private void CalculateElo(Team team1, Team team2, int scoreTeam1, int scoreTeam2) {
            // Basic Elo rating calculation logic
            const int K = 32; // K-factor, which determines the maximum change in rating

            double expectedScoreTeam1 = 1.0 / (1.0 + Math.Pow(10, (int)(team2.CurrentElo - team1.CurrentElo) / 400.0));
            double expectedScoreTeam2 = 1.0 / (1.0 + Math.Pow(10, (int)(team1.CurrentElo - team2.CurrentElo) / 400.0));

            double actualScoreTeam1 = scoreTeam1 > scoreTeam2 ? 1 : (scoreTeam1 < scoreTeam2 ? 0 : 0.5);
            double actualScoreTeam2 = scoreTeam2 > scoreTeam1 ? 1 : (scoreTeam2 < scoreTeam1 ? 0 : 0.5);

            team1.CurrentElo += (int)(K * (actualScoreTeam1 - expectedScoreTeam1));
            team2.CurrentElo += (int)(K * (actualScoreTeam2 - expectedScoreTeam2));
        }
    }
}
