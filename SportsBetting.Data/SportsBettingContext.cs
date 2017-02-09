using System.ComponentModel.DataAnnotations.Schema;
using SportsBetting.Models;

namespace SportsBetting.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportsBettingContext : DbContext
    {

        public SportsBettingContext()
            : base("name=SportsBettingContext")
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Odd> Odds { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<SportEvent> SportEvents { get; set; }

        public static SportsBettingContext Create()
        {
            return new SportsBettingContext();
        }

        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}


