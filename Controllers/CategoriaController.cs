using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrca.Data;


namespace MyOrca.Controllers;

[ApiController]
public class CategoriaController : ControllerBase
{
    [HttpGet("v1/categorias")]
    public async Task<IActionResult> GetAsync(
        [FromServices] OrcaDataContext context)
    {
        var categorias = await context.Categorias.ToListAsync();
        return Ok(categorias);
    }
}