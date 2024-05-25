using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NET.Model.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
    }
}
