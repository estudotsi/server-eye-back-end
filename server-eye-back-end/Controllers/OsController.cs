using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Services.Interfaces;
using server_eye_back_end.Services.Service;

namespace server_eye_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OsController : ControllerBase
	{
		private readonly IOsService _service;

		public OsController(IOsService service)
		{
			_service = service;
		}

        [HttpGet]
		public IActionResult ReadOss()
		{
			var oss = _service.ReadOss();
			
			return Ok(oss);
		}

		[HttpGet("{id}")]
		public IActionResult ReadOsById(int id)
		{
			var os = _service.ReadOsBiId(id);
			if (os == null)
			{
				return NotFound();
			}
			return Ok(os);

		}
	}

}
