using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mvc01.Services
{
    public class LineNotifier
    {

        private string _token;
        private const string URL = "https://notify-api.line.me/api/notify";

        public LineNotifier(string token)
        {
            _token = token;
        }

        public async Task<string> Notify(string message)
        {
            if (string.IsNullOrEmpty(_token)) return null;

            using (var client = new HttpClient())
            {
                var url = URL;
                var content = new FormUrlEncodedContent(new[] {

              new KeyValuePair<string, string>("message", message),

              new KeyValuePair<string, string>("stickerId", "103"),
              new KeyValuePair<string, string>("stickerPackageId", "1"),

            });

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");

                var result = await client.PostAsync(url, content);
                string resultContent = await result.Content.ReadAsStringAsync();

                return resultContent;
            }

        }
    }
}
