using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestVersioning.Models
{
    /// <summary>
    /// Cache Policy options
    /// </summary> 
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CachePolicy
    {
        RestoreCacheIfRequied,
        CacheOnly,
        SourceOnly,
    }
}