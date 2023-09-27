using Microsoft.AspNetCore.Mvc;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;
namespace server_eye_back_end.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class ServerController : ControllerBase
	{
		private readonly IServerService _service;

		public ServerController(IServerService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult ReadServers()
		{
			List<Server> servers = _service.ReadServers();

			return Ok(servers);
		}

		[HttpGet("{id}")]
		public IActionResult ReadServerById(int id)
		{
			Server server = _service.ReadServerById(id);

			if (server == null)
			{
				return NotFound();
			} 
			return Ok(server);

		}

		[HttpGet("rede/{rede}")]
		public IActionResult ReadServerByRede(string rede)
		{
			List<Server> servers = _service.RedeServerByRede(rede);

			if (servers == null)
			{
				return NotFound();
			}
			return Ok(servers);

		}

        [HttpPost]
        public IActionResult AddServer([FromBody] Server serverRecebido)
        {
            Server server = _service.AddServer(serverRecebido);

            if (server == null)
            {
                return BadRequest("Problema ao gravar servidor");
            }
            return Ok(server);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServer(int id)
        {
          
            Server server = _service.DeleteServer(id);

            if (server == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServer([FromBody] Server server, int id)
        {
            Server serverUpdated = _service.UpdateServer(server, id);

            if (serverUpdated == null)
            {
                return NotFound();
            }
            return Ok(serverUpdated);
        }
    }
}
