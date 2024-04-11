namespace Wallet
{
    using System;
    using System.IO;
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    using Swashbuckle.AspNetCore.Filters;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "GooglePay Decryption",
                        Version = "v1",
                    });
                c.ExampleFilters();
                c.OperationFilter<AddResponseHeadersFilter>();

                var filePath = Path.Combine(AppContext.BaseDirectory, $"{nameof(Wallet)}.xml");
                c.IncludeXmlComments(filePath);
            });
            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseAuthorization();
            app.UseExceptionHandler(new ExceptionHandlerOptions()
            {
                AllowStatusCode404Response = false,
                ExceptionHandlingPath = "/Error",
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=GooglePay}/{action=Sale}/{id?}");

            app.Run();
        }
    }
}