

public class Twitter
{
    private class Tweet
    {
        public int Id { get; }
        public DateTime Timestamp { get; }

        public Tweet(int id)
        {
            Id = id;
            Timestamp = DateTime.Now;
        }
    }

    private readonly Dictionary<int, List<Tweet>> userTweets;
    private readonly Dictionary<int, HashSet<int>> userFollows;

    public Twitter()
    {
        userTweets = new Dictionary<int, List<Tweet>>();
        userFollows = new Dictionary<int, HashSet<int>>();
    }

    public void PostTweet(int userId, int tweetId)
    {
        if (!userTweets.ContainsKey(userId))
        {
            userTweets[userId] = new List<Tweet>();
        }
        userTweets[userId].Add(new Tweet(tweetId));
    }

    public IList<int> GetNewsFeed(int userId)
    {
        var newsFeed = new List<Tweet>();

        if (userTweets.ContainsKey(userId))
        {
            newsFeed.AddRange(userTweets[userId]);
        }

        if (userFollows.ContainsKey(userId))
        {
            foreach (var followeeId in userFollows[userId])
            {
                if (userTweets.ContainsKey(followeeId))
                {
                    newsFeed.AddRange(userTweets[followeeId]);
                }
            }
        }

        return newsFeed
            .OrderByDescending(tweet => tweet.Timestamp)
            .Take(10)
            .Select(tweet => tweet.Id)
            .ToList();
    }

    public void Follow(int followerId, int followeeId)
    {
        if (!userFollows.ContainsKey(followerId))
        {
            userFollows[followerId] = new HashSet<int>();
        }
        userFollows[followerId].Add(followeeId);
    }

    public void Unfollow(int followerId, int followeeId)
    {
        if (userFollows.ContainsKey(followerId))
        {
            userFollows[followerId].Remove(followeeId);
        }
    }
}

// Exemple d'utilisation
public class Program
{
    public static void Main(string[] args)
    {
        Twitter twitter = new Twitter();

        twitter.PostTweet(1, 5);
        Console.WriteLine(string.Join(",", twitter.GetNewsFeed(1)));  // [5]

        twitter.Follow(1, 2);
        twitter.PostTweet(2, 6);
        Console.WriteLine(string.Join(",", twitter.GetNewsFeed(1)));  // [6, 5]

        twitter.Unfollow(1, 2);
        Console.WriteLine(string.Join(",", twitter.GetNewsFeed(1)));  // [5]

        twitter.Follow(1, 2);
        twitter.PostTweet(1, 3);
        Console.WriteLine(string.Join(",", twitter.GetNewsFeed(2)));  // []
    }
}
