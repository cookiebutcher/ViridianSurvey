using System;
using Microsoft.EntityFrameworkCore;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DatabaseContext.DataSeed;

namespace ViridianCode.ViridianSurvey.DatabaseContext
{
    public class ViridianSurveyContext : DbContext
    {    
        private UserAccountDataSeeder _userAccountDataSeeder;
        private SurveyDataSeeder _surveyDataSeeder;
        public ViridianSurveyContext(DbContextOptions<ViridianSurveyContext> options) : base(options)
        {}
        
        public DbSet<Question> Questions { get; set; }

        public DbSet<Respondent> Respondents { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _userAccountDataSeeder = new UserAccountDataSeeder(modelBuilder);
            _surveyDataSeeder = new SurveyDataSeeder(modelBuilder);
            _userAccountDataSeeder.Seed();
            _surveyDataSeeder.Seed();
        }
    }
}