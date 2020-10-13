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
        public string Get(string url)
        {
            

            var sql = new CreatorSql();


            return sql.request2("SELECT cb.block, cm.module_id FROM page p " +
                                    "left join content_page cp on p.content_page_id = cp.page_id " +
                                    "left join content_module cm on cm.module_id = cp.content_module_id " +
                                    "left join content_block cb on cb.id = cm.block_id " +
                                    "where " +
                                    "p.url =  '"+ url + "' " +
                                    "group by cm.block_id;");

        }
    }
}
