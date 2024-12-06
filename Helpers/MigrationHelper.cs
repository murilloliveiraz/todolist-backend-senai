using todolist_backend_senai.Contexts;
using Microsoft.EntityFrameworkCore;

namespace todolist_backend_senai.Helpers
{
    public static class MigrationHelper
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using ApplicationContext context =
                scope.ServiceProvider.GetRequiredService<ApplicationContext>();

            try
            {
                context.Database.Migrate();
                Console.WriteLine("Migrations applied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error applying migrations: {ex.Message}");
            }
        }
    }
}
