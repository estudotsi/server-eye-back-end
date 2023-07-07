using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
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
	}
}
