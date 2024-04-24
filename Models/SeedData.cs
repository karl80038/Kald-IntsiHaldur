using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kald_IntsiHaldur.Data;
using System;
using System.Linq;
namespace Kald_IntsiHaldur.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Kald_IntsiHaldurContext(
                serviceProvider.GetRequiredService<DbContextOptions<Kald_IntsiHaldurContext>>()))
            {
                if (context.Incident.Any())
                {
                    return;
                }
                context.SaveChanges();
            }
        }
    }
}



