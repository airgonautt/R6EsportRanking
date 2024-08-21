using R6Ranking.Data;
using static System.Formats.Asn1.AsnWriter;

namespace R6Ranking.Models {
    public class Match {

        public int MatchID { get; set; }
        public string MatchName { get; set; }

        public required int Team1ID { get; set; }
        public required Team Team1 { get; set; }
        public int Team1Score { get; set; }
        public TeamEloHistory? Team1EloHistory { get; set; }

        public required int Team2ID { get; set; }
        public required Team Team2 { get; set; }
        public int Team2Score { get; set; }
        public TeamEloHistory? Team2EloHistory { get; set; }

        public required string TournamentID { get; set; }
        public required Tournament Tournament { get; set; }

        public DateTime MatchDate { get; set; }

        public ICollection<PlayerEloHistory>? PlayerEloHistories { get; set; }
        public ICollection<TeamEloHistory>? TeamEloHistories { get; set; }

        public void GenerateMatchName() {
            if (Team1 != null && Team2 != null) {
                MatchName = $"{Team1.TeamName} vs {Team2.TeamName}";
            }
        }

        // runs Elo algorithm and update teams EloHistory 
        public async Task CalculateAndUpdateElo() {

            decimal expectedScoreA = 1.0M / (1.0M + (decimal)Math.Pow(10, (double)(Team2.CurrentElo - Team1.CurrentElo) / 400.0));
            decimal expectedScoreB = 1.0M / (1.0M + (decimal)Math.Pow(10, (double)(Team1.CurrentElo - Team2.CurrentElo) / 400.0));

            int roundDifference = Math.Abs(Team1Score - Team2Score);
            int K;

            if (roundDifference <= 2) // Tie
            {
                K = 20;
            }
            else if (roundDifference <= 5) // Normal win
            {
                K = 45;
            }
            else // Blowout
            {
                K = 75;
            }

            //returns 1 or 0 to the team with highest amount of rounds won
            double actualScoreA = Team1Score > Team2Score ? 1 : (Team1Score < Team2Score ? 0 : 0.5);
            double actualScoreB = 1 - actualScoreA;

            decimal newEloA = Team1.CurrentElo + K * (Team1Score - expectedScoreA);
            decimal newEloB = Team2.CurrentElo + K * (Team2Score - expectedScoreB);

            // Update teams' Elo
            Team1.CurrentElo = newEloA;
            Team2.CurrentElo = newEloB;

            // Create new TeamElohistory entries
            using (var context = new R6EsportsDbContext()) {

                TeamEloHistory historyA = new TeamEloHistory {
                    TeamID = Team1ID,
                    RivalTeamName = Team2.TeamName,
                    RivalTeamID = Team2.TeamID,
                    EloChange = K * (Team1Score - expectedScoreA),
                    CurrentElo = Team1.CurrentElo,
                    MatchID = this.MatchID,
                    TournamentName = this.Tournament.Name,
                    Date = DateTime.Now
                };

                TeamEloHistory historyB = new TeamEloHistory {
                    TeamID = Team2ID,
                    RivalTeamName = Team1.TeamName,
                    RivalTeamID = Team1.TeamID,
                    EloChange = K * (Team2Score - expectedScoreB),
                    MatchID = this.MatchID,
                    TournamentName = this.Tournament.Name,
                    Date = DateTime.Now
                };

                await context.SaveChangesAsync();
            }
        }
    }
}
