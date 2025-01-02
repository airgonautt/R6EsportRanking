using Microsoft.EntityFrameworkCore;
using R6Ranking.Data;
using R6Ranking.Models;

namespace R6Ranking.Services {
    public class LeaderboardService {
        private readonly IDbContextFactory<R6EsportsDbContext> _dbContextFactory;
        private List<Team> _leaderboardData = new();
        private DateTime _lastUpdated = DateTime.MinValue;

        public LeaderboardService(IDbContextFactory<R6EsportsDbContext> dbContextFactory) {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Team>> GetLeaderboardAsync() {
            if ((DateTime.UtcNow - _lastUpdated).TotalHours > 1) 
            {
                using var context = await _dbContextFactory.CreateDbContextAsync();
                _leaderboardData = await context.Teams
                    .OrderByDescending(p => p.CurrentElo)
                    .Take(10)
                    .ToListAsync();
                _lastUpdated = DateTime.UtcNow;
            }

            return _leaderboardData;
        }
    }

}
