using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Services;

namespace Security.Duende.Identity.Server.Migration.Function.Functions
{
    public class MigrationDurableFunction
    {
        private readonly IMigrationService migrationService;

        public MigrationDurableFunction(IMigrationService migrationService)
            => this.migrationService = migrationService;

        [Function("MigrationDurableFunction_HttpStart")]
        public async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Admin, "post", Route = "v1/user/migrate"),] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("MigrationDurableFunction_HttpStart");

            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                nameof(RunMigrateUsersOrchestrationAsync));

            logger.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

            return client.CreateCheckStatusResponse(req, instanceId);
        }

        [Function(nameof(RunMigrateUsersOrchestrationAsync))]
        public async Task<List<string>> RunMigrateUsersOrchestrationAsync(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            ILogger logger = context.CreateReplaySafeLogger(nameof(MigrationDurableFunction));
            
            var outputs = new List<string>
            {
                await context.CallActivityAsync<string>(nameof(MigrateUsersAsync)),
                await context.CallActivityAsync<string>(nameof(MigratePersistentGrantAsync)),
                await context.CallActivityAsync<string>(nameof(ConfigurationDbGrantAsync))
            };

            return outputs;
        }

        [Function(nameof(MigrateUsersAsync))]
        public async Task<string> MigrateUsersAsync([ActivityTrigger] string name, FunctionContext executionContext)
        {
            try
            {
                await migrationService.UpdateUserDatabaseAsync();

                return "Users migrated!";
            }
            catch (Exception e)
            {
                return $"User migration failed: {e.Message}";
            }
        }

        [Function(nameof(MigratePersistentGrantAsync))]
        public async Task<string> MigratePersistentGrantAsync([ActivityTrigger] string name, FunctionContext executionContext)
        {
            try
            {
                await migrationService.UpdatePersistentGrantDatabaseAsync();

                return "Persistent grant migrated!";
            }
            catch (Exception e)
            {
                return $"Persistent migration failed: {e.Message}";
            }
        }

        [Function(nameof(ConfigurationDbGrantAsync))]
        public async Task<string> ConfigurationDbGrantAsync([ActivityTrigger] string name, FunctionContext executionContext)
        {
            try
            {
                await migrationService.UpdateConfigurationDatabaseAsync();

                return "Configuration migrated!";
            }
            catch (Exception e)
            {
                return $"Configuration migration failed: {e.Message}";
            }
        }
    }
}
