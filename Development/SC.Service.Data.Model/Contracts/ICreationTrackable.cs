using System;

namespace SC.Service.Data.Model.Contracts
{
    public interface ICreationTrackable
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
    }
}
