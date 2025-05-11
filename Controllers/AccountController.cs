using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOrca.Data;
using MyOrca.Extensions;
using MyOrca.Models;
using MyOrca.Services;
using MyOrca.ViewModels;
using SecureIdentity.Password;

namespace MyOrca.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("v1/accounts")]
    public async Task<IActionResult> Post(
        [FromBody]RegisterViewModel model,
        [FromServices]OrcaDataContext context)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

        var usuario = new Usuario
        {
            Nome = model.Nome,
            Email = model.Email,
            Cpf = model.Cpf,
            Slug = model.Email.Replace("@", "-").Replace(".", "-")
        };

        var password = PasswordGenerator.Generate(length: 25, includeSpecialChars: true, upperCase: false);
        usuario.Senha = PasswordHasher.Hash(password);

        try
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModel<dynamic>(new
            {
                usuario = usuario.Email, cpf = usuario.Cpf, password
            }));

        }
        catch (DbUpdateException)
        {
            return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já foi cadastrado."));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05x04 - Falha interna do Servidor."));
        }
        
    }
   
    [HttpPost("v1/accounts/login")]
    public async Task<IActionResult> Login(
        [FromBody]LoginViewModel model,
        [FromServices]OrcaDataContext context,
        [FromServices]TokenService tokenService)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
        
        
        var usuario = await context
            .Usuarios
            .AsNoTracking()
            .Include(x=>x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email);

        if (usuario == null)
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));
        
        if (!PasswordHasher.Verify(usuario.Senha, model.Senha))
            return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

        try
        {
            var token = tokenService.GenerateToken(usuario);
            return Ok(new ResultViewModel<string>(token, null));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna do Servidor."));
        }
    }
    
  
}