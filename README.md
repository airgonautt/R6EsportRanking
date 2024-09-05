# R6Ranking

R6 Ranking System is a Blazor server-based CRUD application designed to track and rank professional teams and players within the Rainbow Six Siege Esports scene. The app calculates and records ratings based on match performance, allowing users to view detailed rankings and performance histories. I designed the database and Elo rating with R6 pro league in mind, but I think the project can be tailored to other competitons/sports as well.

  
## Elo Calculation

During match creation, Elo change is calculated based on the famous chess formula:

 <p align=center>
  $ΔElo=K×(W−E)$ 
 </p>

Where
  >K: Represents the maximum possible Elo adjustment in one match. This varies based on match significance (32 for best of 3+ or 65 for best of 1).

  >W: The actual result, wins awards (1) and losses (0), but if a match is decided by 1 or 2 rounds both teams gain/lose minimal elo since the close match statistically could be considered a tie (0.5)

  >E: The expected result, calculated using the Elo difference between the two teams as follows  
  > <p align=center> $E= {1\over 1+10(Elo_{opponent} −Elo_{team}​ )/500}$  </p>

### Region Elo

Each region has an aggregated Elo score for all teams within that region. This allows for cross region comparisons and provides insights (according to this ranking system) about who the current strongest regions are.

### Rivalry Tracking

You can view a history of matches between teams, including their Elo gain/loss in each encounter, total gain/loss, map bans, winrate, and operator bans


## Upcoming Features

    Team Pages: More granular statistics for each team, including performance metrics.
    Match Simulation: Simulate match outcomes based on team Elo and historical performance.


### Setup

Clone the Repository:

    git clone https://github.com/yourusername/r6-ranking-system.git
    cd r6-ranking-system

Install Prerequisites:

    .NET 6 SDK, MS SQL Server, and a code editor like Visual Studio installed.

Make sure to update the appsettings.json file with your SQL connection string:

    "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=R6EsportsDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    
Add first Migration based on project's models

    Add-Migration InitialMigration

This should create a new database on your MS SQL server that you can interact with on runtime, navegate to /regions and /teams to populate the DB before attempting to create a new match entry on the database


## Contributing

Contributions are welcome! And please contact me for any inquiries, I will respond on a timely manner


## License

This project is licensed under the MIT License - see the LICENSE file for details.
