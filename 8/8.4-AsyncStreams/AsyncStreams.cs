using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;

namespace AdvancedCSharp {

    public class AsyncStreams : ITutorial {

        public async void Run() {
            await foreach (var dataPoint in Helper.FetchIOTData()) {
                WriteLine(dataPoint);
            }
        }

        public static class Helper {

            public static async IAsyncEnumerable<int> FetchIOTData() {
                for (int i = 1; i <= new Random().Next(10, 100); i++) {
                    await Task.Delay(333);
                    yield return i;
                }
            }
        }
    }
}