﻿using System.Net;
using System.Threading.Tasks;

namespace BusinessObjects.Manager
{
    public interface IWebManager
    {
        bool IsNetworkAvailable { get; }
        Task<WebManager.Result> DownloadHtml(string uri);
        Task<CookieContainer> PostData(string uri, string data);
    }
}