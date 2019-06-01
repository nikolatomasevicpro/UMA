using System;

namespace UMA.Domain.Common.Interfaces
{
    public interface ITracker
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
