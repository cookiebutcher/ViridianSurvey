using System;
using Microsoft.EntityFrameworkCore;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class ViridianSurveyContext : DbContext
    {
        public ViridianSurveyContext(DbContextOptions<ViridianSurveyContext> options) : base(options)
        {

        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    }
}