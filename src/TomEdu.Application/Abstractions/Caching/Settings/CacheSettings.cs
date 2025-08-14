namespace TomEdu.Application.Abstractions.Caching.Settings;

public class CacheSettings
{
    public uint AbsoluteExpirationInMinutes { get; set; }

    public uint SlidingExpirationInMinutes { get; set; }
}