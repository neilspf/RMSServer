using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ResourceManager.Data;
using ResourceManager.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly RMContext _context;
        private IConfiguration _config;

        public AppUsersController(RMContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Route("FetchUser")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUser()
        {
            return await _context.AppUser.ToListAsync();
        }

        [Route("FetchAdmin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAdmin()
        {
            return await _context.AppUser.Where(l => l.IsAdmin == true).ToArrayAsync();
        }

        [Route("FindUser")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AppUser>>> FindUser(AppUser user)
        {
            var webLogin = await _context.AppUser.Where(l => l.EmpEmail == user.EmpEmail).ToListAsync();
            return webLogin;
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(AppUser user)
        {
            var webLogin = _context.AppUser.Where(l => l.EmpEmail == user.EmpEmail).FirstOrDefault();
            if (webLogin != null)
            {
                return Unauthorized();
            }
            _context.Database.ExecuteSqlRaw($"EXEC dbo.UserSignup '{user.EmpName}', '{user.EmpEmail}', '{user.Password}', '{user.IsAuthorised}'");
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.EmpId }, user);
        }

        [Route("IsAdmin")]
        [HttpPost]
        public bool CheckAdmin(AppUser user)
        {
            var webLogin = _context.AppUser.Where(l => l.EmpEmail == user.EmpEmail && l.IsAdmin == true).FirstOrDefault();
            if (webLogin != null)
            {
                return true;
            }
            return false;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("LogIn")]
        public IActionResult Login(AppUser user)
        {
            IActionResult response = Unauthorized();
            var webLogin = _context.AppUser.Where(l => l.EmpEmail == user.EmpEmail && l.Password == user.Password).FirstOrDefault();
            if (webLogin != null)
            {
                var tokenString = GenerateJSONWebToken(webLogin);
                response = Ok(new { token = tokenString });
                //response = Ok();
            }
            return response;
        }

        private string GenerateJSONWebToken(AppUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}