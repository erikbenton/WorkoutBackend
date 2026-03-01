using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WorkoutBackend.Identity;

public class WorkItOutDbContext : IdentityDbContext
{
    public WorkItOutDbContext(DbContextOptions<WorkItOutDbContext> options) : base(options)
    {
        
    }
}
