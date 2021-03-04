using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using KP.FunOA.Configuration;
using KP.FunOA.Web;

namespace KP.FunOA.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FunOADbContextFactory : IDesignTimeDbContextFactory<FunOADbContext>
    {
        public FunOADbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FunOADbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FunOADbContextConfigurer.Configure(builder, configuration.GetConnectionString(FunOAConsts.ConnectionStringName));

            return new FunOADbContext(builder.Options);
        }
    }
}
