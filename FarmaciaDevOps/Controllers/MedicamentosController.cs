using Microsoft.AspNetCore.Mvc;
using FarmaciaDevOps.Models;

namespace FarmaciaDevOps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentosController : ControllerBase
    {
        static List<Medicamento> medicamentos = new List<Medicamento>()
        {
            new Medicamento
            {
                Id = 1,
                Nombre = "Paracetamol",
                Precio = 5,
                Stock = 20
            },

            new Medicamento
            {
                Id = 2,
                Nombre = "Ibuprofeno",
                Precio = 8,
                Stock = 15
            }
        };

        // GET: api/medicamentos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(medicamentos);
        }

        // POST: api/medicamentos
        [HttpPost]
        public IActionResult Post(Medicamento medicamento)
        {
            medicamentos.Add(medicamento);

            return Ok(medicamento);
        }
    }
}