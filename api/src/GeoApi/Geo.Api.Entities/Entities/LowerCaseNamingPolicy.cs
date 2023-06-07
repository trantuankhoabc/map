using System.Text.Json;

namespace Geo.Api.Entities.Entities
{
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return name.ToLowerInvariant();
        }
    }
}
