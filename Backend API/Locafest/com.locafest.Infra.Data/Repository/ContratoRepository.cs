using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly Lazy<SqlConnection> con;

        public ContratoRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public int Inserir(Contrato contrato)
        {
            const string sql = @" INSERT INTO dbo.Contrato
                                       (id
                                       ,id_agendamento
                                       ,data_contratacao)
                                 VALUES
                                       (@Id
                                       ,@AgendamentoId
                                       ,@DataContratacao)
                ";
            return con.Value.Execute(sql, contrato);
        }
    }
}
