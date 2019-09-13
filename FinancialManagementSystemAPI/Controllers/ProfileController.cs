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
    public class ProfileController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<m.Profile>> Get()
        {
            return await d.Profile.Get();
        }

        [HttpGet("{id}")]
        public async Task<m.Profile> Get(Guid id)
        {
            return await d.Profile.Get(id);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] m.Profile profile)
        {            
            return Ok(await d.Profile.Login(profile));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] m.Profile data)
        {
            try
            {
                IEnumerable<m.Profile> profiles = await Get();
                m.Profile exists = profiles.FirstOrDefault(p => p.LoginId == data.LoginId);
                if (exists != null) return BadRequest("Login ID is duplicated");

                await d.Profile.Insert(data);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] m.Profile data)
        {
            try
            {
                if (id != data.ProfileId)
                    return BadRequest();

                await d.Profile.Update(data);

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
                await d.Profile.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}