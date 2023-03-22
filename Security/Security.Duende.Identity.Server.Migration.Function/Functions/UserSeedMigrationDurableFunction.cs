using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
using Microsoft.Extensions.Logging;
using Security.Duende.Identity.Server.Migration.Application.Dtos;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers;
using Security.Utils.Extensions;

namespace Security.Duende.Identity.Server.Migration.Function.Functions
{
    public class UserSeedMigrationDurableFunction
    {
        private readonly IUserSeedManager userSeedManager;

        public UserSeedMigrationDurableFunction(IUserSeedManager userSeedManager)
            => this.userSeedManager = userSeedManager;

        [Function("UserSeedMigrationDurableFunction_HttpStart")]
        public  async Task<HttpResponseData> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/user/seed/migrate")] HttpRequestData req,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            ILogger logger = executionContext.GetLogger("UserSeedMigrationDurableFunction_HttpStart");

            var dtos = await userSeedManager.GetDtosAsync(req.Body);

            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                    nameof(RunUserSeedMigrationDurableFunction), dtos);

            return req.CreateOkResult();
        }

        [Function(nameof(RunUserSeedMigrationDurableFunction))]
        public async Task<List<string>> RunUserSeedMigrationDurableFunction(
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
        public async Task<string> MigrateUsersSeedAsync([ActivityTrigger] IEnumerable<AddUserSeedDto> dtos, FunctionContext executionContext)
        {
            try
            {
                await userSeedManager.AddAsync(dtos);

                return "Users seeds migrated!";

            }
            catch (Exception e)
            {
                return $"User migration failed: {e.Message}";
            }
        }
    }
}
