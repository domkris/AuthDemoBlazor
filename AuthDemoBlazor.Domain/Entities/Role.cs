using Microsoft.AspNetCore.Identity;

namespace AuthDemoBlazor.Domain.Entities
{
    public class Role : IdentityRole<long>
    {
        public virtual ICollection<User>? Users { get; set; }
    }
}
