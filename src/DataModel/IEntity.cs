using System;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public interface IEntity
    {
        int Id { get; set; } //test
        DateTime CreatedDate { get; set; }
        UserAccount CreatedBy { get; set; }
    }
}