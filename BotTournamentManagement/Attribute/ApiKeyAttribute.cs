using BotTournamentManagement.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Attribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthorizationFilter))
        {
        }
    }
}
