using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly Lazy<SqlConnection> con;

        public ModeloRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Modelo Obter(Guid modeloId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id
                                  ,descricao
                              FROM dbo.Modelo cl
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", modeloId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Modelo>(sql, parametros);
        }

        public int Inserir(Modelo modelo)
        {
            const string sql = @" INSERT INTO [dbo].[Modelo]
                                       ([id]
                                       ,[descricao])
                                 VALUES
                                       (@Id
                                       ,@Descricao)
                ";
            return con.Value.Execute(sql, modelo);
        }
    }
}
