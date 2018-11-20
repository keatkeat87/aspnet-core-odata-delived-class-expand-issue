using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using ODataDelivedExpandIssue.Models;

namespace ODataDelivedExpandIssue.Controllers
{
    public class AdminsController : ODataController
    {
        private AccountContext Db;
        public AdminsController(
            AccountContext db
        ) {
            Db = db;
        }

        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.Format | AllowedQueryOptions.Count | AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Skip | AllowedQueryOptions.Top | AllowedQueryOptions.Expand, MaxExpansionDepth = 3)]
        public IActionResult Get()
        {
            return Ok(Db.Admins); // this not work!
            //return Ok(Db.Characters); // this will work!
        }
    }
}