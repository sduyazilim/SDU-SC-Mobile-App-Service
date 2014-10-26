using System;

namespace SC.Service.Data.Model.Contracts
{
    public interface IUpdateTrackable
    {
        DateTime UpdatedOn { get; set; }
        string UpdatedBy { get; set; }
    }
}
