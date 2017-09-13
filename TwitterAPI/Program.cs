using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TweetSharp;

namespace TwitterAPI
{
    class Program
    {
        private static string customerKey = "yjZ1052fRskXwqi6oMKbfZ5vS";
        private static string customerKeySecret = "22YxCgT2ADWLVc35B2CDJfw2YfMqoUnmpqUvDyRhrP5n2LFsFD";
        private static string accessToken = "907938992875823104-cZioc9MZhYX7tavvX2MpMJ2VQQwsbn2";
        private static string accessTokenSecret = "Xd3tT2h8gARYKg7FgF7RWcP7KF85PxvYj4bM4mn9Xu9IT";


        private static TwitterService service = new TwitterService(customerKey, customerKeySecret, accessToken, accessTokenSecret);


        static void Main(string[] args)
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started!");
            Console.Write("Type here what you want to tweet - ");
            string tweet = Console.ReadLine();
            SendTweet(tweet);
            Console.Read();
        }

        private static void SendTweet(string status)
        {
            service.SendTweet(new SendTweetOptions { Status = status }, (tweet, response) =>
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"<{DateTime.Now}> - Tweet Sent!");
                    Console.ResetColor();
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"<ERROR>" + response.Error.Message);
                    Console.ResetColor();
                }
            });
        }


    }
}
