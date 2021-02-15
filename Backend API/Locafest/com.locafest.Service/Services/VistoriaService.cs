using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Interface.Repository;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.locafest.Service.Services
{
    public class VistoriaService : IVistoriaService
    {
        private readonly IVistoriaRepository _vistoriaRepository;

        public VistoriaService(IVistoriaRepository vistoriaRepository)
        {
            _vistoriaRepository = vistoriaRepository;
        }

        public Vistoria Obter(Guid vistoriaId)
        {
            return _vistoriaRepository.Obter(vistoriaId);
        }

        public Result Inserir(Vistoria vistoria)
        {
            try
            {
                int retorno = _vistoriaRepository.Inserir(vistoria);
                if (retorno == 1)
                    return Result.Ok();
                else
                {
                    vistoria.AddNotification("Erros", "Ocorreu algum erro na transação do banco de dados.");
                    return Result.Error(vistoria.Notifications);
                }
            }
            catch (Exception e)
            {
                Log.Error("Erros: " + e.Message);
                vistoria.AddNotification("Erros", e.Message);
                return Result.Error(vistoria.Notifications);
            }

        }
    }
}
