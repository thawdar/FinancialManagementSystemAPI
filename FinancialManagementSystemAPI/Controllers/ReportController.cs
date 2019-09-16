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
    public class ReportController : ControllerBase
    {
        [HttpPost("CashBook")]
        public async Task<IEnumerable<m.DailyTransaction>> GetCashBook([FromBody] m.CashBookFilter filter)
        {
            return await d.Transaction.GetCashBook(filter);
        }

        [HttpGet("AccountBalance/{ProfileId}")]
        public async Task<IEnumerable<m.AccountWithBalance>> GetAccountBalance(Guid ProfileId)
        {
            return await d.Account.GetAccountWithBalance(ProfileId);
        }

    }
}