using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class OperadorRepository : IOperadorRepository
    {
        private readonly Lazy<SqlConnection> con;

        public OperadorRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public int Inserir(Operador operador)
        {
            const string sql = @" INSERT INTO [dbo].[Operador]
                                           ([id]
                                           ,[matricula]
                                           ,[nome]
                                           ,[id_usuario])
                                     VALUES
                                           (@Id
                                           ,@Matricula
                                           ,@Nome
                                           ,@UsuarioId)
                ";
            return con.Value.Execute(sql, operador);
        }

        public Operador Obter(string matricula, string senha)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT op.id as Id
                                  ,matricula as Matricula
                                  ,nome as Nome
	                              ,id_usuario as UsuarioId
                              FROM dbo.Operador op
                              INNER JOIN dbo.Usuario us ON us.id = op.id_usuario
                              WHERE matricula = @matricula
                                    and us.senha = @senha ";
            #endregion

            parametros.Add("matricula", matricula, TipoParametro.StringComTamanhoFixo);
            parametros.Add("senha", senha, TipoParametro.StringComTamanhoFixo);

            return con.Value.QueryFirstOrDefault<Operador>(sql, parametros);

        }
    }
}
