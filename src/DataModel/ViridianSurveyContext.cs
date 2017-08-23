using System;
using Microsoft.EntityFrameworkCore;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class ViridianSurveyContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./viridianSurvey.db");
        }
    }
}