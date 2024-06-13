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
    public class KartaController : ControllerBase
    {

        [HttpGet("GetKartu/{idKarte}")]
        public async Task<ActionResult> GetKartu(int idKarte)
        {
            try
            {
                Karta karta = DataProvider.VratiKartu(idKarte);
                KartaPregled response = new KartaPregled(karta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSveKarte")]
        public async Task<ActionResult> GetSveKarte()
        {
            try
            {
                List<KartaPregled> response = DataProvider.VratiSveKarte();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPretplatneKarte")]
        public async Task<ActionResult> GetPretplatneKarte()
        {
            try
            {
                List<KartaPregled> response = DataProvider.VratiKarte();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddKartu/{idOsobe}/{idVozila}/{tipKarte}")]
        public async Task<ActionResult> AddBrojTelefona(int idOsobe, int idVozila, string tipKarte, [FromBody] KartaPregled kartaPregled)
        {
            try
            {
                Osoba osoba = DataProvider.VratiOsobu(idOsobe);
                Vozilo vozilo = DataProvider.VratiVozilo(idVozila);
                KartaBasic kartaBasic = new KartaBasic(kartaPregled.SerijskiBroj, tipKarte, kartaPregled.Datum, kartaPregled.OdVreme, kartaPregled.DoVreme, osoba, vozilo);
                DataProvider.DodajKartu(kartaBasic);

                return Ok("Karta uspesno dodata");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeKarta/{idOsobe}/{idVozila}/{tipKarte}")]
        public async Task<ActionResult> ChangeKarta(int idOsobe, int idVozila, string tipKarte ,[FromBody] KartaPregled kartaPregled)
        {
            try
            {
                Osoba osoba = DataProvider.VratiOsobu(idOsobe);
                Vozilo vozilo = DataProvider.VratiVozilo(idVozila);
                KartaBasic kartaBasic = new KartaBasic(kartaPregled.SerijskiBroj, tipKarte, kartaPregled.Datum, kartaPregled.OdVreme, kartaPregled.DoVreme, osoba, vozilo);
                DataProvider.AzurirajKartu(kartaBasic);

                return Ok("Karta uspesno azurirana");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // TODO ne radi, izmeni ili ga izbrisi kad ti kazem
        [HttpDelete("RemoveKarta/{idKarte}")]
        public async Task<ActionResult> RemoveKarta(int idKarte)
        {
            try
            {
                DataProvider.ObrisiKartu(idKarte);

                return Ok("Karta uspesno izbrisana");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

#pragma warning restore CA2200