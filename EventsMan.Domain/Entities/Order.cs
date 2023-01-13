using EventsMan.Domain.Common;

namespace EventsMan.Domain.Entities;

public class Order : AuditableEntries
{
  public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
    public bool OrderPaid { get; set; }
    
}