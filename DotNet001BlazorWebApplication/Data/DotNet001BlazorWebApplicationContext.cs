using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNet001Shared.Models;

namespace DotNet001BlazorWebApplication.Data
{
    public class DotNet001BlazorWebApplicationContext : DbContext
    {
        public DotNet001BlazorWebApplicationContext (DbContextOptions<DotNet001BlazorWebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<DotNet001Shared.Models.Product> Product { get; set; } = default!;
    }
}
