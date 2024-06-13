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
    public class OsobaController : ControllerBase
    {

        [HttpGet("GetOsoba/{idOsobe}")]
        public async Task<ActionResult> GetOsoba(int idOsobe)
        {
            try
            {
                Osoba osoba = DataProvider.VratiOsobu(idOsobe);
                OsobaPregled osobaPregled = new OsobaPregled(osoba);

                return Ok(osobaPregled);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetOsobe")]
        public async Task<ActionResult> GetOsobe()
        {
            try
            {
                List<OsobaPregled> response = DataProvider.VratiOsobe();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddOsoba")]
        public async Task<ActionResult> AddOsoba([FromBody] OsobaBasic osobaBasic)
        {
            try
            {
                DataProvider.DodajOsobu(osobaBasic);

                return Ok("Osoba usepesno dodata");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeOsoba")]
        public async Task<ActionResult> ChangeOsoba([FromBody] OsobaBasic osobaBasic)
        {
            try
            {
                DataProvider.AzurirajOsobu(osobaBasic);

                return Ok("Osoba usepesno izmenjena");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveOsoba/{idOsobe}")]
        public async Task<ActionResult> RemoveOsoba(int idOsobe)
        {
            try
            {
                DataProvider.ObrisiOsobu(idOsobe);

                return Ok("Osoba uspesno obrisana");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200