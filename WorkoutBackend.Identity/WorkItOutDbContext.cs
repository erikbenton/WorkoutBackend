using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WorkoutBackend.Identity;

public class WorkItOutDbContext(DbContextOptions<WorkItOutDbContext> options) : IdentityDbContext(options)
{
}
