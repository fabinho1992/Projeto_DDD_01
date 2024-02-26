
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Etidades.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAPIs.Models;
using WeBAPIs.Token;

namespace WeBAPIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configuration Services
            // Banco de dados
            builder.Services.AddDbContext<ContextBase>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Injeção Identity
            builder.Services.AddDefaultIdentity<ApplicationUser>(
                op => op.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContextBase>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Interface e Repository
            builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            builder.Services.AddSingleton<IMessage, RepositoryMessage>();

            // Serviço Dominio
            builder.Services.AddSingleton<IServiceMessage, ServiceMessage>();

            //JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
            option.TokenValidationParameters = new TokenValidationParameters
            {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Securiry.Bearer",
              ValidAudience = "Teste.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
            };

            option.Events = new JwtBearerEvents
            {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
             };
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MessageViewModel, Message>();
                cfg.CreateMap<Message, MessageViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //var urlDev = "https://dominiodocliente.com.br";
            //var urlHML = "https://dominiodocliente2.com.br";
            //var urlPROD = "https://dominiodocliente3.com.br";

            //app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

            var devClient = "http://localhost:4200";
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader().WithOrigins(devClient));

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
