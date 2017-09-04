using System;
using System.Collections.Generic;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class UserAccount : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserAccount CreatedBy { get; set; }
    }
}