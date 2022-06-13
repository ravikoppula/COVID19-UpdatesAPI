using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVID19UpdatesAPI.Interfaces;
using COVID19UpdatesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COVID19UpdatesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class COVIDUpdatesController : Controller
    {
        #region constructor

        private readonly ICOVIDUpdatesService _covidUpdatesService;
        public COVIDUpdatesController(ICOVIDUpdatesService covidUpdatesService)
        {
            _covidUpdatesService = covidUpdatesService;
        }

        #endregion

        #region GetUpdates
        [HttpGet]
        [Route("getupdates")]
        public IActionResult GetUpdates()
        {           
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAllOwners action: {ex.Message}");
            }
        }

        #endregion

        #region Set Updates

        // GET api/covidupdates/getcovidupdates?country=Brazil&state=Ceara
        // https://localhost:44329/api/covidupdates/getcovidupdates?country=Brazil&state=Ceara
        [HttpGet("{id}")]
        [Route("getcovidupdates")]
        public ActionResult<IEnumerable<ViewUpdatesVM>> GetCOVIDUpdates(string country, string state, DateTime lastUpdatedDate)
        {
            try
            {
                var covidUpdateList = _covidUpdatesService.GetCOVID19Cases(country, state, lastUpdatedDate);
                return covidUpdateList;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside GetAllOwners action: {ex.Message}");
            }
        }

        #endregion 

    }
}