using Microsoft.EntityFrameworkCore;
using CalculadoraNotaFIAP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CalculadoraNotaFIAP.DataBase
{
    public class CalculadoraContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Nota> Nota { get; set; }
        public CalculadoraContext(DbContextOptions options) : base(options) { }
    }
}