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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.Category>> Get()
        {
            return await d.Category.Get();
        }

        [HttpGet("ProfileId/{ProfileId}")]
        public async Task<IEnumerable<m.Category>> GetByProfileId(Guid ProfileId)
        {
            IEnumerable<m.Category> categories = await d.Category.Get();
            return categories.Where(c => c.ProfileId == ProfileId);
        }

        [HttpGet("Expense/{ProfileId}")]
        public async Task<IEnumerable<m.Category>> GetExpenseCategory(Guid ProfileId)
        {
            IEnumerable<m.Category> categories =  await d.Category.Get();
            return categories.Where(c => c.CategoryType == "Expense" && c.ProfileId == ProfileId);
        }

        [HttpGet("Income/{ProfileId}")]
        public async Task<IEnumerable<m.Category>> GetIncomeCategory(Guid ProfileId)
        {
            IEnumerable<m.Category> categories = await d.Category.Get();
            return categories.Where(c => c.CategoryType == "Income" && c.ProfileId == ProfileId);
        }

        [HttpGet("{id}")]
        public async Task<m.Category> Get(Guid id)
        {
            return await d.Category.Get(id);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.Category data)
        {
            try
            {
                await d.Category.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.Category data)
        {
            try
            {
                if (id != data.CategoryId)
                    return BadRequest();

                await d.Category.Update(data);

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
                await d.Category.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}