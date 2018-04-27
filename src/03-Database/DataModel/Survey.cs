using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Survey
    {
        #region General properties
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string WelcomeMessage { get; set; }
        
        public string EndMessage { get; set; }
        
        public List<Question> Questions { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        
        public int CreatedById { get; set; }

        [Required]
        public UserAccount CreatedBy { get; set; }
        #endregion

        #region Presentation properties
        [Required]
        public bool ShowWelcomeScreen { get; set; }
        
        [Required]
        public bool AllowBackwardNavigation { get; set; }
        
        [Required]
        public bool ShowProgressBar { get; set; }
        
        [Required]
        public bool ShowGroupName { get; set; }
        
        [Required]
        public bool ShowGroupDescription { get; set; }
        #endregion
    }
}