using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Security.Duende.Identity.Server.Migration.Application.Interfaces.Managers;
using Security.Utils.Extensions;

namespace Security.Duende.Identity.Server.Migration.Function.Functions
{
    public class UserSeedMigrationFunction
    {
        private readonly IUserSeedManager userSeedManager;
        private readonly ILogger logger;

        public UserSeedMigrationFunction(IUserSeedManager userSeedManager, ILoggerFactory loggerFactory)
        {
            this.userSeedManager = userSeedManager;

            logger = loggerFactory.CreateLogger<UserSeedMigrationFunction>();
        }

        [Function("UserSeedMigrationFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/user/seed")] HttpRequestData req)
        {
            try
            {
                await userSeedManager.AddAsync(req.Body);

                return req.CreateOkResult();
            }
            catch (Exception e)
            {
                logger.LogError("ENotarUserMigration Failed!", e);

                return req.CreateInternalServerErrorResult();
            }
        }
    }
}
