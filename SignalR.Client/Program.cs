using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Client
{
    public  class Program
    {
        public static async Task Main(string[] args)
        {
            var hubConnection = new HubConnection("http://localhost:50960/");
            IHubProxy testHub = hubConnection.CreateHubProxy("testHub");
            testHub.On<string,string>("addNewMessageToPage", (name, message)=> { Console.WriteLine($"Message Recieved from:{name}, Message: {message}"); });
            await hubConnection.Start();

            while (true)
            {
                string line = Console.ReadLine();
                await testHub.Invoke("Send", "Mohamed", line);
            }
        }
    }
}
