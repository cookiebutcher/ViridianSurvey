using System;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Respondent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public UserAccount CreatedBy { get; set; }
    }
}