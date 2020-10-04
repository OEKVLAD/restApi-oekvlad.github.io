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
    public class ContentPageController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var sql = new CreatorSql();
            return sql.request("select cm.module from page p " +
                                    "LEFT JOIN content_page cp " +
                                    "on cp.page_id = p.content_page_id " +
                                    "LEFT JOIN content_module cm " +
                                    "on cp.content_module_id = cm.id " +
                                    "where " +
                                    "p.id = 1;");

        }
    }
}
