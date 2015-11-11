using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using HTMLUIWinFormsApp.Web;
using Microsoft.Owin.Hosting;

namespace HTMLUIWinFormsApp
{
    static class Program
    {
        public static string BaseURL { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.BaseURL = GenerateBaseURL();
            using (var httpHost = WebApp.Start<Startup>(url: Program.BaseURL))
            {
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// return the base URL with finding unused TCP port number.
        /// </summary>
        private static string GenerateBaseURL()
        {
            var portNumbers = getRandoms(8000, 8999);
            var fixedPortNumber = ConfigurationManager.AppSettings["shell:FixedPortNumber"];
            if (string.IsNullOrEmpty(fixedPortNumber) == false)
            {
                portNumbers = new[] { int.Parse(fixedPortNumber) }.Concat(portNumbers);
            }

            var port = portNumbers.First(p =>
            {
                var listener = new TcpListener(IPAddress.Loopback, p);
                try
                {
                    listener.Start();
                    return true;
                }
                catch (Exception) { }
                finally
                {
                    listener.Stop();
                }
                return false;
            });

            var baseURL = $"http://localhost:{port}/";
            return baseURL;
        }

        /// <summary>
        /// Enumerate random numvers infinitely.
        /// </summary>
        private static IEnumerable<int> getRandoms(int minValue, int maxValue)
        {
            for (var random = new Random(); ;) yield return random.Next(minValue, maxValue);
        }
    }
}
