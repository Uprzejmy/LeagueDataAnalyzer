using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LeagueDataAnalyzer.Models
{
    public class MatchResult
    {
        [Key]
        public int ID { get; set; }
        public int MatchId { get; set; }
        // public string date { get; set; }
        // public string FirstMidName { get; set; }
        // public DateTime EnrollmentDate { get; set; }

        // public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}