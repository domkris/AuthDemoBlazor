using AuthDemoBlazor.Domain.Entities;

namespace AuthDemoBlazor.Domain.Audit
{
    public interface IAuditableEntity
    {
        long? CreatedById { get; set; }
        User? CreatedBy { get; set; }
        long ? ModifiedById { get; set; }
        User? ModifiedBy { get; set; }
        DateTimeOffset? CreatedAt { get; set; }
        DateTimeOffset? ModifiedAt { get; set; }
    }
}
