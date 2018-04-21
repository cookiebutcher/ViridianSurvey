using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ViridianCode.ViridianSurvey.DatabaseContext
{
    public class ViridianSurveyContextFactory : IDesignTimeDbContextFactory<ViridianSurveyContext>
    {
        public ViridianSurveyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ViridianSurveyContext>();
            //string connectionString = ConfigurationExtensions.GetConnectionString(this.Configuration, "ViridianSurveysConnection");
            //optionsBuilder.UseSqlServer("");

            return new ViridianSurveyContext(optionsBuilder.Options);
        }
    }
}