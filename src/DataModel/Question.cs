﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Question : IEntity
    {
        public int Id { get; set; }

        [Required]
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }

        public int? ParentQuestionId { get; set; }

        public virtual Question ParentQuestion { get; set; }

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