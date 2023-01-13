using EventsMan.Domain.Common;

namespace EventsMan.Domain.Entities;

public class Category:AuditableEntries
{
      public Guid CategoryId { get; set; }
      public string? Name{ get; set; }
      public ICollection<Event>? Events;
}