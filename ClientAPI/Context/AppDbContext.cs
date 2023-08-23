using ClientAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Context
{
    public class AppDbContext : DbContext
    {
        DbSet<Client>? Clients { get; set; }
    }
}
