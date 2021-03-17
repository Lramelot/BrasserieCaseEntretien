using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace WebApi.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
                : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<Devis> Devis { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CodeFirstUpdateConnetionString);
        }

        private static string _codeFirstUpdateConnetionString;

        private static string CodeFirstUpdateConnetionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_codeFirstUpdateConnetionString))
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();

                    _codeFirstUpdateConnetionString = config.GetSection("ConnectionStrings")["ApiDbConnection"];
                }
                return _codeFirstUpdateConnetionString;
            }
        }
    }
}
