using System;
using Microsoft.EntityFrameworkCore;
using ViridianCode.ViridianSurvey.DataModel;

namespace ViridianCode.ViridianSurvey.DatabaseContext.DataSeed
{
    public class SurveyDataSeeder
    {
        private ModelBuilder _modelBuilder;
        public SurveyDataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Survey>()
            .HasData(new Survey 
            {
                Id = 1,
                AllowBackwardNavigation = false,
                Code = "S001",
                CreatedById = 1,
                CreatedDate = new DateTime(2018, 04, 27),
                Description = "descriptionik",
                EndMessage = "end mesedzyk",
                ShowGroupDescription = false,
                ShowGroupName = false,
                ShowProgressBar = false,
                ShowWelcomeScreen = false,
                Title = "titelek",
                WelcomeMessage = "welcome mesedzyk"
            });
        }
    }
}
