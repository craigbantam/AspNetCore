using Microsoft.EntityFrameworkCore;
using Sandbox.Data;

namespace Sandbox.Web.StartupServices
{
    public class MigrationStartupService
    {
        private readonly HomeItemsDbContext _dbContext;
        private readonly ILogger<MigrationStartupService> _logger;

        public MigrationStartupService(HomeItemsDbContext dbContext, ILogger<MigrationStartupService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task Init()
        {
            try
            {
                _dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));

                await _dbContext.Database.MigrateAsync();                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while migrating the database");
                throw;
            }
        }
    }
}
