namespace TheMovie.Model.Common
{
    public static class Constants
    {
        public static class Movie
        {
            public readonly static string ApiKey = "api_key";
            
            public readonly static string Language = "language";
        }

        public static class App
        {
            public readonly static string Name = "The movie";
        }

        public static class SortBy
        {
            public readonly static string PopulatiryDesc = "popularity.desc";

            public readonly static string VoteAverageDesc = "vote_average.desc";

            public readonly static string ReleaseDateDesc = "release_date.desc";

            public readonly static string VoteCountDesc = "vote_count.desc";
        }

        public static class Service
        {
            public readonly static string ServiceSettings = "service";

            public readonly static string RedisSettings = "service:redis";

            public readonly static string HealthEndpoint = "/healthz";

            public readonly static string AppStartedLog = "App {0} has been started";
        }

        public static class Tracing
        {
            public readonly static string TraceName = "TheMovie";
        }
    }
}
