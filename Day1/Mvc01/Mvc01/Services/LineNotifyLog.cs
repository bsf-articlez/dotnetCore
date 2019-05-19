using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Services
{
    public class LineNotifyLog : ILog
    {
        private readonly string Token = "";
        private readonly IConfiguration config;
        private LineNotifier line;

        public LineNotifyLog(string s, IConfiguration config)
        {
            this.config = config;

            Token = config["Log:LineNotify:Token"];
            line = new LineNotifier(Token);
        }
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
