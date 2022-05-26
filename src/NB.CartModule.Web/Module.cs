using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using NB.CartModule.Core;
using NB.CartModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Core.Security;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.CartModule.Data.Repositories;
using VirtoCommerce.Platform.Core.Common;
using NB.CartModule.Core.Models;
using NB.CartModule.Data.Models;
using VirtoCommerce.CartModule.Data.Model;
using VirtoCommerce.CartModule.Core.Model;

namespace NB.CartModule.Web
{
    public class Module : IModule
    {
        public ManifestModuleInfo ModuleInfo { get; set; }

        public void Initialize(IServiceCollection serviceCollection)
        {
            AbstractTypeFactory<LineItem>.OverrideType<LineItem, NBCartLineItem>().MapToType<NBCartLineItemEntity>();
            AbstractTypeFactory<LineItemEntity>.OverrideType<LineItemEntity, NBCartLineItemEntity>();


            // database initialization
            var configuration = serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("VirtoCommerce.CartModuleModule") ?? configuration.GetConnectionString("VirtoCommerce");
            serviceCollection.AddDbContext<NBCartDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddTransient<ICartRepository, NBCartRepository>();
        }

        public void PostInitialize(IApplicationBuilder appBuilder)
        {
            // register settings
            var settingsRegistrar = appBuilder.ApplicationServices.GetRequiredService<ISettingsRegistrar>();
            settingsRegistrar.RegisterSettings(ModuleConstants.Settings.AllSettings, ModuleInfo.Id);

            // register permissions
            var permissionsProvider = appBuilder.ApplicationServices.GetRequiredService<IPermissionsRegistrar>();
            permissionsProvider.RegisterPermissions(ModuleConstants.Security.Permissions.AllPermissions.Select(x =>
                new Permission()
                {
                    GroupName = "CartModuleModule",
                    ModuleId = ModuleInfo.Id,
                    Name = x
                }).ToArray());



            // Ensure that any pending migrations are applied
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<NBCartDbContext>())
                {
                    dbContext.Database.EnsureCreated();
                    dbContext.Database.Migrate();
                }
            }
        }

        public void Uninstall()
        {
            // do nothing in here
        }
    }
}
