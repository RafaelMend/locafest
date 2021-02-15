using com.locafest.Domain.LocacaoContext.Entities;
using com.locafest.Domain.LocacaoContext.Model;
using com.locafest.Domain.UsuarioContext.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.locafest.API.Templates
{
    public class TemplateGenerator
    {
        public static string ObterTemplateContrato(ContratoPdfModel contrato)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'>
<h1 style='text-align: center;'>Contrato Locafest</h1>
<p style='text-align: justify;'><strong>LOCAT&Oacute;RIO</strong>: <strong>{0}</strong>, nacionalidade, naturalidade, estado civil, profiss&atilde;o, portador do CPF n&ordm; {1}, residente e domiciliado na Rua {2}, n&deg; {3}, munic&iacute;pio {4}, {5}.</p>
<p style='text-align: justify;'><strong>LOCADOR: </strong>Locafest, empresa brasileira de loca&ccedil;&atilde;o de carro, portador do CNPJ n&ordm; 87.070.445/0001-26, com sede em Belo Horizonte, Minhas Gerais.</p>
<p style='text-align: justify;'>As partes acima identificadas t&ecirc;m, entre si, justo e acertado o presente Contrato de Loca&ccedil;&atilde;o de Autom&oacute;vel que se reger&aacute; pelas cl&aacute;usulas seguintes e pelas condi&ccedil;&otilde;es descritas no presente</p>
<ol style='text-align: justify;'>
<li><strong> CL&Aacute;USULA PRIMEIRA &ndash; DO OBJETO, PRAZO E USO</strong></li>
</ol>
<p style='text-align: justify;'><strong>1.1 O LOCADOR </strong>declara ser o leg&iacute;timo possuidor e/ou propriet&aacute;rio do ve&iacute;culo de modelo {6}, marca {7}, ano {8}.</p>
<p style='text-align: justify;'><strong>1.2 O LOCAT&Oacute;RIO</strong> se responsabiliza pelo ve&iacute;culo, mantendo em bom estado e devolvendo limpo, com o tanque cheio e sem amassados ou arranh&otilde;es. Cada ocorr&ecirc;ncia ter&aacute; uma multa de 30%.</p>
<ol style='text-align: justify;' start='2'>
<li><strong> CLA&Uacute;SULA SEGUNDA &ndash; DO VALOR</strong></li>
</ol>
<p style='text-align: justify;'><strong>2.1.</strong> O<strong> LOCAT&Aacute;RIO </strong>pagar&aacute; ao<strong> LOCADOR </strong>a t&iacute;tulo de loca&ccedil;&atilde;o o valor total de R$: {9} por {10} horas de uso. A data de retirada ser&aacute; {11} com devolu&ccedil;&atilde;o na data {12}.</p>
</div>
                            </body>
                        </html>", contrato.Nome, contrato.Cpf, contrato.Logradouro, contrato.Numero, contrato.Cidade,
                        contrato.Estado, contrato.ModeloVeiculo, contrato.MarcaVeiculo, contrato.AnoVeiculo, 
                        contrato.ValorFinal, contrato.QuantidadeHoras, contrato.DataRetirada, contrato.DataDevolucao);

            return sb.ToString();
        }
    }
}
