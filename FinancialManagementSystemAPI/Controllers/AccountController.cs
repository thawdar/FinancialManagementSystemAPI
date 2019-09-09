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
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.Account>> Get()
        {
            return await d.Account.Get();
        }

        [HttpGet("ProfileId/{ProfileId}")]
        public async Task<IEnumerable<m.Account>> GetByProfileId(Guid ProfileId)
        {
            IEnumerable<m.Account> accounts = await d.Account.Get();
            return accounts.Where(a => a.ProfileId == ProfileId);
        }

        [HttpGet("Balance/{id}")]
        public async Task<decimal> GetBalance(Guid id)
        {
            return await d.Account.GetBalance(id);            
        }

        [HttpGet("{id}")]
        public async Task<m.Account> Get(Guid id)
        {
            return await d.Account.Get(id);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.Account data)
        {
            try
            {
                await d.Account.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.Account data)
        {
            try
            {
                if (id != data.AccountId)
                    return BadRequest();

                await d.Account.Update(data);

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
                await d.Account.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}