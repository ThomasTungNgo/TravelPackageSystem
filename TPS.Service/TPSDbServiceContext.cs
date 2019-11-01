using Microsoft.EntityFrameworkCore;
using System;


namespace TPS.Service
{
    public class TPSDbServiceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            o.UseSqlServer("Data Source=localhost;Initial Catalog=TPSDb;Integrated Security=true;");
        }
    }
}
