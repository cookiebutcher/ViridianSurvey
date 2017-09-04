using System;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public int? ParentQuestionId { get; set; }
        public virtual Question ParentQuestion { get; set; }
        public string Code { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public bool Mandatory { get; set; }
        public int Scale { get; set; }
        public string Relevance { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserAccount CreatedBy { get; set; }
    }
}