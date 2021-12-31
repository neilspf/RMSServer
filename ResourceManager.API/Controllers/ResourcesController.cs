using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Data;
using ResourceManager.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly RMContext _context;
        public ResourcesController(RMContext context)
        {
            _context = context;
        }

        [Route("FetchResource")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resource>>> FetchResource()
        {
            return await _context.Resource.ToListAsync();
        }

        [Route("GetResources")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GridViewResource>>> GetResource(RType type)
        {
            var result = await _context.GridViewResource.FromSqlInterpolated($"EXEC dbo.GetResources {type.RTypeId}").ToListAsync();
            return result;
        }

        [Route("SearchResources")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GridViewResource>>> GetResourceBySerialId(Resource resource)
        {
            var result = await _context.GridViewResource.FromSqlInterpolated($"EXEC dbo.SearchBySerialId {resource.SerialId}").ToListAsync();
            return result;
        }

        [Route("UserResources")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GridViewResource>>> GetUserResource(AppUser user)
        {
            var result = await _context.GridViewResource.FromSqlInterpolated($"EXEC dbo.GetUserResource {user.EmpEmail}").ToListAsync();
            return result;
        }

        [Route("AddResource")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Resource>>> AddResources(Resource resource)
        {
            _context.Database.ExecuteSqlRaw($"EXEC dbo.AddResource {resource.RTypeId}, '{resource.ResourceName}', '{resource.MacId}', '{resource.SerialId}', '{resource.WarrantyValidUpTo}', '{resource.PurchaseDate}', '{resource.Vendor}'");
            await _context.SaveChangesAsync();
            return CreatedAtAction("FetchResource", new { id = resource.ResourceId }, resource);
        }
        [Route("CountResource")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculateResource>>> GetResourceCount()
        {
            var result = await _context.calculateResource.FromSqlInterpolated($"EXEC dbo.CountResource").ToListAsync();
            return result;
        }
        [Route("ResourceByType")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourcebyType>>> GetResourceByType()
        {
            var result = await _context.ResourcebyTypes.FromSqlInterpolated($"EXEC dbo.CountResourceByType").ToListAsync();
            return result;
        }
    }
}
