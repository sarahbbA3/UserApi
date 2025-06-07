using Microsoft.AspNetCore.Mvc;
using UserApi.Data;
using UserApi.Models;   
using UserApi.Utils;
using UserApi.DTOs;
using Microsoft.EntityFrameworkCore;


namespace UserApi.Controllers;

[Route("api/usuarios")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserContext _context;
    private readonly IConfiguration _config;

    public UserController(UserContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserCreateDto dto)
    {
        if (!RegexValidator.IsValidEmail(dto.Email))
            return BadRequest(new { mensaje = "Formato de correo inválido" });

        var passwordRegex = _config["PasswordRegex"];
        if (!RegexValidator.IsValidPassword(dto.Password, passwordRegex))
            return BadRequest(new { mensaje = "Formato de contraseña inválido" });

        var emailExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (emailExists)
            return Conflict(new { mensaje = "El correo ya registrado" });

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            Token = Guid.NewGuid().ToString(),
            Phones = dto.Phones.Select(p => new Phone
            {
                Number = p.Number,
                CityCode = p.CityCode,
                ContryCode = p.ContryCode
            }).ToList()
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            id = user.Id,
            created = user.Created,
            modified = user.Modified,
            last_login = user.LastLogin,
            token = user.Token,
            isactive = user.IsActive
        });
    }
}
