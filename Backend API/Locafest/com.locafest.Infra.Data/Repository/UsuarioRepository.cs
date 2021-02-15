using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Lazy<SqlConnection> con;

        public UsuarioRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public int Inserir(Usuario usuario)
        {
            const string sql = @" INSERT INTO [dbo].[Usuario]
                                       ([id]
                                       ,[senha])
                                 VALUES
                                       (@Id
                                       ,@Senha)
                ";
            return con.Value.Execute(sql, usuario);
        }
    }
}
