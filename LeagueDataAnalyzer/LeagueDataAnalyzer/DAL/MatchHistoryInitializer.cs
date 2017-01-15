using LeagueDataAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueDataAnalyzer.DAL
{
    public class MatchHistoryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MatchHistoryContext>
    {
        protected override void Seed(MatchHistoryContext context)
        {
            int index = 1024;
            var MatchesResults = new List<MatchResult>
            {
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            new MatchResult{MatchId=index++},
            };

            MatchesResults.ForEach(mr => context.MatchesResults.Add(mr));

            context.SaveChanges();
        }
    }
}