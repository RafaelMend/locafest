using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface;
using com.locafest.Domain.UsuarioContext.Entities;
using com.locafest.Domain.UsuarioContext.Interface.Repository;
using com.locafest.Infra.Data.Configuration;
using Dapper;
using System;
using System.Data.SqlClient;

namespace com.locafest.Infra.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly Lazy<SqlConnection> con;

        public VeiculoRepository(Lazy<SqlConnection> sqlConnection)
        {
            con = sqlConnection;
        }

        public Veiculo Obter(Guid veiculoId)
        {
            var parametros = new DynamicParameters();

            #region
            string sql = @" SELECT id as Id
                              ,limite_porta_mala as LimitePortaMala
                              ,id_categoria as CategoriaId
                              ,id_combustivel as CombustivelId
                              ,id_marca as MarcaId
                              ,id_modelo as ModeloId
                              ,placa as Placa
                              ,ano as Ano
                              ,valor_hora as ValorHora 
                          FROM dbo.Veiculo
                          WHERE id = @veiculoId ";
            #endregion

            parametros.Add("veiculoId", veiculoId, TipoParametro.Guid);

            return con.Value.QueryFirstOrDefault<Veiculo>(sql, parametros);
        }

        public int Inserir(Veiculo veiculo)
        {
            const string sql = @" INSERT INTO dbo.Veiculo
                                       (id
                                       ,limite_porta_mala
                                       ,id_categoria
                                       ,id_combustivel
                                       ,id_marca
                                       ,id_modelo
                                       ,placa
                                       ,ano
                                       ,valor_hora)
                                 VALUES
                                       (@Id
                                       ,@LimitePortaMala
                                       ,@CategoriaId
                                       ,@CombustivelId
                                       ,@MarcaId
                                       ,@ModeloId
                                       ,@Placa
                                       ,@Ano
                                       ,@ValorHora)
                ";
            return con.Value.Execute(sql, veiculo);
        }
    }
}
