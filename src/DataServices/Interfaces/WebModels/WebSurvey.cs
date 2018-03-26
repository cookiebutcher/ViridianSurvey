using System.ComponentModel.DataAnnotations;

namespace ViridianCode.ViridianSurvey.DataServices.Interfaces.WebModels
{
    public class WebSurvey
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string WelcomeMessage { get; set; }
        public string EndMessage { get; set; }

        public bool ShowWelcomeScreen { get; set; }

        public bool AllowBackwardNavigation { get; set; }

        public bool ShowProgressBar { get; set; }

        public bool ShowGroupName { get; set; }

        public bool ShowGroupDescription { get; set; }
    }
}
