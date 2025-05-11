using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrca.Data;
using MyOrca.Extensions;
using MyOrca.Models;
using MyOrca.ViewModels;


namespace MyOrca.Controllers;

[ApiController]
public class CategoriaController : ControllerBase
{
    [HttpGet("v1/categorias")]
    public async Task<IActionResult> GetAsync(
        [FromServices] OrcaDataContext context)
    {
        try
        {
            var categorias = await context.Categorias.ToListAsync();
            return Ok(new ResultViewModel<List<Categoria>>(categorias));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Categoria>>("05XE5 - Falha interna no servidor"));
        }
    }
   
    [HttpGet("v1/categorias/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] int id,
        [FromServices] OrcaDataContext context)
    {
        try
        {
            var categoria = await context
                .Categorias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound(new ResultViewModel<Categoria>("Conteúdo não encontrado"));

            return Ok(new ResultViewModel<Categoria>(categoria));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Categoria>("05XE6 - Falha interna no servidor"));
        }
    }

    [HttpPost("v1/categorias")]
    public async Task<IActionResult> PostAsync(
        [FromBody] EditorCategoriaViewModel model,
        [FromServices] OrcaDataContext context)
    {
        if (!ModelState.IsValid) // verifica se dados do body estão válidos conforme validação viewmodel
            return BadRequest(new ResultViewModel<Categoria>(ModelState.GetErrors()));
        
        try
        {
            var categoria = new Categoria
            {
                Id = 0,
                //SubCategorias = [],
                Nome = model.Nome,
                Slug = model.Slug.ToLower()
            };
            await context.Categorias.AddAsync(categoria);
            await context.SaveChangesAsync();

            return Created($"v1/categorias/{categoria.Id}", new ResultViewModel<Categoria>(categoria));
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500,new ResultViewModel<Categoria>("05XE9 - Não foi possível incluir a Categoria"));
        }
        catch
        {
            return StatusCode(500,new ResultViewModel<Categoria>("05XE10 - Falha interna no Servidor"));
        }
    }

    [HttpPut("v1/categorias/{id:int}")]
    public async Task<IActionResult> PutAsync(
        [FromRoute] int id,
        [FromBody] EditorCategoriaViewModel model,
        [FromServices] OrcaDataContext context)
    {
        try
        {
            var categoria = await context
                .Categorias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound(new ResultViewModel<Categoria>("Conteúdo não encontrado"));

            categoria.Nome = model.Nome;
            categoria.Slug = model.Slug.ToLower();

            context.Categorias.Update(categoria);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Categoria>(categoria));
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500,new ResultViewModel<Categoria>("05XE8 - Não foi possível alterar a Categoria"));
        }
        catch
        {
            return StatusCode(500,new ResultViewModel<Categoria>( "05XE11 - Falha interna no servidor"));
        }
    }

    [HttpDelete("v1/categorias/{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id,
        [FromServices] OrcaDataContext context)
    {
        try
        {
            var categoria = await context
                .Categorias
                .FirstOrDefaultAsync(x => x.Id == id);

            if (categoria == null)
                return NotFound(new ResultViewModel<Categoria>("Conteúdo não encontrado"));

            context.Categorias.Remove(categoria);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<Categoria>(categoria));
        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500,new ResultViewModel<Categoria>("05XE7 - Não foi possível excluir a Categoria"));
        }
        catch (Exception e)
        {
            return StatusCode(500,new ResultViewModel<Categoria>("05XE12 - Falha interna no servidor"));
        }
    }
   
}