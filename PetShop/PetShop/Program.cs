using FluentValidation;
using FluentValidation.AspNetCore;
using PetShop.BL.Interfaces;
using PetShop.BL.Services;
using PetShop.DL.Interfaces;
using PetShop.DL.Repositories;
using PetShop.HealthChecks;

namespace PetShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IPetRepository, PetRepository>();
            builder.Services.AddSingleton<IPetService, PetService>();
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IProductService, ProductService>();
            builder.Services.AddSingleton<IPetShopService, PetShopService>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));
            builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>(nameof(CustomHealthCheck));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.MapHealthChecks("/healthz");

            app.MapControllers();

            app.Run();
        }
    }
}