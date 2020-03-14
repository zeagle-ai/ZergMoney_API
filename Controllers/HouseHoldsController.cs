using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ZergMoney_API.Models;

namespace ZergMoney_API.Controllers
{
    [RoutePrefix("api/HouseHolds")]
    public class HouseHoldsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Route("GetHouseHold")]
        [AcceptVerbs("GET")]
        public async Task<Household> GetHouseHold(int hhId)
        {
            return await db.GetHouseHold(hhId);
        }

        [Route("GetHouseHoldAccounts")]
        [AcceptVerbs("GET")]
        public async Task<List<PersonalAccount>> GetHouseHoldAccounts(int hhId)
        {
            return await db.GetHouseHoldAccounts(hhId);
        }

        [Route("GetTransactions")]
        [AcceptVerbs("GET")]
        public async Task<List<Transaction>> GetTransactions(int accId)
        {
            return await db.GetTransactions(accId);
        }

        [Route("GetBudget")]
        [AcceptVerbs("GET")]
        public async Task<Budget> GetBudget(int hhId)
        {
            return await db.GetBudget(hhId);
        }

        [Route("GetBudgetItems")]
        [AcceptVerbs("GET")]
        public async Task<List<BudgetItem>> GetBudgetItems(int budgId)
        {
            return await db.GetBudgetItems(budgId);
        }

        [Route("AddAccount")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddAccount(int hhId, string name, decimal bal, decimal recBal, string owner, bool isDel, string bankName)
        {
            return Ok(db.AddAccount(hhId, name, bal, recBal, owner, isDel, bankName));
        }

        [Route("AddTransaction")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddTransaction(int accountId, string description, DateTime date, decimal amount, bool isVoid, int catId, string owner, bool rec, decimal recAmount, bool isDel, string dep, int hhId)
        {
            return Ok(db.AddTransaction(accountId, description, date, amount, isVoid, catId, owner, rec, recAmount, isDel, dep, hhId));
        }
    }
}
