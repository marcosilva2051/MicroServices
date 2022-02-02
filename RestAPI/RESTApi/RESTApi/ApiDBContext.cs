using Microsoft.EntityFrameworkCore;
using RESTApi.Model;

namespace RESTApi
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }
        DbSet<Person> Persons { get; set; }
    }
}
