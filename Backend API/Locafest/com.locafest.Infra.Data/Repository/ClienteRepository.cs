using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly Lazy<SqlConnection> con;

        public ClienteRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public int Inserir(Cliente cliente)
        {
            const string sql = @" INSERT INTO [dbo].[Cliente]
                                       ([id]
                                       ,[nome]
                                       ,[cpf]
                                       ,[aniversario]
                                       ,[id_endereco]
                                       ,[id_usuario])
                                 VALUES
                                       (@Id
                                       ,@Nome
                                       ,@Cpf
                                       ,@Aniversario
                                       ,@EnderecoId
                                       ,@UsuarioId)
                ";
            return con.Value.Execute(sql, cliente);
        }

        public Cliente Obter(string cpf, string senha)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT cl.id as Id
                                  ,cpf as Cpf
                                  ,nome as Nome
								  ,aniversario as Aniversario
								  ,id_endereco as EnderecoId
	                              ,id_usuario as UsuarioId
                              FROM dbo.Cliente cl
                              INNER JOIN dbo.Usuario us ON us.id = cl.id_usuario
                              WHERE cpf = @cpf
                                    and us.senha = @senha ";
            #endregion

            parametros.Add("cpf", cpf, TipoParametro.StringComTamanhoFixo);
            parametros.Add("senha", senha, TipoParametro.StringComTamanhoFixo);

            return con.Value.QueryFirstOrDefault<Cliente>(sql, parametros);

        }

        public Cliente Obter(Guid clienteId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT cl.id as Id
                                  ,cpf as Cpf
                                  ,nome as Nome
								  ,aniversario as Aniversario
								  ,id_endereco as EnderecoId
	                              ,id_usuario as UsuarioId
                              FROM dbo.Cliente cl
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", clienteId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Cliente>(sql, parametros);
        }
    }
}
