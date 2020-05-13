using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using Common.ExpressionExtend;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Test;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost("QueryTest")]
        public IEnumerable<TEST_MODEL> QueryTest([FromBody]List<QueryParam> queryParams)
        {
            return BLL.BllContanier.Get<ITestBll>().Query(queryParams);
        }

        [HttpPost("AddTest")]
        public bool AddTest([FromBody]TEST_MODEL model)
        {
            return BLL.BllContanier.Get<ITestBll>().AddTestModel(model) == 1;
        }

        [HttpPost("DelTest")]
        public bool DelTest([FromBody]string pkid)
        {
            return BLL.BllContanier.Get<ITestBll>().DelTestModel(pkid) == 1;
        }
    }
}
