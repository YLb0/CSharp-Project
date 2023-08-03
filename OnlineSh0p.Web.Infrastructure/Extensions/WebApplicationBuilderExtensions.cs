using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShopSystem.Data.Models;

namespace OnlineSh0p.Web.Infrastructure.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedAdministrator(this IApplicationBuilder app, string email)
        {
            using var scopedServices  = app.ApplicationServices.CreateScope();

            IServiceProvider serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async () =>
            {
                if (await roleManager.RoleExistsAsync("Administrator"))
                {
                    return;
                }

                IdentityRole<Guid> role =
                    new IdentityRole<Guid>("Administrator");

                await roleManager.CreateAsync(role);

                ApplicationUser adminUser=
                    await userManager.FindByEmailAsync(email);

                 await userManager.AddToRoleAsync(adminUser, "Administrator");
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
