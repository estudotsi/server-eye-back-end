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
			List<App> apps = _service.ReadApps();

			return Ok(apps);
		}

		[HttpGet("{id}")]
		public IActionResult ReadAppsById(int id)
		{
			App app = _service.ReadAppById(id);
			
			if(app == null)
			{
				return NotFound();
			}
			return Ok(app);
		}

        [HttpPost]
        public IActionResult AddApp([FromBody] App appRecebido)
        {
            App app = _service.AddApp(appRecebido);

            if (app == null)
            {
                return BadRequest("Problema ao gravar aplicativo");
            }
            return Ok(app);
        }
    }
}
