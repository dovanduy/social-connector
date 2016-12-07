using TweetSharp;
using System.Threading.Tasks;
using System;

namespace ConsoleApplication1
{
    class Program
    {
        private const string AppConsumerKey = "9iDwZY1pRSNozUHHJ4nG3ylni";
        private const string AppConsumerSecret = "A8uDyUQHBNrxAMYW13FbOO7i52bSZNkMTOY8TSLSFqghDpe5vh";
        private const string AccessToken = " 806037750881226752-oqtUgPlIAs3RLFVEmdMprbzXlF4xGLJ";
        private const string AccessTokenSecret = "Girhom6ihod6N80RNmPKM2QLMr6qRTfvvdavHmgL4ac1j";

        static void Main(string[] args)
        {
            TwitterService service = new TwitterService(Program.AppConsumerKey, Program.AppConsumerSecret, Program.AccessToken, Program.AccessTokenSecret);

            // Step 4 - User authenticates using the Access Token
            var result = service.GetTweet(new GetTweetOptions() { Id = 806069884341760001, IncludeEntities = true, IncludeMyRetweet = true, TrimUser = true });
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
