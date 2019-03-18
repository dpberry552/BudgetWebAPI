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
    public class AccountController : ApiController
    {
        [Route("api/account")]
        public IEnumerable<BusinessObject<Account>> Get()
        {
            using(var db = DBConnection.GetConnection())
            {
                return Account.GetAll(db);
            }
        }

        [Route("api/account/{id}")]
        public BusinessObject<Account> Get(int id)
        {
            using (var db = DBConnection.GetConnection())
            {
                return Account.GetById(db, id);
            }
        }

        [HttpPost]
        [Route("api/account")]
        public void Post([FromBody]Account acct)
        {
            using(var db = DBConnection.GetConnection())
            {
                Account.Persist(db, acct);
            }
        }

        [HttpDelete]
        [Route("api/account/{id}")]
        public void Delete(int id)
        {
            using(var db = DBConnection.GetConnection())
            {
                Account.Delete(db, id);
            }
        }
    }
}
