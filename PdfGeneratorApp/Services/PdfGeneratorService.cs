using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfGeneratorApp.Models;

namespace PdfGenerator.Services
{
    public class PdfGeneratorService
    {
        public void GeneratePdf(string title, List<Person> data, string pdfPath)
        {
            Document document = new Document();
            Section section = document.AddSection();

            Paragraph headerParagraph = section.AddParagraph(title);
            headerParagraph.Format.Font.Size = 16;
            headerParagraph.Format.Font.Bold = true;
            headerParagraph.Format.SpaceAfter = "1cm";

            Table table = section.AddTable();
            table.Borders.Width = 0.75;

            Column column1 = table.AddColumn(Unit.FromCentimeter(3));
            Column column2 = table.AddColumn(Unit.FromCentimeter(5));
            Column column3 = table.AddColumn(Unit.FromCentimeter(5));

            Row headerRow = table.AddRow();
            headerRow.Cells[0].AddParagraph("Номер");
            headerRow.Cells[1].AddParagraph("Фамилия");
            headerRow.Cells[2].AddParagraph("Имя");

            headerRow.Cells[0].Format.Font.Bold = true;
            headerRow.Cells[1].Format.Font.Bold = true;
            headerRow.Cells[2].Format.Font.Bold = true;

            foreach (var item in data)
            {
                Row row = table.AddRow();
                row.Cells[0].AddParagraph(item.Number.ToString());
                row.Cells[1].AddParagraph(item.LastName);
                row.Cells[2].AddParagraph(item.FirstName);
            }

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();

            pdfRenderer.PdfDocument.Save(pdfPath);
        }
    }
}
