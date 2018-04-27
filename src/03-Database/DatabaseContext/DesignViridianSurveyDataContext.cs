using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ViridianCode.ViridianSurvey.DatabaseContext
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ViridianSurveyContext>
    {
        private static IConfigurationRoot _configuration;
        const string ConnectionSecretName = "ViridianConnectionStringSecret";        

        public ViridianSurveyContext CreateDbContext(string[] args)
        {
            BootstrapConfiguration();
            var connectionString = _configuration[ConnectionSecretName];
                
            var builder = new DbContextOptionsBuilder<ViridianSurveyContext>();                
    
            builder.UseSqlServer(connectionString);
    
            return new ViridianSurveyContext(builder.Options);
        }

        private static void BootstrapConfiguration()
        {           
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TemporaryDbContextFactory>();

            _configuration = builder.Build();
        }
    }
}