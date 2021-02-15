using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly Lazy<SqlConnection> con;

        public EnderecoRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Endereco Obter(Guid enderecoId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id
                                  ,cep
                                  ,logradouro
                                  ,numero
                                  ,complemento
                                  ,cidade
                                  ,estado
                              FROM dbo.Endereco
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", enderecoId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Endereco>(sql, parametros);
        }

        public int Inserir(Endereco endereco)
        {
            const string sql = @" INSERT INTO [dbo].[Endereco]
                                       ([id]
                                       ,[cep]
                                       ,[logradouro]
                                       ,[numero]
                                       ,[complemento]
                                       ,[cidade]
                                       ,[estado])
                                 VALUES
                                       (@Id
                                       ,@Cep
                                       ,@Logradouro
                                       ,@Numero
                                       ,@Complemento
                                       ,@Cidade
                                       ,@Estado)
                ";
            return con.Value.Execute(sql, endereco);
        }
    }
}
