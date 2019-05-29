using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using m = Model;
using d = DataAccess;

namespace FinancialManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppAdministratorController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.AppAdministrator>> Get()
        {
            return await d.AppAdministrator.Get();
        }

        [HttpGet("{id}")]
        public async Task<m.AppAdministrator> Get(Guid id)
        {
            return await d.AppAdministrator.Get(id);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.AppAdministrator data)
        {
            try
            {
                await d.AppAdministrator.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.AppAdministrator data)
        {
            try
            {
                if (id != data.AdminId)
                    return BadRequest();

                await d.AppAdministrator.Update(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await d.AppAdministrator.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}