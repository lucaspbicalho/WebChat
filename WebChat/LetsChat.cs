using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using WebChat.Service;

namespace SignalRChat
{
    [HubName("myChatHub")]
    public class LetsChat : Hub
    {
        StooqBotService _stooqBotService;
        public LetsChat()
        {
            _stooqBotService = new StooqBotService() { };
        }

        public LetsChat(StooqBotService stooqBotService)
        {
            _stooqBotService = stooqBotService;
        }
        public void send(string message, string user)
        {
            if (message.StartsWith("/stock="))
            {
                Clients.All.addMessageStooq(message.Replace("/stock=", ""), user);
                //.SendStooq("/stock=aapl.us");
            }
            else
                Clients.All.addMessage(message, user);
        }
    }
}