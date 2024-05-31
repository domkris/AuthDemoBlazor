using Microsoft.AspNetCore.Identity;

namespace AuthDemoBlazor.Domain.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
