using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly Lazy<SqlConnection> con;

        public AgendamentoRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Agendamento Obter(Guid agendamentoId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id as Id
                                  ,id_veiculo as VeiculoId
                                  ,id_cliente as ClienteId
                                  ,data_retirada as DataRetirada
                                  ,data_devolucao as DataDevolucao
                                  ,valor_hora as ValorHora
                                  ,quantidade_horas as QuantidadeHoras
                                  ,valor_final as ValorFinal
                                  ,local as Local
                              FROM dbo.Agendamento
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", agendamentoId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Agendamento>(sql, parametros);
        }

        public int Inserir(Agendamento agendamento)
        {
            const string sql = @" INSERT INTO dbo.Agendamento
                                       (id
                                       ,id_veiculo
                                       ,id_cliente
                                       ,data_retirada
                                       ,data_devolucao
                                       ,valor_hora
                                       ,quantidade_horas
                                       ,valor_final
                                       ,local)
                                 VALUES
                                       (@Id
                                       ,@VeiculoId
                                       ,@ClienteId
                                       ,@DataRetirada
                                       ,@DataDevolucao
                                       ,@ValorHora
                                       ,@QuantidadeHoras
                                       ,@ValorFinal
                                       ,@Local)
                ";
            return con.Value.Execute(sql, agendamento);
        }
    }
}
