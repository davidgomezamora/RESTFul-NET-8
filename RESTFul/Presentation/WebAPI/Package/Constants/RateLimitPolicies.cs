namespace Presentation.WebAPI.Package.Constants
{
    public static class RateLimitPolicies
    {
        public const string FixedWindow = "FixedWindow";
        public const string SlidingWindow = "SlidingWindow";
        public const string TokenBucket = "TokenBucket";
        public const string Concurrency = "Concurrency";
        public const string Default = FixedWindow;
    }
}
