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
    public class VoziloController : ControllerBase
    {

        [HttpGet("GetVozilo/{idVozila}")]
        public async Task<ActionResult> GetVozilo(int idVozila)
        {
            try
            {
                Vozilo vozilo = DataProvider.VratiVozilo(idVozila);
                VoziloPregled voziloPregled = new VoziloPregled(vozilo);

                return Ok(voziloPregled);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVozila")]
        public async Task<ActionResult> GetSvaVozila()
        {
            try
            {
                List<VoziloPregled> response = DataProvider.VratiSvaVozila();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddVozilo")]
        public async Task<ActionResult> AddVozilo([FromBody] VoziloBasic voziloBasic)
        {
            try
            {
                DataProvider.DodajVozilo(voziloBasic);

                return Ok("Vozilo usepesno dodato");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeVozilo")]
        public async Task<ActionResult> ChangeVozilo([FromBody] VoziloBasic voziloBasic)
        {
            try
            {
                DataProvider.AzurirajVozilo(voziloBasic);

                return Ok("Vozilo usepesno izmenjeno");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveVozila/{idVozila}")]
        public async Task<ActionResult> RemoveVozilo(int idVozila)
        {
            try
            {
                DataProvider.obrisiVozilo(idVozila);

                return Ok("Vozilo uspesno obrisano");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200