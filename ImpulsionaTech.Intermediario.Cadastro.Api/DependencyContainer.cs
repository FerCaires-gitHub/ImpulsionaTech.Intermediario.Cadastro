using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.Cliente;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Dtos.TipoConta;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Interfaces;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Model;
using ImpulsionaTech.Intermediario.Cadastro.Domain.Services;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data;
using ImpulsionaTech.Intermediario.Cadastro.Infrastructure.Data.Repositories;
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

                cfg.CreateMap<ClienteRequest, Cliente>();
                cfg.CreateMap<Cliente, ClienteResponse>().ReverseMap();
                cfg.CreateMap<UpdateClienteRequest, Cliente>();

                cfg.CreateMap<TipoContaRequest, TipoConta>();
                cfg.CreateMap<TipoConta, TipoContaResponse>().ReverseMap();
                cfg.CreateMap<UpdateTipoContaRequest, TipoConta>();

            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<EFContext>(opt => opt.UseInMemoryDatabase("teste"));
            //services.AddDbContext<EFContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(AsyncRepository<>));
            services.AddTransient<IUnitOfWork<Cliente>, UnitOfWork<Cliente>>();
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IServiceBase<ClienteRequest, ClienteResponse, Cliente>, ServiceBase<ClienteRequest, ClienteResponse, Cliente>>();

            services.AddTransient<IUnitOfWork<TipoConta>, UnitOfWork<TipoConta>>();
            services.AddTransient<ITipoContaService, TipoContaService>();
            services.AddTransient<IServiceBase<TipoContaRequest, TipoContaResponse, TipoConta>, ServiceBase<TipoContaRequest, TipoContaResponse, TipoConta>>();

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
