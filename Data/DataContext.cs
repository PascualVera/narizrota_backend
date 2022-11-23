using LaBestiaNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LaBestiaNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
