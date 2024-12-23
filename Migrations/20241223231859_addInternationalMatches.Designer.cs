﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using R6Ranking.Data;

#nullable disable

namespace R6Ranking.Migrations
{
    [DbContext(typeof(R6EsportsDbContext))]
    [Migration("20241223231859_addInternationalMatches")]
    partial class addInternationalMatches
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("R6Ranking.Models.Map", b =>
                {
                    b.Property<int>("MapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MapID"));

                    b.Property<string>("MapName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MapPhoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MapID");

                    b.ToTable("Map");

                    b.HasData(
                        new
                        {
                            MapID = 100,
                            MapName = "DefaultMap"
                        },
                        new
                        {
                            MapID = 1,
                            MapName = "Bank"
                        },
                        new
                        {
                            MapID = 2,
                            MapName = "Border"
                        },
                        new
                        {
                            MapID = 3,
                            MapName = "Chalet"
                        },
                        new
                        {
                            MapID = 4,
                            MapName = "Clubhouse"
                        },
                        new
                        {
                            MapID = 5,
                            MapName = "Consulate"
                        },
                        new
                        {
                            MapID = 6,
                            MapName = "Kafe Dostoyevksy"
                        },
                        new
                        {
                            MapID = 7,
                            MapName = "Lair"
                        },
                        new
                        {
                            MapID = 8,
                            MapName = "Nighthaven Labs"
                        },
                        new
                        {
                            MapID = 9,
                            MapName = "Oregon"
                        },
                        new
                        {
                            MapID = 10,
                            MapName = "Skyscraper"
                        },
                        new
                        {
                            MapID = 11,
                            MapName = "Theme Park"
                        },
                        new
                        {
                            MapID = 12,
                            MapName = "Villa"
                        });
                });

            modelBuilder.Entity("R6Ranking.Models.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchID"));

                    b.Property<int>("MapID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MatchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Team1Ban1")
                        .HasColumnType("int");

                    b.Property<int>("Team1Ban2")
                        .HasColumnType("int");

                    b.Property<int>("Team1ID")
                        .HasColumnType("int");

                    b.Property<int>("Team1Score")
                        .HasColumnType("int");

                    b.Property<int>("Team2Ban1")
                        .HasColumnType("int");

                    b.Property<int>("Team2Ban2")
                        .HasColumnType("int");

                    b.Property<int>("Team2ID")
                        .HasColumnType("int");

                    b.Property<int>("Team2Score")
                        .HasColumnType("int");

                    b.Property<int>("TournamentID")
                        .HasColumnType("int");

                    b.Property<bool>("isBo3")
                        .HasColumnType("bit");

                    b.Property<bool>("isInternational")
                        .HasColumnType("bit");

                    b.HasKey("MatchID");

                    b.HasIndex("MapID");

                    b.HasIndex("Team1ID");

                    b.HasIndex("Team2ID");

                    b.HasIndex("TournamentID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("R6Ranking.Models.OperatorBan", b =>
                {
                    b.Property<int>("OperatorBanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OperatorBanID"));

                    b.Property<string>("OperatorLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatorSide")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OperatorBanID");

                    b.ToTable("OperatorBans");
                });

            modelBuilder.Entity("R6Ranking.Models.OriginCountry", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryID"));

                    b.Property<string>("CountryFlag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("R6Ranking.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"));

                    b.Property<string>("CardURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateJoined")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLeft")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlavorText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OriginCountryCountryID")
                        .HasColumnType("int");

                    b.Property<string>("PhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkillRating")
                        .HasColumnType("int");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("OriginCountryCountryID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("R6Ranking.Models.Region", b =>
                {
                    b.Property<string>("RegionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RegionID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("R6Ranking.Models.RegionEloChange", b =>
                {
                    b.Property<int>("RegionEloHistoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionEloHistoryID"));

                    b.Property<DateTime>("ChangeDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentElo")
                        .HasColumnType("int");

                    b.Property<int>("EloChange")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RegionEloHistoryID");

                    b.HasIndex("RegionID");

                    b.ToTable("RegionEloChanges");
                });

            modelBuilder.Entity("R6Ranking.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<int>("CurrentElo")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.HasIndex("RegionID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("R6Ranking.Models.TeamEloChange", b =>
                {
                    b.Property<int>("TeamEloChangeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamEloChangeID"));

                    b.Property<int>("CurrentElo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EloChange")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RivalTeamID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("TeamEloChangeID");

                    b.HasIndex("RivalTeamID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamEloChanges");
                });

            modelBuilder.Entity("R6Ranking.Models.TeamOperatorBan", b =>
                {
                    b.Property<int>("TeamOperatorBanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamOperatorBanID"));

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("OperatorBanID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("TeamOperatorBanID");

                    b.HasIndex("MatchId");

                    b.HasIndex("OperatorBanID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamOperatorBans");
                });

            modelBuilder.Entity("R6Ranking.Models.Tournament", b =>
                {
                    b.Property<int>("TournamentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TournamentID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TournamentLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournamentLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TournamentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WinnerTeamID")
                        .HasColumnType("int");

                    b.HasKey("TournamentID");

                    b.HasIndex("RegionID");

                    b.HasIndex("WinnerTeamID");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("R6Ranking.Models.Trophy", b =>
                {
                    b.Property<int>("TrophyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrophyID"));

                    b.Property<int>("TournamentID")
                        .HasColumnType("int");

                    b.Property<string>("TrophyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrophyPhotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrophyID");

                    b.HasIndex("TournamentID")
                        .IsUnique();

                    b.ToTable("Trophies");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("TournamentID")
                        .HasColumnType("int");

                    b.HasKey("TeamID", "TournamentID");

                    b.HasIndex("TournamentID");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("R6Ranking.Models.Match", b =>
                {
                    b.HasOne("R6Ranking.Models.Map", "Map")
                        .WithMany("Matches")
                        .HasForeignKey("MapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.Team", "Team1")
                        .WithMany("MatchesAsTeam1")
                        .HasForeignKey("Team1ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.Team", "Team2")
                        .WithMany("MatchesAsTeam2")
                        .HasForeignKey("Team2ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.Tournament", "Tournament")
                        .WithMany()
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Map");

                    b.Navigation("Team1");

                    b.Navigation("Team2");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("R6Ranking.Models.Player", b =>
                {
                    b.HasOne("R6Ranking.Models.OriginCountry", "OriginCountry")
                        .WithMany("CountryPlayers")
                        .HasForeignKey("OriginCountryCountryID");

                    b.HasOne("R6Ranking.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID");

                    b.Navigation("OriginCountry");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("R6Ranking.Models.RegionEloChange", b =>
                {
                    b.HasOne("R6Ranking.Models.Region", "Region")
                        .WithMany("RegionEloHistory")
                        .HasForeignKey("RegionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("R6Ranking.Models.Team", b =>
                {
                    b.HasOne("R6Ranking.Models.Region", "Region")
                        .WithMany("Teams")
                        .HasForeignKey("RegionID");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("R6Ranking.Models.TeamEloChange", b =>
                {
                    b.HasOne("R6Ranking.Models.Team", "RivalTeam")
                        .WithMany()
                        .HasForeignKey("RivalTeamID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("R6Ranking.Models.Team", "Team")
                        .WithMany("TeamEloHistory")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("RivalTeam");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("R6Ranking.Models.TeamOperatorBan", b =>
                {
                    b.HasOne("R6Ranking.Models.Match", "Match")
                        .WithMany("TeamOperatorBans")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.OperatorBan", "OperatorBan")
                        .WithMany()
                        .HasForeignKey("OperatorBanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.Team", "Team")
                        .WithMany("TeamOperatorBans")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("OperatorBan");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("R6Ranking.Models.Tournament", b =>
                {
                    b.HasOne("R6Ranking.Models.Region", "Region")
                        .WithMany("Tournaments")
                        .HasForeignKey("RegionID");

                    b.HasOne("R6Ranking.Models.Team", "WinnerTeam")
                        .WithMany()
                        .HasForeignKey("WinnerTeamID");

                    b.Navigation("Region");

                    b.Navigation("WinnerTeam");
                });

            modelBuilder.Entity("R6Ranking.Models.Trophy", b =>
                {
                    b.HasOne("R6Ranking.Models.Tournament", "Tournament")
                        .WithOne("Trophy")
                        .HasForeignKey("R6Ranking.Models.Trophy", "TournamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.HasOne("R6Ranking.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("R6Ranking.Models.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("R6Ranking.Models.Map", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("R6Ranking.Models.Match", b =>
                {
                    b.Navigation("TeamOperatorBans");
                });

            modelBuilder.Entity("R6Ranking.Models.OriginCountry", b =>
                {
                    b.Navigation("CountryPlayers");
                });

            modelBuilder.Entity("R6Ranking.Models.Region", b =>
                {
                    b.Navigation("RegionEloHistory");

                    b.Navigation("Teams");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("R6Ranking.Models.Team", b =>
                {
                    b.Navigation("MatchesAsTeam1");

                    b.Navigation("MatchesAsTeam2");

                    b.Navigation("Players");

                    b.Navigation("TeamEloHistory");

                    b.Navigation("TeamOperatorBans");
                });

            modelBuilder.Entity("R6Ranking.Models.Tournament", b =>
                {
                    b.Navigation("Trophy");
                });
#pragma warning restore 612, 618
        }
    }
}
