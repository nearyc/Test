using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class AsyscAwait {

    private readonly HttpClient _httpClient = new HttpClient();

    // [HttpGet]
    // [Route("DotNetCount")]
    public async Task<int> GetDotNetCountAsync() {
        // Suspends GetDotNetCountAsync() to allow the caller (the web server)
        // to accept another request, rather than blocking on this one.
        var html = await _httpClient.GetStringAsync("http://dotnetfoundation.org");
        await Task.Delay(100);
        return Regex.Matches(html, @"\.NET").Count;
    }
    public static void Function() {

    }
}