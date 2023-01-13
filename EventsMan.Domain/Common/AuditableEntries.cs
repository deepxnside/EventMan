namespace EventsMan.Domain.Common;

public class AuditableEntries
{
   public  string? CreatedBy { get; set; }
   public DateTime CreatedDate { get; set; }
   public string? LastModifiedBy { get;set; }
   public DateTime LastModifiedDate { get; set; }
}