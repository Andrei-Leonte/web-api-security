using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;
using Security.Duende.Identity.Server.Migration.Application.Dtos;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers;
using Security.Duende.Identity.Server.Migration.Application.Services;

namespace Security.Duende.Identity.Server.Migration.Function.Functions
{
    public class UserSeedMigrationDurableFunction
    {
        private readonly IUserSeedManager userSeedManager;

        [Function("UserSeedMigrationDurableFunction_HttpStart")]
        public static async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("UserSeedMigrationDurableFunction_HttpStart");

            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                nameof(UserSeedMigrationDurableFunction));

            logger.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);
            
            return client.CreateCheckStatusResponse(req, instanceId);
        }

        [Function(nameof(UserSeedMigrationDurableFunction))]
        public async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] TaskOrchestrationContext context)
        {
            ILogger logger = context.CreateReplaySafeLogger(nameof(MigrationDurableFunction));
            
            var users = context.GetInput<IEnumerable<AddUserSeedDto>>();
            
            var outputs = new List<string>
            {
                await context.CallActivityAsync<string>(nameof(MigrateUsersSeedAsync), users)
            };

            return outputs;
        }

        [Function(nameof(MigrateUsersSeedAsync))]
        public async Task<string> MigrateUsersSeedAsync([ActivityTrigger] string name, FunctionContext executionContext)
        {
            try
            {
                //await userSeedManager.AddAsync();

                return "Users migrated!";
            }
            catch (Exception e)
            {
                return $"User migration failed: {e.Message}";
            }
        }
    }
}
