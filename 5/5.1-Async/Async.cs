using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AdvancedCSharp {

    public class Async : ITutorial {

        public void Run() {
            var s = new Stopwatch();
            s.Start();
            var results1 = Helper.LoadSites1("http://google.com", "http://microsoft.com", "http://umutozel.com");
            Console.WriteLine("Sync Load: " + s.ElapsedMilliseconds);

            s.Restart();
            var results2 = Helper.LoadSites2("http://google.com", "http://microsoft.com", "http://umutozel.com").Result;
            Console.WriteLine("Async Load: " + s.ElapsedMilliseconds);

            Helper.Explanation();
        }

        public class Helper {

            public static IList<string> LoadSites1(params string[] urls) {
                var contents = new List<string>();
                var client = new WebClient();

                foreach (var url in urls) {
                    contents.Add(client.DownloadString(url));
                }

                return contents;
            }

            public static async Task<IList<string>> LoadSites2(params string[] urls) {
                var client = new HttpClient();
                var tasks = urls.Select(u => client.GetStringAsync(u));
                var results = await Task.WhenAll(tasks);
                return results.ToList();
            }

            public static void Explanation() {
                var myTask = GetCompany();

                DoSomeStuff();

                // await!
                while (!myTask.IsCompleted) { }

                Console.WriteLine(myTask.Result.Id);
            }

            private static void DoSomeStuff() {
                var count = new Random().Next(10, 50);
                for (var i = 0; i < count; i++) {
                    Console.WriteLine("Doing some other stuff");
                    Thread.Sleep(30);
                }
            }

            private static IMyStateMachine<Company> GetCompany() {
                var myTask = new MyStateMachine<Company>();
                var timer = new Timer(
                    _ => myTask.SetResult(new Company { Id = new Random().Next(10000) }),
                    null, 1111, 1111
                );
                return myTask;
            }

            public interface IMyStateMachine<T> {
                bool IsCompleted { get; }
                T Result { get; }
            }

            public class MyStateMachine<T> : IMyStateMachine<T> {

                public void SetResult(T value) {
                    Result = value;
                    IsCompleted = true;
                }

                public bool IsCompleted { get; private set; }
                public T Result { get; private set; }
            }

            public class Company {
                public int Id { get; set; }
            }
        }
    }
}