using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppController : ControllerBase
	{
		private readonly IAppService _service;

		public AppController(IAppService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult ReadApps()
		{
			var apps = _service.ReadApps();

			return Ok(apps);
		}

		[HttpGet("{id}")]
		public IActionResult ReadAppsById(int id)
		{
			var app = _service.ReadAppBiId(id);
			
			if(app == null)
			{
				return NotFound();
			}
			return Ok(app);
		}
	}
}
