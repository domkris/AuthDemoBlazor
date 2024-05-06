using AuthDemoBlazor.Domain.Audit;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AuthDemoBlazor.Domain.Entities
{
    public class User : IdentityUser<long>, IAuditableEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public long RoleId { get; set; }
        public Role? Role { get; set; }

        public bool IsActive {get; set;}
        public long? CreatedById { get; set; }
        public long? ModifiedById { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? ModifiedAt { get; set; }
        public User? CreatedBy { get; set; }
        public User? ModifiedBy { get; set; }
    }
}
