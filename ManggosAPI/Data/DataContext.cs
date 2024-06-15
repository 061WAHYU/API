using ManggosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ManggosAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) 
        {

        }
        public DbSet<Costumer> costumers { get; set; }
    }
}
