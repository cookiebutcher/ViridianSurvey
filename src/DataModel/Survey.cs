using System;
using System.Collections.Generic;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public class Survey : IEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Question> Questions { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}