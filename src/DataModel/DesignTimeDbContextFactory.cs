using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ViridianSurveyContext>
    {
        public ViridianSurveyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ViridianSurveyContext>();   
            builder.UseSqlite("Filename=./viridianSurvey.db");
    
            return new ViridianSurveyContext(builder.Options);
        }
    }
}