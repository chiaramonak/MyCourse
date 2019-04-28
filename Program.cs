using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MyCourse
{
    public class Program
    {
        /*All'avvio dell'applicazione, dal metodo Main che è il 
        primo metodo a essere invocato, 
        viene preparato il web host che contiene alcuni componenti 
        essenziali che permettono all'applicazione di interagire 
        con il resto del sistema. */
        public static void Main(string[] args)
        {   
            string firstArgument= args.FirstOrDefault();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
