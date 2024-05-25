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

            // Configurar a string de conexão
            var connectionString = builder.Configuration.GetConnectionString("SQLServerConnectionString");
            builder.Services.AddDbContext<SQLServerContext>(options =>
                options.UseSqlServer(connectionString));

            // Registro do serviço IPersonService com a implementação PersonService
            builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

            // Adicionar serviços de controle
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure o pipeline de requisições HTTP
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
