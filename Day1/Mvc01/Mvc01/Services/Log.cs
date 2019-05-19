using System;
using System.IO;
using System.Threading.Tasks;

namespace Mvc01.Services
{
    public class Log : ILog
    {
        private const string LogFileName = "log.txt";
        public async Task SendAsync(string s)
        {
            var message = $"{DateTimeOffset.Now:s} {s}";
            int count = 3;

            x:
            try
            {
                await File.AppendAllLinesAsync(LogFileName, new[] { message });
            }
            catch (Exception)
            {
                if (count-- > 0)
                {
                    await Task.Delay(250);
                    goto x;
                    //await Send(s, count - 1);
                }
            }
        }
    }
}
