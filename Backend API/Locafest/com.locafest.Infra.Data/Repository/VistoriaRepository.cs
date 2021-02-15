using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace com.locafest.Infra.Data.Repository
{
    public class VistoriaRepository : IVistoriaRepository
    {
        private readonly Lazy<SqlConnection> con;

        public VistoriaRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Vistoria Obter(Guid vistoriaId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id
                                  ,id_contrato as ContratoId
                                  ,idc_carro_limpo as IndiceCarroLimpo
                                  ,idc_tanque_cheio as IndiceTanqueCheio
                                  ,idc_amassados as IndiceAmassados
                                  ,idc_arranhoes as IndiceArranhoes
                                  ,perc_ocorrencia as PercentualOcorrencia
                              FROM dbo.Vistoria
                              WHERE id = @id ";
            #endregion

            parametros.Add("id", vistoriaId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Vistoria>(sql, parametros);
        }

        public int Inserir(Vistoria vistoria)
        {
            const string sql = @" INSERT INTO dbo.Vistoria
                                       (id
                                       ,id_contrato
                                       ,idc_carro_limpo
                                       ,idc_tanque_cheio
                                       ,idc_amassados
                                       ,idc_arranhoes
                                       ,perc_ocorrencia)
                                 VALUES
                                       (@Id
                                       ,@ContratoId
                                       ,@IndiceCarroLimpo
                                       ,@IndiceTanqueCheio
                                       ,@IndiceAmassados
                                       ,@IndiceArranhoes
                                       ,@PercentualOcorrencia)
                ";
            return con.Value.Execute(sql, vistoria);
        }
    }
}
