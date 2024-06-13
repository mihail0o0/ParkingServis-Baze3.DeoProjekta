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
    public class ParkingController : ControllerBase
    {

        [HttpGet("GetParking/{idParkinga}")]
        public async Task<ActionResult> GetParking(int idParkinga)
        {
            try
            {
                Parking parking = DataProvider.VratiParking(idParkinga);
                ParkingPregled response = new ParkingPregled(parking);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetParkinge")]
        public async Task<ActionResult> GetParkinge()
        {
            try
            {
                List<ParkingPregled> response = DataProvider.VratiSveParkinge();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddParking")]
        public async Task<ActionResult> AddParking([FromBody] ParkingBasic parkingBasic)
        {
            try
            {
                DataProvider.DodajParking(parkingBasic);

                return Ok("Parking uspesno dodat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeParking")]
        public async Task<ActionResult> ChangeParking([FromBody] ParkingBasic parkingBasic)
        {
            try
            {
                DataProvider.AzurirajParking(parkingBasic);

                return Ok("Parking uspesno azururan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpDelete("RemoveParking/{idParkinga}")]
        public async Task<ActionResult> RemoveParking(int idParkinga)
        {
            try
            {
                DataProvider.ObrisiParking(idParkinga);

                return Ok("Parking uspesno obrisan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200