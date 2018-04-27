using System;
using Microsoft.EntityFrameworkCore;
using ViridianCode.ViridianSurvey.DataModel;

namespace ViridianCode.ViridianSurvey.DatabaseContext.DataSeed
{
    public class UserAccountDataSeeder
    {
        private ModelBuilder _modelBuilder;
        public UserAccountDataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<UserAccount>()
            .HasData(new UserAccount 
            {
                Id = 1,
                IsActive = true,
                UserName = "admin",
                FirstName = "Janusz",
                LastName = "Testów",
                Email = "janusz@testow.com",
                CreatedDate = new DateTime(2018, 04, 27)
            });
        }
    }
}
