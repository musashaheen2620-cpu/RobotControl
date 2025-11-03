using System.Net.Sockets;
using System.Text;

namespace Inventory_system_1.Models
{
    public class Robot
    {
        public const int UrscriptPort = 30002;
        public const int DashboardPort = 29999;
        public string IpAddress = "localhost";

        public void SendString(int port, string message)
        {
            using var client = new TcpClient(IpAddress, port);
            using var stream = client.GetStream();
            var data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public void SendUrsript(string urscript)
        {
            SendString(DashboardPort, "brake release\n");
            SendString(UrscriptPort, urscript);
        }
    }
}