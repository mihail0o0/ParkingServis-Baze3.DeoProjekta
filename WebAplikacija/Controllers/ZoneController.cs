using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkingServis;
using ParkingServis.Entiteti;

#pragma warning disable CA2200

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Zone : ControllerBase
    {

        [HttpGet("GetZonu/{idZone}")]
        public async Task<ActionResult> GetZonu(int idZone)
        {
            try
            {
                KartaZone zone = DataProvider.VratiZonu(idZone);
                ZonePregled response = new ZonePregled(zone);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSveZone/{idKarte}")]
        public async Task<ActionResult> GetSveZone(int idKarte)
        {
            try
            {
                List<ZonePregled> response = DataProvider.VratiZone(idKarte);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

#pragma warning restore CA2200