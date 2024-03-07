using LegalStatistics.AccountAPI.AccountModels;
using LegalStatistics.AccountAPI.AccountModels.AccountDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace LegalStatistics.AccountAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenModel _jwtModel;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IOptions<TokenModel> options)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtModel = options.Value;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            if (registerRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser
            {
                UserName = registerRequestDTO.Email,
                EmailConfirmed = true,
                Department = registerRequestDTO.Department,
                Title = registerRequestDTO.Title
            };
            //var dubleCheckEmail = await _userManager.FindByEmailAsync(signUpRequestDTO.Email);
            //if (dubleCheckEmail == null)  
            //{
            //    return BadRequest("Email already exists");
            //}
            var result = await _userManager.CreateAsync(user, registerRequestDTO.Password);

            if (!result.Succeeded)
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    IsRegisterationSuccessful = false,
                    Errors = result.Errors.Select(u => u.Description)
                });
            }
            if (string.IsNullOrEmpty(registerRequestDTO.Role))
            {
                registerRequestDTO.Role = "basic";
            }
            var roleResult = await _userManager.AddToRoleAsync(user, registerRequestDTO.Role);
            if (!roleResult.Succeeded)
            {
                return BadRequest(new RegisterResponseDTO()
                {
                    IsRegisterationSuccessful = false,
                    Errors = result.Errors.Select(u => u.Description) 
                });
            }
            return StatusCode(201);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] LogInRequestDTO logInRequestDTO)
        {
            if (logInRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(logInRequestDTO.Email, logInRequestDTO.Password, false, false);
            if (result.Succeeded)
            { 
                var user = await _userManager.FindByNameAsync(logInRequestDTO.Email);
                if (user == null)
                {
                    return Unauthorized(new LogInResponseDTO
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Ошибка аутентификации"
                    });
                }

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtModel.ValidIssuer,
                    audience: _jwtModel.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new LogInResponseDTO()
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    UserDTO = new UserDTO()
                    {
                        Id = user.Id,
                        Email = user.UserName
                    }
                });
            }
            else
            {
                return Unauthorized(new LogInResponseDTO
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Ошибка аутентификации"
                });
            }
        }

        [HttpPost("AddRole/{role}")]
        public async Task<IActionResult> AddRole(string role)
        {
            if (await _roleManager.RoleExistsAsync(role))
            {
                return BadRequest("Роль уже существует");
            }
            var result = await _roleManager.CreateAsync(new IdentityRole(role));

            return StatusCode(201);
        }

        #region Методы для извлечения инф-ии для JWT токена 
        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtModel.SecretKey));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            List<Claim> claims;
            try
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("Id", user.Id),
                    new Claim("Department", user.Department),
                    new Claim("Title", user.Title)
                };
            }
            catch (Exception)
            {

                throw;
            }
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id)); //FindByEmailAsync(user.Email));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        #endregion

    }
}
