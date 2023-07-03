using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_eye_back_end.Models;
using server_eye_back_end.Services.Interfaces;

namespace server_eye_back_end.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DBController : ControllerBase
	{
		private readonly IDBService _service;

		public DBController(IDBService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult ReadADBs()
		{
			var dbs = _service.ReadADbs();

			return Ok(dbs);
		}

		[HttpGet("{id}")]
		public IActionResult ReadDBAsById(int id)
		{
			DB db = _service.ReadDbById(id);

			if (db == null)
			{
				return NotFound();
			}
			return Ok(db);
		}
	}
}
