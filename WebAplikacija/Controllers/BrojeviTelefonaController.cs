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
    public class BrojeviTelefona : ControllerBase
    {

        [HttpGet("VratiTelefon/{idTelefona}")]
        public async Task<ActionResult> VratiTelefon(int idTelefona)
        {
            try
            {
                OsobaTelefon telefon = DataProvider.VratiTelefon(idTelefona);
                BrojTelefonaPregled response = new BrojTelefonaPregled(telefon);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VratiTelefone/{idOsobe}")]
        public async Task<ActionResult> VratiTelefone(int idOsobe)
        {
            try
            {
                List<BrojTelefonaPregled> response = DataProvider.VratiBrojeve(idOsobe);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBrojTelefona/{idOsobe}")]
        public async Task<ActionResult> AddBrojTelefona(int idOsobe, [FromBody] BrojTelefonaPregled brojTelefona)
        {
            try
            {
                Osoba osoba = DataProvider.VratiOsobu(idOsobe);
                BrojTelefonaBasic btb = new BrojTelefonaBasic(brojTelefona.Id, brojTelefona.Telefon, osoba);
                DataProvider.DodajBrojTelefona(btb);

                return Ok("Broj telefona uspesno dodat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveBrojTelefona/{idBrojaTelefona}")]
        public async Task<ActionResult> RemoveBrojTelefona(int idBrojaTelefona)
        {
            try
            {
                DataProvider.ObrisiBrojTelefona(idBrojaTelefona);

                return Ok("Broj Telefona uspesno izbrisan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200