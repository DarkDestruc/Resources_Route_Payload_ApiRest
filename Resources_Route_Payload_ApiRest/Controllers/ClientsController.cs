using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resources_Route_Payload_ApiRest.Models;
using System.Reflection.Metadata.Ecma335;

namespace Resources_Route_Payload_ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>
        {
        new Usuario{IdCliente=1, Name="Moises", Address="Martha de Rodos"},
        new Usuario{IdCliente=2,Name="Jocelin", Address="Via Salitre"}

        };
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetInformationClient()
        {
            return Ok(usuarios);
        }

        [HttpGet("id")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
             var usuario= usuarios.Find(x => x.IdCliente == id);
            if (usuario == null)
            {
            return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario) 
        {
            usuarios.Add(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.IdCliente }, usuario);
;                
        }
        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, [FromBody] Usuario usuario)
        {
            var usuarioExistente = usuarios.Find(u => u.IdCliente == id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Name = usuario.Name;
            usuarioExistente.Address = usuario.Address;
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult BorrarUsuario(int id)
        {
            var usuario = usuarios.Find(u => u.IdCliente == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuarios.Remove(usuario);
            return NoContent();
        }


    }
}
