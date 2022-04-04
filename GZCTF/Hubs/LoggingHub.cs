﻿using Microsoft.AspNetCore.SignalR;
using CTFServer.Hubs.Client;
using CTFServer.Services;
using CTFServer.Utils;

namespace CTFServer.Hubs;

public class LoggingHub : Hub<ILoggingClient>
{
    public override async Task OnConnectedAsync()
    {
        if (!await HubHelper.HasAdmin(Context.GetHttpContext()!))
        {
            Context.Abort();
            return;
        }

        await base.OnConnectedAsync();
    }
}
