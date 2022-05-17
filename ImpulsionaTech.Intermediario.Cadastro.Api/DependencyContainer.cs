using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ImpulsionaTech.Intermediario.Cadastro.Application;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Commands.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Clientes;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.Contas;
using ImpulsionaTech.Intermediario.Cadastro.Application.Responses.TiposConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace ImpulsionaTech.Intermediario.Cadastro.Api
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddExpressionMapping();

                cfg.CreateMap<InsertClienteCommand, Cliente>();
                cfg.CreateMap<Cliente, InsertClienteResponse>();
                cfg.CreateMap<Cliente, GetClienteResponse>().ReverseMap();
                cfg.CreateMap<UpdateClienteCommand, Cliente>();

                cfg.CreateMap<InsertTipoContaCommand, TipoConta>();
                cfg.CreateMap<TipoConta, InsertTipoContaResponse>();
                cfg.CreateMap<TipoConta, GetTipoContaResponse>().ReverseMap();
                cfg.CreateMap<UpdateTipoContaCommand, TipoConta>();

                cfg.CreateMap<InsertContaCommand, Conta>();
                cfg.CreateMap<Conta, InsertContaResponse>();
                cfg.CreateMap<Conta, GetTipoContaResponse>().ReverseMap();
                cfg.CreateMap<UpdateContaCommand, Conta>();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<EFContext>(opt => opt.UseInMemoryDatabase("teste"));
            //services.AddDbContext<EFContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(AsyncRepository<>));
            services.AddTransient<IAsyncRepository<Cliente>, AsyncRepository<Cliente>>();
            services.AddTransient<IAsyncRepository<TipoConta>, AsyncRepository<TipoConta>>();
            services.AddTransient<IAsyncRepository<Conta>, AsyncRepository<Conta>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "ImpulsionaTech.Cadastro" });
                swagger.DescribeAllParametersInCamelCase();
            });
            services.AddControllers().AddJsonOptions(
                options =>
                {
                    var enumConverter = new JsonStringEnumConverter();
                    options.JsonSerializerOptions.Converters.Add(enumConverter);
                });

        }
    }
}
