using Lab_09_Roman_Qquelcca.Reports.Excel;

namespace Lab_09_Roman_Qquelcca.Controllers;


using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReportesController : ControllerBase
{
    private readonly Generar_Reporte_Clientes _reporteClientes;
    private readonly Generar_Reporte_Detalles _reporteDetalles;

    public ReportesController(
        Generar_Reporte_Clientes reporteClientes,
        Generar_Reporte_Detalles reporteDetalles)
    {
        _reporteClientes = reporteClientes;
        _reporteDetalles = reporteDetalles;
    }

    [HttpGet("clientes-con-pedidos")]
    public IActionResult DescargarReporteClientesConPedidos()
    {
        var filePath = _reporteClientes.Generar();

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var fileName = System.IO.Path.GetFileName(filePath);

        return File(fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileName);
    }

    [HttpGet("productos-con-detalles")]
    public IActionResult DescargarReporteProductosConDetalles()
    {
        var filePath = _reporteDetalles.Generar();

        var fileBytes = System.IO.File.ReadAllBytes(filePath);
        var fileName = System.IO.Path.GetFileName(filePath);

        return File(fileBytes,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            fileName);
    }
}
