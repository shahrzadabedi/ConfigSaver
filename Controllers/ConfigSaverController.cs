using ConfigSaver.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConfigSaver.Controllers
{
    
    [RoutePrefix("api/ConfigSaver")]
    public class ConfigSaverController : ApiController
    {      
        [HttpGet]
        public IHttpActionResult Get(int input)
        {
            return Ok(1);
        }
        [HttpPost]
        [Route("SaveConfig")]
        public async Task SaveConfig(POSConfigKeyValue config)
        {
            ConfigSaver saver = new ConfigSaver(new Base64Encoder(), new JsonSerializer(), new RegistrySaver());
            await saver.SaveConfigAsync(config.Key, config.PosConfig);
        }
        [HttpPost]
        [Route("ReadConfigAsync")]
        public async Task<IHttpActionResult> ReadConfigAsync(POSConfigKeyValue config)
        {
            PosConfig res = null;
            try
            {
                ConfigSaver saver = new ConfigSaver(new Base64Encoder(), new JsonSerializer(), new RegistrySaver());
                res = (await saver.ReadConfigAsync<PosConfig>(config.Key));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(res);
        }
        [HttpGet]
        [Route("ReadConfig")]
        public IHttpActionResult ReadConfig(POSConfigKeyValue config)
        {
            PosConfig result = null;
            try
            {
                ConfigSaver saver = new ConfigSaver(new Base64Encoder(), new JsonSerializer(), new RegistrySaver());
                result = saver.ReadConfig<PosConfig>(config.Key);               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        public string GetPropertyValue(object obj)
        {
            var s = obj.GetType().GetProperty("Name").GetValue(obj,null);
            return "s";
        }
    }

    internal class Person
    {
        public string Name { get; set; }
        public string Family { get; set; }
    }

    internal class Car
    {
        public string Name { get; set; }
    }

    
}