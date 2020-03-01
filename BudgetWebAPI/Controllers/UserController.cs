using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetDataAccess.Models;
using BudgetDataAccess.Connections;
using System.Web.Http;

namespace BudgetWebAPI.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/user/{id}")]
        public BusinessObject<BudgetUser> Get(int id)
        {
            using(var db = DBConnection.GetConnection())
            {
                return BudgetUser.GetById(db, id);
            }
        }

        [HttpPost]
        [Route("api/user")]
        public BudgetUser VerifyLogin([FromBody]BudgetUser user)
        {
            using(var db = DBConnection.GetConnection())
            {
                var userModel = BudgetUser.GetByUserName(db, user.UserName);
                if(userModel != null && userModel.Password.Equals(user.Password))
                {
                    return userModel;
                }
                return null;
            }
        }
    }
}
