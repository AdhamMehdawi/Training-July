using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.DTOs;
using WebApplication2.Entities;
using WebApplication2.Services.TokenService;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AccountController(ApplicationDbContext context, UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _context = context;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser user)
        {
            if (user == null)
            {
                return BadRequest("User data is missing.");
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var appUser = new AppUser
                    {
                        UserName = user.Email,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        DateOfBirth = user.DateOfBirth,
                        DateCreated = DateTime.UtcNow
                    };

                    var result = await _userManager.CreateAsync(appUser, user.Password);

                    if (!result.Succeeded)
                    {
                        return BadRequest(new { Errors = result.Errors.Select(e => e.Description).ToList() });
                    }

                    if (user.Roles != null && user.Roles.Any())
                    {
                        var roleResult = await _userManager.AddToRolesAsync(appUser, user.Roles);
                        if (!roleResult.Succeeded)
                        {
                            await _userManager.DeleteAsync(appUser); 
                            await transaction.RollbackAsync();
                            return BadRequest(new { Errors = roleResult.Errors.Select(e => e.Description).ToList() });
                        }
                    }

                    await transaction.CommitAsync();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(StatusCodes.Status500InternalServerError, new { Errors = new List<string> { $"Error creating user: {ex.Message}" } });
                }
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            if (user == null)
            {
                return BadRequest("User data is missing.");
            }

            var appUser = await _userManager.FindByNameAsync(user.UserName);

            if (appUser == null)
            {
                return BadRequest("Invalid email or password.");
            }

            var result = await _userManager.CheckPasswordAsync(appUser, user.Password);

            if (result)
            {
                var userRoles = await _userManager.GetRolesAsync(appUser);
                var jwtToken = _tokenService.GenerateJwtToken(appUser.UserName, appUser.Id, userRoles.FirstOrDefault());
                var refreshToken = _tokenService.GenerateRefreshToken();

                _tokenService.SaveRefreshToken(appUser.Id, refreshToken);

                return Ok(new TokenResponseDto { JwtToken = jwtToken, RefreshToken = refreshToken });
            }

            return BadRequest("Invalid email or password.");
        }
    }
}
