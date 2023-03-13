using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Security.Cookie.Migration.Application.Interfaces.Services;
using Security.Utils.Extensions;

namespace Security.Cookie.Migration.Function.Functions
{
    public class UserMigrationFunctions
    {
        private readonly IUserMigrationService userMigrationService;
        private readonly ILogger logger;

        public UserMigrationFunctions(
            IUserMigrationService userMigrationService, ILoggerFactory loggerFactory)
        {
            this.userMigrationService= userMigrationService;

            logger = loggerFactory.CreateLogger<UserMigrationFunctions>();
        }

        [Function("UserMigrationFunctions")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/user/migrate")] HttpRequestData req)
        {
            try
            {
                await userMigrationService.AddAsync();

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
