using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroservicioCedula.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CedulaController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public CedulaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{idCedula}")]
        public async Task<IActionResult> GetCedula(string idCedula)
        {
            // URL de la API de la SEP
            var url = $"https://www.cedulaprofesional.sep.gob.mx/cedula/buscaCedulaJson.action?json=%7B%27maxResult%27:%27100%27,%27nombre%27:%27%27,%27paterno%27:%27%27,%27materno%27:%27%27,%27idCedula%27:%27{idCedula}%27%7D";

            // Hacer la solicitud HTTP
            var response = await _httpClient.GetFromJsonAsync<CedulaResponse>(url);

            // Verificar si se encontró la cédula
            if (response?.Items == null || response.Items.Count == 0)
            {
                return NotFound("Cédula no encontrada");
            }

            // Devolver la información de la cédula
            return Ok(response.Items[0]);
        }
    }

    // Clase para mapear la respuesta JSON
    public class CedulaResponse
    {
        public List<CedulaItem> Items { get; set; } = new List<CedulaItem>();
    }

    public class CedulaItem
    {
        public int Anioreg { get; set; } 
        public string Desins { get; set; } = string.Empty;
        public string IdCedula { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int Inscons { get; set; } 
        public int Insedo { get; set; } 
    }
}