using LeagueDataAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeagueDataAnalyzer.DAL
{
    public class MatchHistoryContext : DbContext
    {
        public MatchHistoryContext() : base("MatchHistoryContext")
        {
        }

        public DbSet<MatchResult> MatchesResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}