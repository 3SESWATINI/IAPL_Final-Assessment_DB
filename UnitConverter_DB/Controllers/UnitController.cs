using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitConverter_DB.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {
        private UnitDbContext _dbContext;

        public UnitController(UnitDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       


        [HttpGet]
        [ActionName("MetricToImprial")]
        [Route("[action]/{unittype}/{Convertvalue}")]
        public double MetricToImprial(string unittype, double Convertvalue)  //function for calculating
        {
            try
            {
                double rValue = 0;
                if (unittype == null) { throw new Exception("Enter Proper UnitType"); }
                if (Convertvalue == 0) { throw new Exception("Enter value"); }
                var db = _dbContext.Units.Where(x => x.type == unittype).FirstOrDefault();
                if (db != null)
                {
                    var rates = db.rates;
                    if (rates != 0)
                    {
                        rValue = Convertvalue / Convert.ToDouble(rates);
                    }
                }
                return rValue;
                //returning calculation
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        [ActionName("ImprialToMetric")]
        [Route("[action]/{unittype}/{Convertvalue}")]
        public double ImprialToMetric(string unittype, double Convertvalue)  //function for calculating
        {
            try
            {
                double rValue = 0;
                if (unittype == null) { throw new Exception("Enter Proper UnitType"); }
                if (Convertvalue == 0) { throw new Exception("Enter value"); }
                var db = _dbContext.Units.Where(x => x.type == unittype).FirstOrDefault();
                if (db != null)
                {
                    var rates = db.rates;
                    if (rates != 0)
                    {
                        rValue = Convertvalue * Convert.ToDouble(rates);
                    }
                }
                return rValue;
                //returning calculation
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
