using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Services
{
    public class LineNotifyLog : ILog
    {
        // implicitly impl.
        public async Task Send(string s)
        {
            throw new NotImplementedException();
        }
        //async Task ILog.Send(string s)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
