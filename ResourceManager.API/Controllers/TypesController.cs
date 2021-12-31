using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Data;
using ResourceManager.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly RMContext _context;
        public TypesController(RMContext context)
        {
            _context = context;
        }

        [Route("FetchType")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RType>>> GetType()
        {
            return await _context.RType.ToListAsync();
        }
    }
}
