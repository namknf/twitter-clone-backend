namespace Twitter_backend.Contract
{
    public class ApiRoutes
    {
        public const string Root = "api/";

        public static class Tweets
        {
            public const string GetAll = Root + "/tweets";
            public const string Get = Root + "/tweets/{tweetId}";
            public const string Create = Root + "/tweets";
            public const string Update = Root + "/tweets/{tweetId}";
            public const string Delete = Root + "/tweets/{tweetId}";
        }
    }
}
