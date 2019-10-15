using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace System.Net.WebSockets
{
    public static class ClientWebSocketExtensions
    {
        public static bool IsAvailable(this ClientWebSocket socket)
        {
            switch(socket.State)
            {
                case WebSocketState.Closed:
                case WebSocketState.Aborted:
                case WebSocketState.CloseReceived:
                    return false;
                default:
                    return true;
            }
        }
    }
}
