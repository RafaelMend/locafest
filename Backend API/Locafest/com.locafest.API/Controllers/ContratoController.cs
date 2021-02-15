using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using com.locafest.API.Templates;
using com.locafest.Domain;
using com.locafest.Domain.LocacaoContext.Interface.Service;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace com.locafest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IConverter _converter;
        private readonly IContratoService _contratoService;

        public ContratoController(IConverter converter, IContratoService contratoService)
        {
            _converter = converter;
            _contratoService = contratoService;
        }

        [HttpGet]
        public IActionResult CreatePDF(Guid agendamentoId)
        {
            try
            {
                var contratoPdf = _contratoService.ObterContrato(agendamentoId);
            
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report"
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = TemplateGenerator.ObterTemplateContrato(contratoPdf),
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Assets", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };
                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(pdf);
                return File(file, "application/pdf", "contrato.pdf");
            } 
            catch {
                return Ok(new ErrorModel("Erro inesperado ao gerar o contrato!"));
            }
        }
    }
}
