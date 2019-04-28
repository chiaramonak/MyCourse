using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
             if (env.IsEnvironment("Production")){
            app.UseHttpsRedirection();
            }

            //PRIMO MIDDLEWARE

            //if (env.IsDevelopment())
            // usato solo se l'app è in via di sviluppo cioè Development
            
            if(env.IsEnvironment("Development"))
            {
                //pagina informativa con dettagli dell'errore, 
                //cattura errori dal secondo middleware in poi 
                app.UseDeveloperExceptionPage();
            }

            //secondo middleware
            app.UseStaticFiles(); // raggiungi i file statici

            // Terzo MIDDLEWARE
            app.Run(async (context) =>
            {
                /*Il httpContext context = Ogni volta che arriva una richiesta web, 
                il web server produce un oggetto che permetterà 
                all'applicazione di leggere le informazioni 
                contenute nella richiesta e di produrre una risposta. */
                string nome = context.Request.Query["nome"];
                await context.Response.WriteAsync($"Ciao {nome.ToUpper()}");
            });
        }
    }
}
