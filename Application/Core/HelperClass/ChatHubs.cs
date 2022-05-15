using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.HelperClass
{
    public class ChatHubs : Hub
    {
        public string Connection() => Context.ConnectionId;
    }
}
