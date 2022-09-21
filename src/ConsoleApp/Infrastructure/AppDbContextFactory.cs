using ConsoleApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace ConsoleApp.Infrastructure
{
    public static class AppDbContextFactory
    {
        public static AppDbContext Create(DbConnection connection)
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connection);
            return new AppDbContext(builder.Options);
        }
    }
}
