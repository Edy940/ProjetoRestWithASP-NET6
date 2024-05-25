using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASP_NET.Model.Context;
using RestWithASP_NET.Services;
using RestWithASP_NET.Services.Implementations;

namespace RestWithASPNETUdemy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar a string de conex�o
            var connectionString = builder.Configuration.GetConnectionString("SQLServerConnectionString");
            builder.Services.AddDbContext<SQLServerContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro do servi�o IPersonService com a implementa��o PersonService
            builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

            // Adicionar servi�os de controle
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure o pipeline de requisi��es HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
