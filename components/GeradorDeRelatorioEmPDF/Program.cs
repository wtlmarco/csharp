﻿using GeradorDeRelatorioEmPDF;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Text.Json;

internal class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>();
    static BaseFont fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
    private static void Main(string[] args)
    {
        DesserializarPessoas();

        GerarRelatorioEmPDF(100);
    }

    static void DesserializarPessoas()
    {
        if(File.Exists("arquivos/pessoas.json"))
        {
            using (var sr = new StreamReader("arquivos\\pessoas.json"))
            {
                var dados = sr.ReadToEnd();
                pessoas = JsonSerializer.Deserialize(dados, typeof(List<Pessoa>)) as List<Pessoa>;
            }
        }
    }

    static void GerarRelatorioEmPDF(int qtdePessoas)
    {
        var pessoasSelecionadas = pessoas.Take(qtdePessoas).ToList();
        if(pessoasSelecionadas.Count > 0)
        {
            //Cálculo da quantidade de páginas
            int totalPaginas = 1;
            int totalLinhas = pessoasSelecionadas.Count;
            if (totalLinhas > 24)
                totalPaginas += (int)Math.Ceiling((totalLinhas - 24) / 29F);

            //Configuração do documento PDF
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);

            var nomeArquivo = $"pessoas.{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var arquivo = new FileStream(nomeArquivo, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            writer.PageEvent = new EventosDePagina(totalPaginas);

            pdf.Open();

            //Adição do Título
            var fonteParagrafo = new iTextSharp.text.Font(fontBase, 32, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório de Pessoas\n\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            titulo.SpacingAfter = 4;
            pdf.Add(titulo);

            //Adição da imagem
            var caminhoImagem = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "arquivos\\img\\youtube.png");
            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(caminhoImagem);

                float razaoAlturaLargura = logo.Width / logo.Height;
                float alturaLogo = 32;
                float larguraLogo = alturaLogo * razaoAlturaLargura;
                logo.ScaleToFit(larguraLogo, alturaLogo);

                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                writer.DirectContent.AddImage(logo, false);
            }

            //Adição de um link
            var fonteLink = new iTextSharp.text.Font(fontBase, 9.9F, Font.NORMAL, BaseColor.Blue);
            var link = new Chunk("Canal do Prof. Ricardo Maroquio", fonteLink);
            link.SetAnchor("https://www.youtube.com/maroquio");
            var larguraTextoLink = fontBase.GetWidthPoint(link.Content, fonteLink.Size);
            var caixaTexto = new ColumnText(writer.DirectContent);
            caixaTexto.AddElement(link);
            caixaTexto.SetSimpleColumn(
                pdf.PageSize.Width - pdf.RightMargin - larguraTextoLink,
                pdf.PageSize.Height - pdf.TopMargin - (30 * pxPorMm),
                pdf.PageSize.Width - pdf.RightMargin,
                pdf.PageSize.Height - pdf.TopMargin - (18 * pxPorMm)
                );
            caixaTexto.Go();

            //Adição da tabela de dados
            var tabela = new PdfPTable(5);
            float[] larguraColunas = { 0.6f, 2f, 1.5f, 1f, 1f };
            tabela.SetWidths(larguraColunas);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //Adição das células de títulos das colunas
            CriarCelulaTexto(tabela, "Código", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Nome", PdfPCell.ALIGN_LEFT, true);
            CriarCelulaTexto(tabela, "Profissão", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Salário", PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTexto(tabela, "Empregada", PdfPCell.ALIGN_CENTER, true);

            foreach (var p in pessoasSelecionadas)
            {
                CriarCelulaTexto(tabela, p.IdPessoa.ToString("D6"), PdfPCell.ALIGN_CENTER);
                CriarCelulaTexto(tabela, p.Nome + " " + p.Sobrenome);
                CriarCelulaTexto(tabela, p.Profissao.Nome, PdfPCell.ALIGN_CENTER);
                CriarCelulaTexto(tabela, p.Salario.ToString("C2"), PdfPCell.ALIGN_RIGHT);

                var caminhoImagemCelula = p.Empregado ? "arquivos\\img\\emoji_feliz.png" : "arquivos\\img\\emoji_triste.png";
                caminhoImagemCelula = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, caminhoImagemCelula);
                CriarCelulaImagem(tabela, caminhoImagemCelula, 20, 20);
            }

            pdf.Add(tabela);

            //Fechamento do Documento
            pdf.Close();
            arquivo.Close();

            //Abre o PDF no visualizador padrão
            var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            if (File.Exists(caminhoPDF))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start {caminhoPDF}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }
        }
    }

    static void CriarCelulaTexto(PdfPTable tabela, string texto, 
        int alinhamentoHorz = PdfPCell.ALIGN_LEFT, 
        bool negrito = false, bool italico = false,
        int tamanhoFonte = 12, int alturaCelula = 25)
    {
        int estilo = iTextSharp.text.Font.NORMAL;
        if(negrito && italico)
        {
            estilo = iTextSharp.text.Font.BOLDITALIC;
        }
        else if(negrito)
        {
            estilo = iTextSharp.text.Font.BOLD;
        }
        else if(italico)
        {
            estilo = iTextSharp.text.Font.ITALIC;
        }

        var fonteCelula = new iTextSharp.text.Font(fontBase, tamanhoFonte, estilo, BaseColor.Black);

        var bgColor = iTextSharp.text.BaseColor.White;
        if (tabela.Rows.Count % 2 == 1)
            bgColor = new BaseColor(0.95F, 0.95F, 0.95F);

        var celula = new PdfPCell(new Phrase(texto, fonteCelula));
        celula.HorizontalAlignment = alinhamentoHorz;
        celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        celula.Border = 0;
        celula.BorderWidthBottom = 1;
        celula.FixedHeight = alturaCelula;
        celula.PaddingBottom = 5;
        celula.BackgroundColor = bgColor;

        tabela.AddCell(celula);
    }

    static void CriarCelulaImagem(PdfPTable tabela, string caminhoImagem,
        int larguraImagem, int alturaImagem, int alturaCelula = 25)
    {
        var bgColor = iTextSharp.text.BaseColor.White;
        if (tabela.Rows.Count % 2 == 1)
            bgColor = new BaseColor(0.95F, 0.95F, 0.95F);

        if(File.Exists(caminhoImagem))
        {
            iTextSharp.text.Image imagem = iTextSharp.text.Image.GetInstance(caminhoImagem);
            imagem.ScaleToFit(larguraImagem, alturaImagem);

            var celula = new PdfPCell(imagem);
            celula.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.BackgroundColor = bgColor;

            tabela.AddCell(celula);
        }
    }
}