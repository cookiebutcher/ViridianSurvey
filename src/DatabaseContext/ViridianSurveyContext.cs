using Microsoft.EntityFrameworkCore;
using ViridianCode.ViridianSurvey.DataModel;

namespace ViridianCode.ViridianSurvey.DatabaseContext
{
    public class ViridianSurveyContext : DbContext
    {    
        public ViridianSurveyContext(DbContextOptions<ViridianSurveyContext> options) : base(options)
        {}
        
        public DbSet<Question> Questions { get; set; }

        public DbSet<Respondent> Respondents { get; set; }

        public DbSet<Survey> Surveys { get; set; }
        
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}