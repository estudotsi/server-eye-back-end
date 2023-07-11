using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_eye_back_end.Data;
using server_eye_back_end.Models;
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
			List<Os> oss = _service.ReadOss();
			
			return Ok(oss);
		}

		[HttpGet("{id}")]
		public IActionResult ReadOsById(int id)
		{
			Os os = _service.ReadOsById(id);

			if (os == null)
			{
				return NotFound();
			}
			return Ok(os);
		}

		[HttpPost]
		public IActionResult AddOs([FromBody]Os osRecebido) 
		{
			Os os = _service.AddOs(osRecebido);

			if(os == null)
			{
				return BadRequest("Problema ao gravar sistema operacional");
			}
			
			return Ok(os);

		}
	}

}
