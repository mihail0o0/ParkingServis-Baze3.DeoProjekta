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
    public class IskorisceneKarte : ControllerBase
    {

        [HttpGet("GetIskoriscenuKartu/{idKarte}")]
        public async Task<ActionResult> GetIskoriscenuKartu(int idKarte)
        {
            try
            {
                IskoriscenaKarta karta = DataProvider.VratiIskoriscenuKartu(idKarte);
                IskoriscenaKartaPregled response = new IskoriscenaKartaPregled(karta);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSveIskorisceneKarte")]
        public async Task<ActionResult> GetSveIskorisceneKarte()
        {
            try
            {
                List<IskoriscenaKartaPregled> response = DataProvider.VratiIskorisceneKarte();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddIskoriscenuKartu/{idVozila}/{idParkingMesta}/{idKarte}")]
        public async Task<ActionResult> AddIskoriscenuKartu(int idVozila, int idParkingMesta, int idKarte, [FromBody] IskoriscenaKartaPregled iskoriscenaKartaPregled)
        {
            try
            {
                Vozilo vozilo = DataProvider.VratiVozilo(idVozila);
                ParkingServis.Entiteti.ParkingMesto parkingMesto = DataProvider.VratiParkingMesto(idParkingMesta);
                Karta karta = DataProvider.VratiKartu(idVozila);
                IskoriscenaKartaBasic iskoriscenaKartaBasic = new IskoriscenaKartaBasic(iskoriscenaKartaPregled.Id, iskoriscenaKartaPregled.VremeIzvrseneKontrole ?? DateTime.Now, iskoriscenaKartaPregled.OdVreme, iskoriscenaKartaPregled.DoVreme, vozilo, parkingMesto, karta);
                DataProvider.DodajIskoriscenuKartu(iskoriscenaKartaBasic);

                return Ok("Karta uspesno dodata");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveIskoriscenaKarta/{idKarte}")]
        public async Task<ActionResult> RemoveIskoriscenuKartu(int idKarte)
        {
            try
            {
                DataProvider.ObrisiIskoriscenuKartu(idKarte);

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