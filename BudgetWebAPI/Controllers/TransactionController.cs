using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BudgetDataAccess.Models;
using BudgetDataAccess.Connections;

namespace BudgetWebAPI.Controllers
{
    public class TransactionController : ApiController
    {
        [Route("api/transaction")]
        public IEnumerable<BusinessObject<Transaction>> Get()
        {
            using (var db = DBConnection.GetConnection())
            {
                return Transaction.GetAll(db);
            }
        }
    }
}
