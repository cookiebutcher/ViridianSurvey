using System;
using System.ComponentModel.DataAnnotations;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Question
    {
        public int Id { get; set; }      

        public Survey Survey { get; set; }

        public Question ParentQuestion { get; set; }

        [Required]
        public string Code { get; set; }

        public string QuestionText { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Order { get; set; }

        public bool Mandatory { get; set; }

        [Required]
        public int Scale { get; set; }

        public string Relevance { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public UserAccount CreatedBy { get; set; }
    }
}