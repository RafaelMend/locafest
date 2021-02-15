using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly Lazy<SqlConnection> con;

        public MarcaRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Marca Obter(Guid marcaId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id
                                  ,descricao
                              FROM dbo.Marca cl
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", marcaId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Marca>(sql, parametros);
        }

        public int Inserir(Marca marca)
        {
            const string sql = @" INSERT INTO [dbo].[Marca]
                                       ([id]
                                       ,[descricao])
                                 VALUES
                                       (@Id
                                       ,@Descricao)
                ";
            return con.Value.Execute(sql, marca);
        }
    }
}
