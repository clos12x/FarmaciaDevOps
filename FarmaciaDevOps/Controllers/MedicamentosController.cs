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

        // GET: api/medicamentos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var medicamento = medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound("Medicamento no encontrado");
            }

            return Ok(medicamento);
        }

        // POST: api/medicamentos
        [HttpPost]
        public IActionResult Post(Medicamento medicamento)
        {
            medicamento.Id = medicamentos.Max(m => m.Id) + 1;

            medicamentos.Add(medicamento);

            return CreatedAtAction(nameof(GetById),
                new { id = medicamento.Id },
                medicamento);
        }

        // PUT: api/medicamentos/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Medicamento medicamentoActualizado)
        {
            var medicamento = medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound("Medicamento no encontrado");
            }

            medicamento.Nombre = medicamentoActualizado.Nombre;
            medicamento.Precio = medicamentoActualizado.Precio;
            medicamento.Stock = medicamentoActualizado.Stock;

            return Ok(medicamento);
        }

        // DELETE: api/medicamentos/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var medicamento = medicamentos.FirstOrDefault(m => m.Id == id);

            if (medicamento == null)
            {
                return NotFound("Medicamento no encontrado");
            }

            medicamentos.Remove(medicamento);

            return Ok("Medicamento eliminado correctamente");
        }
    }
}