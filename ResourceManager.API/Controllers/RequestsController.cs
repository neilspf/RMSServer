using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Data;
using ResourceManager.Entity;
using ResourceManager.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly RMContext _context;
        public RequestsController(RMContext context)
        {
            _context = context;
        }

        [Route("FetchRequest")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequest()
        {
            return await _context.Request.ToListAsync();
        }

        [Route("AddRequest")]
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(CustomRequest req)
        {
            _context.Database.ExecuteSqlRaw($"EXEC dbo.PostRequest {req.RTypeId}, '{req.EmpEmail}', '{req.Description}', '{req.Status}', '{req.RequestTo}'");
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = req.RequestId }, req);
        }

        [Route("UserRequest")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GridViewUserRequest>>> GetUserRequest(AppUser user)
        {
            var result = await _context.GridViewUserRequest.FromSqlInterpolated($"EXEC dbo.UserRequests {user.EmpEmail}").ToListAsync();
            return result;
        }

        [Route("AdminRequest")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GridViewAdminRequest>>> GetAdminRequest(AppUser user)
        {
            var result = await _context.GridViewAdminRequest.FromSqlInterpolated($"EXEC dbo.AdminRequests {user.EmpId}").ToListAsync();
            return result;
        }
    }
}
