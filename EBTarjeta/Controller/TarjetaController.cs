using EBTarjeta.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBTarjeta.Controller
{
    // Controlador API para operaciones CRUD sobre tarjetas de crédito.
    // Expone endpoints REST: obtener lista, crear, actualizar y eliminar tarjetas.
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {       
        private readonly ApplicationDbContext _context;

        // El contexto de datos se inyecta por DI; usado para acceder al DbSet de tarjetas.
        public TarjetaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TarjetaController>
        // Devuelve todas las tarjetas almacenadas. Maneja errores y devuelve BadRequest en caso de excepción.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaTarjetas = await _context.TarjetaCredit.ToListAsync();
                return Ok(listaTarjetas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<TarjetaController>
        // Crea una nueva tarjeta. Valida Content-Type y el estado del modelo antes de persistir.
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TarjetaCredito tarjeta)
        {
            // Comprobación del Content-Type
            if (string.IsNullOrWhiteSpace(Request.ContentType) || !Request.ContentType!.Contains("application/json"))
            {
                return BadRequest("Content-Type must be 'application/json'.");
            }

            // Validación del modelo
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Añadir usando el DbSet explícito
                _context.TarjetaCredit.Add(tarjeta);
                await _context.SaveChangesAsync();

                // Devuelve 201 Created con la ubicación
                return Created($"/api/TarjetaCredito/{tarjeta.Id}", tarjeta);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TarjetaController>/5
        // Actualiza una tarjeta existente; comprueba que el Id de ruta coincida con el del cuerpo.
        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] TarjetaCredito tarjeta)
        {
            try
            {
                if (Id != tarjeta.Id)
                {
                    return NotFound();
                }
                _context.Update(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta fue actualizada con exito!" } );    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TarjetaController>/5
        // Elimina la tarjeta indicada por Id; devuelve NotFound si no existe.
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredit.FindAsync(Id);
                if (tarjeta == null)
                {
                    return NotFound();
                }
                _context.TarjetaCredit.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta fue eliminada con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
