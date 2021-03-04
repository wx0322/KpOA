using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace KP.FunOA.EntityFrameworkCore
{
    public static class FunOADbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FunOADbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FunOADbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
