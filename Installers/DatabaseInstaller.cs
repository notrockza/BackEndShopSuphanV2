using Microsoft.EntityFrameworkCore;
using ShopSuphan.Models;

namespace ShopSuphan.Installers
{
    public class DatabaseInstaller : IInstallers
    {
        public void InstallServices(WebApplicationBuilder builder)
        {

            var connectionString = builder.Configuration.GetConnectionString("DatabaseContext");
            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connectionString)
            );

        }
    }
}
