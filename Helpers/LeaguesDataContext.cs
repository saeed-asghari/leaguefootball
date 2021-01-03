using LeagueFootball.Entities;
using Microsoft.EntityFrameworkCore;
 using System;
namespace LeagueFootball.Helpers
{
    public class LeaguesDataContext : DbContext
    {

        public LeaguesDataContext(DbContextOptions<LeaguesDataContext> opt) : base(opt)
        {

        }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            modelBuilder.Entity<League>()
                .HasMany(e => e.Teams);
            
            modelBuilder.Entity<Team>()
                .HasMany(e => e.Players);



           // LeagueSeed
            modelBuilder.Entity<League>().HasData(new League {LeagueID = 1,Name = "لیگ برتر", FoundingDate = DateTime.ParseExact("2001-03-02","yyyy-MM-dd",null)});
            modelBuilder.Entity<League>().HasData(new League {LeagueID = 2,Name = "لیگ آزادگان", FoundingDate = DateTime.ParseExact("2001-03-02","yyyy-MM-dd",null)});
           

            modelBuilder.Entity<Team>().HasData(new Team {TeamId=1 ,LeagueID = 1,Name = "پرسپولیس", FoundingDate = DateTime.ParseExact("2001-03-02","yyyy-MM-dd",null),Players = null});
            modelBuilder.Entity<Team>().HasData(new Team {TeamId=2,LeagueID = 1,Name = "استقلال", FoundingDate = DateTime.ParseExact("2001-03-02","yyyy-MM-dd",null),Players = null });
            modelBuilder.Entity<Team>().HasData(new Team {TeamId=3,LeagueID = 2,Name = "تیم دسته دو", FoundingDate = DateTime.ParseExact("2001-03-02","yyyy-MM-dd",null),Players = null});

            modelBuilder.Entity<Player>().HasData(new Player {PlayerId=1,TeamId=1,FirstName = "سیدجلال ",LastName="حسینی", DateOfBirth = DateTime.ParseExact("1980-03-02","yyyy-MM-dd",null)});
            modelBuilder.Entity<Player>().HasData(new Player {PlayerId=2,TeamId=2,FirstName = "وریا ",LastName="غفوری" ,DateOfBirth = DateTime.ParseExact("1980-03-02","yyyy-MM-dd",null)});
            modelBuilder.Entity<Player>().HasData(new Player {PlayerId=3,TeamId=3,FirstName = "علی ",LastName="محمدی", DateOfBirth = DateTime.ParseExact("1980-03-02","yyyy-MM-dd",null)});



            modelBuilder.Entity<User>().HasData(new User {Id=1, FirstName = "Saeed", LastName = "As", Username = "test", Password = "test" });
    

          

        }
    }
}