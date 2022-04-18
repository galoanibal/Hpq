using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PRUEBA.QPH.API.Conection
{
    public class TestDbContext:DbContext
    {
        private IConfiguration _configuration;       

        public TestDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            _configuration = builder.Build();
            string connectionString = _configuration.GetConnectionString("ConecctionDbTest").ToString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
