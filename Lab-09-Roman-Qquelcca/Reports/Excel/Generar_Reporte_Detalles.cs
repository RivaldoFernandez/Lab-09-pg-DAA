namespace Lab_09_Roman_Qquelcca.Reports.Excel;

using ClosedXML.Excel;
using Examen_Roman_Qquelcca.Repositories.Interfaces;
using System;

public class Generar_Reporte_Detalles
{
    private readonly IUnitOfWork _unitOfWork;

    public Generar_Reporte_Detalles(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public string Generar()
    {
        var detalles = _unitOfWork.Orderdetails
            .GetAllWithInclude(od => od.Product, od => od.Order, od => od.Order.Client)
            .ToList();

        string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        string fileName = $"Reporte_Detalles_{fechaHora}.xlsx";
        string filePath = $"Outputs/{fileName}";

        using (var workbook = new XLWorkbook())
        {
            var ws = workbook.Worksheets.Add("Detalles");

            ws.Cell(1, 1).Value = "Producto";
            ws.Cell(1, 2).Value = "Cliente";
            ws.Cell(1, 3).Value = "Cantidad";
            ws.Cell(1, 4).Value = "Fecha";

            int row = 2;
            foreach (var detail in detalles)
            {
                var nombreProducto = detail.Product?.Name ?? "N/A";
                var nombreCliente = detail.Order?.Client?.Name ?? "N/A";
                var cantidad = detail.Quantity;
                var fecha = detail.Order?.OrderDate.ToShortDateString() ?? "N/A";

                ws.Cell(row, 1).Value = nombreProducto;
                ws.Cell(row, 2).Value = nombreCliente;
                ws.Cell(row, 3).Value = cantidad;
                ws.Cell(row, 4).Value = fecha;
                row++;
            }

            workbook.SaveAs(filePath);
        }

        return filePath;
    }
}
