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
    public class Zakup : ControllerBase
    {

        [HttpGet("GetZakup/{idZakupa}")]
        public async Task<ActionResult> GetZakup(int idZakupa)
        {
            try
            {
                ParkingServis.Entiteti.Zakup zakup = DataProvider.VratiZakup(idZakupa);
                ZakupPregled response = new ZakupPregled(zakup);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSveZakupe")]
        public async Task<ActionResult> GetSveZakupe()
        {
            try
            {
                List<ZakupPregled> response = DataProvider.VratiZakupe();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddZakup")]
        public async Task<ActionResult> AddIskoriscenuKartu([FromBody] ZakupPregled zakupPregled)
        {
            try
            {
                Vozilo vozilo = DataProvider.VratiVozilo(zakupPregled.VoziloId);
                Osoba osoba = DataProvider.VratiOsobu(zakupPregled.OsobaId);
                ParkingServis.Entiteti.ParkingMesto parkingMesto = DataProvider.VratiParkingMesto(zakupPregled.ParkinMestoId);
                ZakupBasic zakupBasic = new ZakupBasic(zakupPregled.Id, zakupPregled.OdVreme ?? DateTime.Now, zakupPregled.DoVreme ?? DateTime.Now, zakupPregled.DatumPotpisa ?? DateTime.Now, osoba, vozilo, parkingMesto);
                DataProvider.DodajZakup(zakupBasic);

                return Ok("Zakup uspesno dodat");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveZakup/{idZakupa}")]
        public async Task<ActionResult> RemoveIskoriscenuKartu(int idZakupa)
        {
            try
            {
                DataProvider.ObrisiZakup(idZakupa);

                return Ok("Zakup uspesno izbrisan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200