namespace Lab_09_Roman_Qquelcca.Reports.Excel;


using ClosedXML.Excel;
using Examen_Roman_Qquelcca.Repositories.Interfaces;
using System;

public class Generar_Reporte_Clientes
{
    private readonly IUnitOfWork _unitOfWork;

    public Generar_Reporte_Clientes(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public string Generar()
    {
        var clientes = _unitOfWork.Clients
            .GetAllWithInclude(c => c.Orders)
            .ToList();

        string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"Reporte_Clientes_{fechaHora}.xlsx";
        string filePath = $"Outputs/{fileName}";

        using (var workbook = new XLWorkbook())
        {
            var ws = workbook.Worksheets.Add("Clientes");
            ws.Cell(1, 1).Value = "Cliente";
            ws.Cell(1, 2).Value = "Pedidos";

            int row = 2;
            foreach (var cliente in clientes)
            {
                ws.Cell(row, 1).Value = cliente.Name;
                ws.Cell(row, 2).Value = cliente.Orders?.Count ?? 0;
                row++;
            }

            workbook.SaveAs(filePath);
        }

        return filePath;
    }
}
