using System;

namespace SC.Service.Data.Model.Contracts
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
