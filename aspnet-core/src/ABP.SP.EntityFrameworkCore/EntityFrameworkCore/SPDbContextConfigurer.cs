using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ABP.SP.EntityFrameworkCore;

public static class SPDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<SPDbContext> builder, string connectionString)
    {
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public static void Configure(DbContextOptionsBuilder<SPDbContext> builder, DbConnection connection)
    {
        builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString));
    }
}