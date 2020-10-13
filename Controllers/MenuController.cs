using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Database;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpGet]
        [Route("main")]
        public string Get(string url)
        {
            var sql = new CreatorSql();
            return sql.request("select " +
                "CONCAT( " +
                "CONCAT( " +
                " '{\"title\":\"', m.title, '\"', " +
                " ',\"url\":\"',  m.url, '\"', " +
                "',\"type\":\"', m.type, '\"}' " +
                " ) " +
                ") as json " +
                "from menu m " +
                "where  m.menu_name = 'main_menu' " +
                "order by m.sort ASC; ");
        }
    }
}
