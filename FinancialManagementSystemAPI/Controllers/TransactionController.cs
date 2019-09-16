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
    public class DailyTransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.DailyTransaction>> Get()
        {
            return await d.Transaction.Get();
        }

        [HttpGet("ProfileId/{ProfileId}")]
        public async Task<IEnumerable<m.DailyTransaction>> GetByProfileId(Guid ProfileId)
        {
            return await d.Transaction.GetByProfileId(ProfileId);
        }

        [HttpPost("ProfileIdAndPeriod")]
        public async Task<IEnumerable<m.DailyTransaction>> GetByProfileIdAndPeriod([FromBody] m.TransactionFilter filter)
        {
            return await d.Transaction.GetByProfileId(filter.ProfileId, filter.StartDate, filter.EndDate);
        }        

        [HttpPost("TotalCategory/ProfileIdAndPeriod")]
        public async Task<IEnumerable<m.CategoryTotal>> GetTotalCategoryByProfileIdAndPeriod([FromBody] m.TransactionFilter filter)
        {
            return await d.Transaction.GetTotalCategoryByProfileId(filter.ProfileId, filter.StartDate, filter.EndDate);
        }

        [HttpPost("TotalCategoryType/ProfileIdAndPeriod")]
        public async Task<IEnumerable<m.CategoryTypeTotal>> GetTotalCategoryTypeByProfileIdAndPeriod([FromBody] m.TransactionFilter filter)
        {
            return await d.Transaction.GetTotalCategoryTypeByProfileId(filter.ProfileId, filter.StartDate, filter.EndDate);
        }

        [HttpGet("{id}")]
        public async Task<m.DailyTransaction> Get(Guid id)
        {
            return await d.Transaction.Get(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.DailyTransaction data)
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
        public async Task<IActionResult> Put(Guid id, [FromBody] m.DailyTransaction data)
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