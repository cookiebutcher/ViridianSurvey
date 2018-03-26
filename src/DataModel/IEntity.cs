using System;

namespace ViridianCode.ViridianSurvey.DataModel
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime CreatedDate { get; set; }
    }
}