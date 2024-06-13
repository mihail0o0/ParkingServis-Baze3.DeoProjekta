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
    public class ParkingMesto : ControllerBase
    {

        [HttpGet("GetParkingMesto/{idParkingMesta}")]
        public async Task<ActionResult> GetParkingMesto(int idParkingMesta)
        {
            try
            {
                ParkingServis.Entiteti.ParkingMesto parkingMesto = DataProvider.VratiParkingMesto(idParkingMesta);

                ParkingMestoPregled response = new ParkingMestoPregled(parkingMesto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetSvaParkingMesta")]
        public async Task<ActionResult> GetSvaParkingMesta()
        {
            try
            {
                List<ParkingMestoPregled> response = DataProvider.VratiSvaParkingMesta();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetParkingMestaParkinga/{idParkinga}")]
        public async Task<ActionResult> GetParkingMestaParkinga(int idParkinga)
        {
            try
            {
                List<ParkingMestoPregled> response = DataProvider.VratiParkingMesta(idParkinga);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddParkingMesto/{idParkinga}")]
        public async Task<ActionResult> AddParkingMesto(int idParkinga, [FromBody] ParkingMestoPregled novoParkingMesto)
        {
            try
            {
                Parking parking = DataProvider.VratiParking(idParkinga);
                ParkingMestoBasic pmb = new ParkingMestoBasic(novoParkingMesto.ID, novoParkingMesto.TrenutniStatus, novoParkingMesto.ParkingMestoType, novoParkingMesto.NazivUlice, novoParkingMesto.Zona, novoParkingMesto.RedniBroj, novoParkingMesto.Sprat, parking);
                DataProvider.DodajParkingMesto(pmb);

                return Ok("Parking mesto uspesno dodato");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ChangeParkingMesto/{idParkinga}")]
        public async Task<ActionResult> ChangeParkingMesto(int idParkinga, [FromBody] ParkingMestoPregled parkingMesto)
        {
            try
            {
                Parking parking = DataProvider.VratiParking(idParkinga);
                ParkingMestoBasic pmb = new ParkingMestoBasic(parkingMesto.ID, parkingMesto.TrenutniStatus, parkingMesto.ParkingMestoType, parkingMesto.NazivUlice, parkingMesto.Zona, parkingMesto.RedniBroj, parkingMesto.Sprat, parking);
                DataProvider.AzurirajParkingMesto(pmb);

                return Ok("Parking mesto uspesno dodato");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("RemoveParkingMesto/{idParkingMesta}")]
        public async Task<ActionResult> RemoveParkingMesto(int idParkingMesta)
        {
            try
            {
                DataProvider.ObrisiParkingMesto(idParkingMesta);

                return Ok("Parking mesto uspesno izbrisano");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

#pragma warning restore CA2200