using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NLog;
using NootBase.S3.Business;

namespace NootBase.S3.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly AppSettings _appSettings;
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly ITestManager _testManager;

        public ValuesController(IOptions<AppSettings> appSettings, ITestManager testManager)
        {
            _testManager = testManager;
            _appSettings = appSettings.Value;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.Debug("Endpoint Hit");
            _logger.Info("Index page says hello");

            return new string[] { "val22ue1", "value2","33223", _appSettings.ApplicationTitle, _testManager.Test() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
