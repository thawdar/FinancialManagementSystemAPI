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
    public class SubscriptionController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.Subscription>> Get()
        {
            return await d.Subscription.Get();
        }

        [HttpGet("{id}")]
        public async Task<m.Subscription> Get(Guid id)
        {
            return await d.Subscription.Get(id);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.Subscription data)
        {
            try
            {
                await d.Subscription.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.Subscription data)
        {
            try
            {
                if (id != data.SubscriptionId)
                    return BadRequest();

                await d.Subscription.Update(data);

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
                await d.Subscription.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}