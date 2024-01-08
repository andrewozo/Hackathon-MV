using System.Text.Json.Serialization;

namespace Hackathon_MV.Server.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccTypeClass
    {
        Checkings = 1,

        Savings = 2,
    }
}
