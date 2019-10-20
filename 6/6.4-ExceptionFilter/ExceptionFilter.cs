using System;
using System.Net.Http;
using static System.Console;

namespace AdvancedCSharp {

    public class ExceptionFilter : ITutorial {

        public async void Run() {
            var handler = new HttpClientHandler();
            handler.AllowAutoRedirect = false;

            using (HttpClient client = new HttpClient(handler)) {
                var task = client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/about/");
                try {
                    var responseText = await task;
                    WriteLine(responseText);
                } catch (HttpRequestException e) when (e.Message.Contains("301")) {
                    WriteLine("Site Moved");
                } catch (Exception ex) {
                    WriteLine(ex.Message);
                }
            }
        }
    }
}
