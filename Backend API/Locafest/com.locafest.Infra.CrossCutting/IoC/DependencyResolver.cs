using System.Diagnostics.CodeAnalysis;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using com.locafest.Infra.CrossCutting;
using com.locafest.Domain.UsuarioContext.Interface.Service;
using com.locafest.Service.Services;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Infra.Data.Repository;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;

namespace crm.locafest.CrossCutting.IoC
{
    public static class DependencyResolver
    {
        public static void AddDependencyResolver(this IServiceCollection services, IConfiguration configuration)
        {
            RegisterService(services);
            RegisterRepositories(services);

            Settings.ConnectionString = configuration.GetConnectionString("conexao");

            services.AddScoped(scope =>
            {
                return new Lazy<SqlConnection>(() =>
                {
                    var conexao = new SqlConnection(Settings.ConnectionString);
                    conexao.Open();
                    return conexao;
                });
            });
        }

        private static void RegisterService(IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IOperadorService, OperadorService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<ISimulacaoService, SimulacaoService>();
            services.AddScoped<IAgendamentoService, AgendamentoService>();
            services.AddScoped<IContratoService, ContratoService>();
            services.AddScoped<IVistoriaService, VistoriaService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IVistoriaRepository, VistoriaRepository>();
        }
    }
}