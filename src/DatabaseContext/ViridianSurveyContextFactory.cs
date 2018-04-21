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
            optionsBuilder.UseSqlServer("Server=localhost;Database=Viridian2;User Id=sa;Password=Blueye21;");

            return new ViridianSurveyContext(optionsBuilder.Options);
        }
    }
}