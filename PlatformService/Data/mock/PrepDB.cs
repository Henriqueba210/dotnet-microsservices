using PlatformService.Models;

namespace PlatformService.Data.Mock
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }

        }

        private static void SeedData(AppDbContext? context)
        {
            if (!(context!.Platforms.Any()))
            {
                Console.WriteLine("Seeding data...");
                context.Platforms.AddRange(
                    new Platform { Name = "DotNet", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Java", Publisher = "Oracle", Cost = "Free" },
                    new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
                Console.WriteLine("Seeding complete.");
            }
            else
            {
                Console.WriteLine("Platforms already exist in the database.");
            }
        }
    }
}
