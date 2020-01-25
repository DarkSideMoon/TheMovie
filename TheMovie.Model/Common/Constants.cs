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
    }
}
