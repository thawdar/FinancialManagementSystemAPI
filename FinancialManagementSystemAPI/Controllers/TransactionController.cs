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
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.Transaction>> Get()
        {
            return await d.Transaction.Get();
        }

        [HttpGet("{id}")]
        public async Task<m.Transaction> Get(Guid id)
        {
            return await d.Transaction.Get(id);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.Transaction data)
        {
            try
            {
                await d.Transaction.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.Transaction data)
        {
            try
            {
                if (id != data.TransactionId)
                    return BadRequest();

                await d.Transaction.Update(data);

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
                await d.Transaction.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}