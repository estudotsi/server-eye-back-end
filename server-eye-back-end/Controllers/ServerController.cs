using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
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
			var servers = _service.ReadServers();

			return Ok(servers);
		}

		[HttpGet("{id}")]
		public IActionResult ReadServerById(int id)
		{
			var server = _service.ReadServerBiId(id);
			if (server == null)
			{
				return NotFound();
			} 
			return Ok(server);

		}
	}
}
