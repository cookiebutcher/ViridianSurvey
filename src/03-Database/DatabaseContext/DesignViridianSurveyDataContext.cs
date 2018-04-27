using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.Migrations
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<ViridianSurveyContext>
    {
        private static IConfigurationRoot Configuration;
        const string ConnectionSecretName = "ViridianConnectionStringSecret";        

        public ViridianSurveyContext CreateDbContext(string[] args)
        {
            BootstrapConfiguration();
            var connectionString = Configuration[ConnectionSecretName];
                
            var builder = new DbContextOptionsBuilder<ViridianSurveyContext>();                
    
            builder.UseSqlServer(connectionString);
    
            return new ViridianSurveyContext(builder.Options);
        }

        private static void BootstrapConfiguration()
        {           
            var builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TemporaryDbContextFactory>();

            Configuration = builder.Build();
        }
    }
}