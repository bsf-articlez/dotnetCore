﻿using System.Threading.Tasks;

namespace Mvc01.Services
{
    public interface ILog
    {
        Task SendAsync(string s);
    }
}