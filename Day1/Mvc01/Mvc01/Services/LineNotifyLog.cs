using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Services
{
    public class LineNotifyLog : ILog
    {
        private const string Token = "G4566oxi8w8eyZq7cBK7YZ8BEdM8BJZd65f2VEIjxHG";
        private LineNotifier line = new LineNotifier(Token);
        // implicitly impl.
        public async Task SendAsync(string s)
        {
            var message = $"{DateTime.Now:s} {s}";

            await line.Notify(message);
        }
        //async Task ILog.Send(string s)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
