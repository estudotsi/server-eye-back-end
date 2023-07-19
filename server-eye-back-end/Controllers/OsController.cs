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
		private readonly IWebHostEnvironment _hostEnvironment;

		public OsController(IOsService service, IWebHostEnvironment hostEnvironment)
		{
			_service = service;
			_hostEnvironment = hostEnvironment;
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

		[HttpPost("upload-image/{osId}")]
		public async Task<IActionResult> AddImage(int osId)
		{
			Os os = _service.ReadOsById(osId);

			if (os == null)
			{
				return NoContent();
			}

			var file = Request.Form.Files[0];

			if (file.Length > 0)
			{
				DeleteImage(os.ImagemURL);
				os.ImagemURL = await SaveImage(file);
			}

			var osRetorno = _service.UpdateOs(os, osId);

			return Ok(osRetorno);
		}

		[HttpPost]
		public IActionResult AddOs([FromBody] Os osRecebido)
		{
			Os os = _service.AddOs(osRecebido);

			if (os == null)
			{
				return BadRequest("Problema ao gravar sistema operacional");
			}
			return Ok(os);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteOs(int id)
		{
			Os os = _service.DeleteOs(id);

			if (os == null)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateOs([FromBody] Os os, int id) 
		{
			Os osUpdated = _service.UpdateOs(os, id);

			if (osUpdated == null) 
			{
				return NotFound();
			}
			return Ok(osUpdated);
		}

		[NonAction]
		public void DeleteImage(string imageName)
		{
			var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);
			if (System.IO.File.Exists(imagePath))
			{
				System.IO.File.Delete(imagePath);
			}
		}

		[NonAction]
		public async Task<string> SaveImage(IFormFile imageFile)
		{
			string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).
				Take(10).
				ToArray()).Replace(' ', '-');

			imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

			var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"Resources/images", imageName);

			using (var filestream = new FileStream(imagePath, FileMode.Create))
			{
				await imageFile.CopyToAsync(filestream);
			}

			return imageName;
		}

	}

}
