using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PLF_11112024_Rautner.Models;

namespace PLF_11112024_Rautner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        // Table in Datenbank einfügen/erstellen
        public DbSet<GeschenkModel> GeschenkModels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}